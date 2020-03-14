using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnturret : MonoBehaviour
{
    public GameObject turret;
    public GameObject pivot;
    // Start is called before the first frame update
    void Start()
    {
    	for(int i=1; i < createWall.wallcount; ++i)
        {
            float zval = Random.Range(200, createWall.space - 100) + i * createWall.space + RailMover.dist_covered;
            float xval = Random.Range(RailController.xMin, RailController.xMax);
            int create = Random.Range(0, 10);
            int type = Random.Range(1, 3);
            if(create!=0)
            {
                GameObject c;
                c = turret;
                var x = Instantiate(c, Vector3.right * xval + Vector3.up * -150 + Vector3.forward*zval, c.transform.rotation);
                x.gameObject.SetActive(true);
                x.gameObject.name = c.name;
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (RailMover.level % 2 == 0)
        {
            this.gameObject.SetActive(false);
        }
    }
}
