using UnityEngine;
using System.Collections;

public class AimingScript : MonoBehaviour
{

    //public Transform GunBegin;
    public Transform Turret;//оружие
    public Transform Body;//тело игрока
    private Vector3 mouse_pos;//позиция мыши
    private Vector3 object_pos;//позиция рук игрока
    private Vector3 rotationVector;//вектор поворота рук
	private float angle;//угол наклона
    private bool facingRight = true;//повернут ли игрок в право
	
	// Update is called once per frame
	void Update () {
        //отрожаем игрока
        if (mouse_pos.x > 10 && !facingRight)
            Flip();
        else if (mouse_pos.x < -10 && facingRight)
            Flip();
	}

    void FixedUpdate()
    {
        //узнаем позицию мыши
        mouse_pos = Input.mousePosition;
        mouse_pos.z = 0.0f;
        //узнаем позицию рук
        object_pos = Camera.main.WorldToScreenPoint(transform.position);
        //нахождение позиции мыши на экране
        mouse_pos.x = mouse_pos.x - object_pos.x;
        mouse_pos.y = mouse_pos.y - object_pos.y;
        //угол поворота
        angle = Mathf.Atan2(mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg;
        //вектор поворота
        rotationVector = new Vector3(0, 0, angle);

        //если смотреть в право, кориктируется угол
        if (!facingRight)
            rotationVector.z = 180 - rotationVector.z;

        //смена угла рук игрока
        transform.rotation = Quaternion.Euler(rotationVector);
    }

    //метод который отрожает
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = Body.transform.localScale;
        theScale.x *= -1;
        Body.transform.localScale = theScale;
    }
}
