using UnityEngine;
using System.Collections;

public class HookScript : MonoBehaviour {

    /*    
    public Transform hookObj;
    public HingeJoint2D joint;
    public Rigidbody2D connectedObject;

    //public Transform GunBegin;
    private Vector3 mouse_pos;//позиция мыши
    private Vector3 object_pos;//позиция рук игрока
    private Vector3 rotationVector;//вектор поворота рук
    private float angle;//угол наклона
    private bool facingRight = true;//повернут ли игрок в право

	// Use this for initialization
	void Start () {
        joint = GetComponent<HingeJoint2D>();
        connectedObject = joint.connectedBody;
	}
	
	// Update is called once per frame
	void Update () {
	
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
        //transform.rotation = Quaternion.Euler(rotationVector);

        if (Input.GetKey(KeyCode.Mouse1))
        {
            // CreateHook();
            connectedObject.transform.eulerAngles = new Vector3(0, 0, rotationVector.z);

            connectedObject.transform.localScale = new Vector2(connectedObject.transform.localScale.x + 0.1f, connectedObject.transform.localScale.y);
            //connectedObject.GetComponent<BoxCollider2D>().
            //connectedObject.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
        else
        {
            //connectedObject.gameObject.SetActive(false);
            connectedObject.gameObject.GetComponent<SpriteRenderer>().enabled = true;
            //connectedObject.transform.localScale = new Vector2(1, 1);
        }

        
        
    }

    public void CreateHook()
    {
        Transform hook = (Transform)Instantiate(hookObj,transform.position,Quaternion.Euler(rotationVector));
        joint.connectedBody = hook.GetComponent<Rigidbody2D>();
    }
     */



    void Update()
    {
        Debug.DrawRay(transform.position, new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z), Color.green, 2, false);
    }
}
