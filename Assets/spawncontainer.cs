using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawncontainer : MonoBehaviour
{
    public GameObject c1;
    public GameObject c2;
    public GameObject c3;
    public GameObject pivot;
    // Start is called before the first frame update
    void Start()
    {
        for(int i=1; i < createWall.wallcount; ++i)
        {
            float zval = Random.Range(200, createWall.space-100) + i * createWall.space + RailMover.dist_covered;
            float xval = Random.Range(RailController.xMin, RailController.xMax);
            int create = Random.Range(0, 10);
            int type = Random.Range(0, 4);
            if(create!=0)
            {
                GameObject c;
                if(type<=1)
                {
                    c = c1;
                }
                else if(type == 2)
                {
                    c = c2;
                }
                else
                {
                    c = c3;
                }
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
