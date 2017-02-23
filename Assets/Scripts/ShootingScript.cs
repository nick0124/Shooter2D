
using UnityEngine;
using System.Collections;

public class ShootingScript : MonoBehaviour
{
    public Transform bullet; //Префаб патрона
    public Rigidbody2D Body;//тело игрока
    public int BulletSpeed = 20; //Скорость патрона
    public int CurAmmoInCartridge = 10; //Текущее кол-во патронов в обойме
    public int AmmoInCartridge = 10; //Максимальное число патронов в обойме
    public int CurCartridge = 9;  //Текущее число обойм
    private float ReloadTimer = 0.0f; //Переменная для таймаута перезарядки
    public float ReloadTime = 1;//Время перезарядки оружия
    private Vector2 direction;//направление выстрела
    private Vector3 mouse_pos;
    private Vector3 object_pos;
    //private Animator anim;//анимация выстрела
    //public AudioClip Fire; //Звук стрельбы
    //public AudioClip Reload; //Звук перезярядки
    enum GunMode //режим стрельбы
    {
        single, //одиночный
        burst //очередь
    }
    private GunMode _gunMode;//Режимы стрельбы
    private float BurstTimer = 0;//Переменная необходимая для таймера перезарядки
    public float BurstRate = 0.1f;//Время между выстрелами

    void Start()
    {
        //anim = GetComponent<Animator>();//получаем анимацию выстрела
        _gunMode = GunMode.single; // режим стрельбы одиночный

    }

    // Update is called once per frame
    void Update()
    {
        direction = this.transform.right;//направление оружия

        if (BurstTimer > 0)
        {
            BurstTimer -= Time.deltaTime;
        }

        //смена режимов стрельбы
        if (Input.GetButtonDown("GunMode"))
        {
            switch (_gunMode)
            {
                case GunMode.single:
                    _gunMode = GunMode.burst;
                    break;
                case GunMode.burst:
                    _gunMode = GunMode.single;
                    break;
            }
        }

        //Стрельба
        //Если нажата ЛКМ и кол-во патронов больше 0 и время перезарядки меньше или равно 0 и режим стрельбы одиночный 
        if (Input.GetMouseButtonDown(0) & CurAmmoInCartridge > 0 & ReloadTimer <= 0 & _gunMode == GunMode.single)
        {
            Single();
        }
        //Если зажата ЛКМ и кол-во патронов больше 0 и время перезарядки меньше или равно 0 и режим стрельбы очередь и таймер очерди меньше или равно 0 
        if (Input.GetMouseButton(0) & CurAmmoInCartridge > 0 & ReloadTimer <= 0 & _gunMode == GunMode.burst & BurstTimer <= 0)
        {

            Burst();
        }

        //Перезарядка оружия
        if (Input.GetButtonDown("Reload Weapon") & CurCartridge > 0 & ReloadTimer <= 0)
        {
            ReloadTimer = ReloadTime;
            CurCartridge -= 1;//-1 обойма
            CurAmmoInCartridge = AmmoInCartridge;//Число патронов в обойме = максимальному числу патронов
            //audio.PlayOneShot(Reload);//проигрываем звук перезарядки
        }
        if (ReloadTimer > 0)                    //если таймер больше 0
        {
            ReloadTimer -= Time.deltaTime; //Переменная перезарядки уменьшается с течением времени
        }

        //вычисление позиции мыши
        mouse_pos = Input.mousePosition;
        object_pos = Camera.main.WorldToScreenPoint(Body.transform.position);
        mouse_pos.x = mouse_pos.x - object_pos.x;
    }

    //стрельба одиночными
    void Single()
    {
        if (mouse_pos.x > 0)
        {
            Transform bulletInstance = (Transform)Instantiate(bullet, transform.position, Quaternion.Euler(new Vector3(0, 0, this.transform.eulerAngles.z)));
            bulletInstance.GetComponent<Rigidbody2D>().velocity = new Vector2((Body.transform.GetComponent<Rigidbody2D>().velocity.x + 20 * direction.x), 20 * direction.y);
        }
        else
        {
            Transform bulletInstance = (Transform)Instantiate(bullet, transform.position, Quaternion.Euler(new Vector3(0, 0, 180 - this.transform.eulerAngles.z)));
            bulletInstance.GetComponent<Rigidbody2D>().velocity = new Vector2(Body.transform.GetComponent<Rigidbody2D>().velocity.x + 20 * direction.x * -1, 20 * direction.y);
        }
        CurAmmoInCartridge = CurAmmoInCartridge - 1; //-1 патрон в обойме
        //audio.PlayOneShot(Fire); //проигрываем звук выстрела
    }

    //стрельба очередями
    void Burst()
    {
        BurstTimer = BurstRate;//Промежуток между выстрелами
        if (mouse_pos.x > 0)
        {
            Transform bulletInstance = (Transform)Instantiate(bullet, transform.position, Quaternion.Euler(new Vector3(0, 0, this.transform.eulerAngles.z)));
            bulletInstance.GetComponent<Rigidbody2D>().velocity = new Vector2((Body.transform.GetComponent<Rigidbody2D>().velocity.x + BulletSpeed * direction.x), 20 * direction.y);
        }
        else
        {
            Transform bulletInstance = (Transform)Instantiate(bullet, transform.position, Quaternion.Euler(new Vector3(0, 0, 180 - this.transform.eulerAngles.z)));
            bulletInstance.GetComponent<Rigidbody2D>().velocity = new Vector2(Body.transform.GetComponent<Rigidbody2D>().velocity.x + BulletSpeed * direction.x * -1, 20 * direction.y);
        }
        CurAmmoInCartridge = CurAmmoInCartridge - 1; //-1 патрон в обойме
        //audio.PlayOneShot(Fire); //проигрываем звук выстрела
    }
}


