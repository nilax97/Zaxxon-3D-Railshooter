using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjects : MonoBehaviour
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

    // void OnCollisionEnter (Collision col)
    void OnCollisionEnter(Collision col)
    {
        //Debug.Log("OUR BULLET " + col.gameObject.name);
        if (col.gameObject.name == "Stealth_Bomber")
        {
            //Debug.Log("Shooting the stealth bomber");
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(col.gameObject);
            Destroy(gameObject);
            RailController.fuel = Mathf.Min(RailController.fuel + 5, 20);
            updateScore.hit_score = updateScore.hit_score + 100;

        }
        else if(col.gameObject.name == "Wall")
        {
            Destroy(this.gameObject);
        }
        if (col.gameObject.name == "Missile Pointer")
        {
            Debug.Log("Shooting the Homing Missile!!");
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(col.gameObject);
            Destroy(gameObject);
            RailController.fuel = Mathf.Min(RailController.fuel + 5, 20);
            updateScore.hit_score = updateScore.hit_score + 100;
        }
        if (col.gameObject.name == "Silo")
        {
            Debug.Log("Shooting the Silo");
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(col.gameObject);
            Destroy(gameObject);
            RailController.fuel = Mathf.Min(RailController.fuel + 5, 20);
            updateScore.hit_score = updateScore.hit_score + 100;
        }
        if (col.gameObject.name == "Turret")
        {
            Debug.Log("Shooting the Turret");
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(col.gameObject);
            Destroy(gameObject);
            RailController.fuel = Mathf.Min(RailController.fuel + 5, 20);
            updateScore.hit_score = updateScore.hit_score + 100;
        }
    }
}
