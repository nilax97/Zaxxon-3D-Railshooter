using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Random_Missiles : MonoBehaviour
{
    public GameObject missile;
    public GameObject silo;
    public GameObject pivot;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 1; i < createWall.wallcount; ++i)
        {
            float xval = Random.Range(RailController.xMin, RailController.xMax);
            float zval = Random.Range(200, createWall.space - 100) + i * createWall.space + RailMover.dist_covered;

            var x = Instantiate(missile, Vector3.right * xval + Vector3.up * -190 + Vector3.forward * zval, missile.transform.rotation);
            x.gameObject.SetActive(true);
            x.gameObject.name = missile.name;

            var y = Instantiate(silo, Vector3.right * xval + Vector3.up * -150 + Vector3.forward * zval, silo.transform.rotation);
            y.gameObject.SetActive(true);
            y.gameObject.name = missile.name;
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
