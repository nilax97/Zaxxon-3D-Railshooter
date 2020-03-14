using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createsidewall : MonoBehaviour
{

    public GameObject Wall;
    public GameObject refwall;
    public float num_walls;
    float length;
    float height;
    float thickness;
    // Start is called before the first frame update
    void Start()
    {
        length = refwall.transform.localScale.x;
        height = refwall.transform.localScale.y;
        thickness = refwall.transform.localScale.z;
        num_walls = RailMover.levelLength / height;
        for (int i=0; i<=num_walls; ++i)
        {
            Vector3 left = transform.position + transform.right * length * 1.5f + transform.forward * height * i;
            Vector3 right = transform.position + transform.right * length * -1.5f + transform.forward * height * i;
            for(int j=0; j<3; ++j)
            {
                var x = Instantiate(Wall, left + transform.up * height * (j - 1), Wall.transform.rotation);
                var y = Instantiate(Wall, right + transform.up * height * (j - 1), Wall.transform.rotation);
                x.gameObject.name = Wall.name;
                y.gameObject.name = Wall.name;
                x.gameObject.SetActive(true);
                y.gameObject.SetActive(true);
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
