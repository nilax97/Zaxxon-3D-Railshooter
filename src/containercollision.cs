using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class containercollision : MonoBehaviour
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
        Debug.Log(col.gameObject.name);
        if (col.gameObject.name == "Bullet")
        {
            RailController.fuel = Mathf.Min(RailController.fuel + 5,20);
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(this.gameObject);
            Destroy(col.gameObject);
            return;
        }
    }
}
