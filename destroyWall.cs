using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyWall : MonoBehaviour
{
    public GameObject player;
    public GameObject explosion;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.z > (transform.position.z + 25))
        {
            Destroy(this.gameObject);
        }
    }
    //void OnCollisionEnter(Collision col)
    //{
    //    if (col.gameObject.name == "RailBox")
    //    {
    //        Instantiate(explosion, transform.position, transform.rotation);
    //        Debug.Log("Wall colliding with Player");
    //        col.transform.position = col.transform.position - col.transform.forward * 100;
    //        //Destroy(this.gameObject);
    //    }
    //    if (col.gameObject.name == "Laser")
    //    {
    //        Instantiate(explosion, transform.position, transform.rotation);
    //        //Debug.Log("Enemy Bullet colliding with Player");
    //        //Destroy(this.gameObject);
    //    }
    //}
}
