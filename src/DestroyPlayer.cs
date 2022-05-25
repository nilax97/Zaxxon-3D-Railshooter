using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPlayer : MonoBehaviour
{
	public GameObject explosion;
    public GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target.transform.position.z > transform.position.z)
        {
            Destroy(this.gameObject);
        }
    }

    // void OnCollisionEnter (Collision col)
    void OnCollisionEnter(Collision col)
    {
        Debug.Log(col.gameObject.name);
        //Debug.Log("ENEMY BULLET " + col.gameObject.name);
        if (col.gameObject.name == "pivot")
        {
        	Instantiate(explosion, transform.position, transform.rotation);
            //Debug.Log("bullet colliding with Player");
            // Destroy(col.gameObject);
        }
        if (col.gameObject.name == "Wall" || col.gameObject.name == "SideWall")
        {
            Destroy(this.gameObject);
        }
    }

}

