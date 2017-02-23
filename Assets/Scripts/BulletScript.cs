using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {

    //public Transform explosion;
    public int Damage = 1;
    public int BulletLife = 10;
    //public bool isEnemyShot = false;

	// Use this for initialization
	void Start () 
    {
        Destroy(gameObject, BulletLife);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    /*
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
        else if (coll.gameObject.tag != "Player")
        {
            Destroy(gameObject);
        }
    }
    */

    void OnTriggerStay2D(Collider2D coll)
    {
        //Transform explosionInstance = (Transform)Instantiate(explosion, transform.position, Quaternion.Euler(new Vector3(0, 0, Random.Range(0,360))));

        if (coll.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
        else if (coll.gameObject.tag != "Player")
        {
            Destroy(gameObject);
        }
    }
     
    
}
