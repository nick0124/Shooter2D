using UnityEngine;
using System.Collections;

public class Resize : MonoBehaviour {

   

    // Update is called once per frame
    void FixedUpdate()
    {
    }

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        foreach (ContactPoint2D contact in coll.contacts)
        {
            print(contact.collider.name + " hit " + contact.otherCollider.name);
            Debug.DrawRay(contact.point, contact.normal, Color.white);
        }
    }


}
