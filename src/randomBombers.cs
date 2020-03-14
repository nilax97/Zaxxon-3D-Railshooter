using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomBombers : MonoBehaviour
{
    public GameObject Bomber;
    public GameObject target;
    public int level = 1;
    public int minBombers = 2;
    public int numBombers;
    public int currCount;
    public float xMin = RailController.xMin;
    public float xMax = RailController.xMax;
    public float yMin = RailController.yMin;
    public float yMax = RailController.yMax;
    public float zMin = 0;
    public float zMax = 800;
    // Start is called before the first frame update
    void Start()
    {
        numBombers = minBombers * level;
        currCount = 0;
        level = 1;
        minBombers = 2;
        xMin = RailController.xMin;
        xMax = RailController.xMax;
        yMin = RailController.yMin;
        yMax = RailController.yMax;
        zMin = 0;
        zMax = 800;
    }

    // Update is called once per frame
    void Update()
    {
        int framecount = Time.frameCount;

        zMin = target.transform.position.z + createWall.space;
        zMax = Mathf.Min(zMin + createWall.space * 3, RailMover.levelLength + RailMover.dist_covered);
        if ((framecount % 100 == 0 || framecount == 1))
        {
            float x1 = Mathf.Max(target.transform.position.x - 150, xMin);
            float x2 = Mathf.Min(target.transform.position.x + 150, xMax);
            float y1 = Mathf.Max(target.transform.position.y - 150, yMin);
            float y2 = Mathf.Min(target.transform.position.y + 150, yMax);
            Vector3 pos = new Vector3(Random.Range(x1, x2), Random.Range(y1, y2), Random.Range(zMin, zMax));
            var x = Instantiate(Bomber, pos, transform.rotation);
            x.gameObject.name = Bomber.name;
            x.gameObject.SetActive(true);

        }
        if(RailMover.level % 2 == 1)
        {
            this.gameObject.SetActive(false);
        }
    }
}
