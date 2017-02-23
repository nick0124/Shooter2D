using UnityEngine;
using System.Collections;

public class HealthScript : MonoBehaviour {

    public int Health = 10;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Bullet")
        {
            Health -= 1;
            if (Health < 0)
            {
                //Destroy(gameObject);
                //gameObject.GetComponent<SpriteRenderer>().sprite = deadImage;
                //GetComponent<PolygonCollider2D>().isTrigger = true;
            }
        }
    }
}
