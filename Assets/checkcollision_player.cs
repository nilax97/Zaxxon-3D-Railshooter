using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkcollision_player : MonoBehaviour
{
    public GameObject explosion;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision col)
    {
        // Debug.Log("Colliding with ->");
        //Debug.Log("OUR PLAYER " + col.gameObject.name);
        if (col.gameObject.name == "Wall")
        {
            RailController.lives = RailController.lives - 1;
            RailController.fuel = RailController.maxFuel;
            Instantiate(explosion, transform.position, transform.rotation);
            Debug.Log("Wall colliding with Player" + col.gameObject.transform.position);
            this.transform.position = this.transform.position - this.transform.forward * 250;
            Destroy(col.gameObject);
            return;
        }
        if (col.gameObject.name == "Laser")
        {
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(col.gameObject);
            RailController.lives = RailController.lives - 1;
            RailController.fuel = RailController.maxFuel;
            Debug.Log("Enemy Bullet colliding with Player");
            //Destroy(this.gameObject);
            return;
        }
        if(col.gameObject.name == "Container1" || col.gameObject.name == "Container2" || col.gameObject.name == "Container3")
        {
            RailController.lives = RailController.lives - 1;
            RailController.fuel = RailController.maxFuel;
            Instantiate(explosion, transform.position, transform.rotation);
            Debug.Log("Container colliding with Player" + col.gameObject.transform.position);
            this.transform.position = this.transform.position - this.transform.forward * 250;
            Destroy(col.gameObject);
            return;
        }
        if(col.gameObject.name == "Stealth_Bomber")
        {
            RailController.lives = RailController.lives - 1;
            RailController.fuel = RailController.maxFuel;
            Instantiate(explosion, transform.position, transform.rotation);
            Debug.Log("Bomber colliding with Player" + col.gameObject.transform.position);
            
            Destroy(col.gameObject);
            return;
        }
        if (col.gameObject.name == "Silo")
        {
            RailController.lives = RailController.lives - 1;
            RailController.fuel = RailController.maxFuel;
            Instantiate(explosion, transform.position, transform.rotation);
            Debug.Log("Silo colliding with Player" + col.gameObject.transform.position);

            Destroy(col.gameObject);
            return;
        }
        if (col.gameObject.name == "Missile Pointer")
        {
            RailController.lives = RailController.lives - 1;
            RailController.fuel = RailController.maxFuel;
            Instantiate(explosion, transform.position, transform.rotation);
            Debug.Log("Missile colliding with Player" + col.gameObject.transform.position);

            Destroy(col.gameObject);
            return;
        }
        if (col.gameObject.name == "Turret")
        {
            RailController.lives = RailController.lives - 1;
            RailController.fuel = RailController.maxFuel;
            Instantiate(explosion, transform.position, transform.rotation);
            Debug.Log("Turret colliding with Player" + col.gameObject.transform.position);

            Destroy(col.gameObject);
            return;
        }
    }
}
