using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killobject : MonoBehaviour
{
    public GameObject pivot;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(pivot.transform.position.z - transform.position.z > 250)
        {
            Destroy(this.gameObject);
        }
    }
}
