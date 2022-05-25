using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createWall : MonoBehaviour
{
    public float level;
    public float numCubes;
    public GameObject Wall;
    public GameObject player;
    public static int wallcount = 10;
    float length;
    float height;
    public static float space = RailMover.levelLength / wallcount;
    float thickness;
    // Start is called before the first frame update
    void Start()
    {
        //for (int i = 0; i < numCubes; i++) {
        //    Vector3 temp = transform.position + transform.right * 70;
        //    Instantiate(Cube, temp , transform.rotation);
        //}
        length = Wall.transform.localScale.x;
        height = Wall.transform.localScale.y;
        thickness = Wall.transform.localScale.z;
        wallcount = 10;
        space = RailMover.levelLength / wallcount;
        for (int k=1; k<=wallcount; ++k)
        {
            int free1 = Random.Range(1, 9);
            int free2 = Random.Range(1, 9);
            for (int i = 0; i < 3; ++i)
            {
                for (int j = 0; j < 3; ++j)
                {
                    if (i * 3 + j == free1 || i * 3 + j == free2)
                    {
                        continue;
                    }
                    Vector3 temp = transform.position + transform.right * length * (i - 1) + transform.up * height * (j - 1) + transform.forward * k * space;
                    var x = Instantiate(Wall, temp, transform.rotation);
                    x.gameObject.name = Wall.name;
                    x.gameObject.SetActive(true);

                }
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
