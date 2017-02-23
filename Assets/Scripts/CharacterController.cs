using UnityEngine;
using System.Collections;

public class CharacterController : MonoBehaviour
{
    public float moveForce = 10f;//максимальная скорость бегаигрока
    public float maxSpeed = 20;//максимальная скорость 
    public float jumpForce = 700f;//сила прыжка
    private bool grounded = false;//стоит ли на земле
    public Transform groundCheck;//объект проверяющий столкновение с землей
    public float groundRadius = 0.2f;//его радиус
    public LayerMask whatIsGround;//что является землей
    private int score;

    private float move;

    void Update()
    {
        //проверка стояния на земле
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);

        move = Input.GetAxis("Horizontal");

        //прыжок
        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)))
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce));
        }

        //бег влево, вправо
        //GetComponent<Rigidbody2D>().velocity = new Vector2(move * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);

        if(Mathf.Abs(transform.GetComponent<Rigidbody2D>().velocity.x) < maxSpeed)//если скорость больше максимальной то не применяем силу
            GetComponent<Rigidbody2D>().AddForce(new Vector2(move * moveForce, 0));

        

        //выход и перезагрузка уровня
        /*
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.LoadLevel(0);
        }
        if (Input.GetKey(KeyCode.R))
        {
            Application.LoadLevel(Application.loadedLevel);
        }
         */
    }

    //для собирания бонусов
    /*
    void OnCollisionEnter2D(Collision2D col)
    {

        if (col.gameObject.name == "coin")
        {
            Destroy(col.gameObject);
            score++;
        }

        if (col.gameObject.name == "enemy")
        {
            Application.LoadLevel(2);
        }
        //Application.LoadLevel(Application.loadedLevel);
    }
     */
}