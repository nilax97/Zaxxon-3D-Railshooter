using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileScript : MonoBehaviour
{
    public GameObject explosion;
	public float controlHeight = -40;
    public float speed = 1;
    public float sensitivity = 70;
    public float minY = 20;
    public GameObject laser;
    public float laserspeed = 50000.0f;
    public float laserInterval = 40;
    public float laserCount = 0;
    public static int shoot = 0;

    // Start is called before the first frame
    void Start()
    {
        laserspeed = 200.0f;
    }

    // Update is called once per frame
    void Update()
    {
    	// if (transform.position.y > controlHeight)
     //    {
     //        var vec2tar = new Vector3(target.position.x,Mathf.Max(target.position.y,minY),target.position.z) - transform.position;
     //        var rot2tar = Quaternion.LookRotation(vec2tar);
     //        transform.rotation = Quaternion.RotateTowards(transform.rotation, rot2tar, sensitivity * Time.deltaTime);
     //    }
     if(shoot == 0)
        {
            return;
        }
        transform.Translate(transform.forward * speed * Time.deltaTime * -0.2f);

        laserCount += Time.deltaTime;

        if (laserCount > laserInterval)
        {
            laserCount = 0;
            var s = Instantiate(laser, transform.position + transform.forward * -0.4f, Quaternion.identity);
            s.gameObject.GetComponent<Rigidbody>().velocity = transform.forward * laserspeed * -1;
            s.gameObject.SetActive(true);
            s.gameObject.name = laser.name;
            Destroy(s.gameObject, 5);
        }
        if (RailMover.level % 2 == 1)
        {
            this.gameObject.SetActive(false);
        }
    }

    void OnCollisionEnter(Collision col)
    {
        Debug.Log(col.gameObject.name);
        if (col.gameObject.name == "Bullet")
        {
            RailController.fuel = Mathf.Min(RailController.fuel + 5, 20);
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(this.gameObject);
            Destroy(col.gameObject);
            return;
        }
    }
}
