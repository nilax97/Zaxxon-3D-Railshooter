using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Homing_Missile : MonoBehaviour
{
    public float controlHeight = -150;
    public GameObject target;
    public GameObject explosion;
    public float speed = 100f;
    public float rotationspeed = 100f;
    public float sensitivity = 70;
    public float minY = 150;
    Vector3 direction;
    Quaternion lookRotation;

    // Start is called before the first frame update
    void Start()
    {
        controlHeight = -150;
        speed = 100f;
        sensitivity = 70;
        minY = 150;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z - target.transform.position.z < createWall.space - 100)
        {
            direction = (target.transform.position - transform.position).normalized;
            lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationspeed);
            //transform.LookAt(target.transform);
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
            
        }
        if (target.transform.position.z > transform.position.z)
        {
            Destroy(this.gameObject);
        }
    }
}
