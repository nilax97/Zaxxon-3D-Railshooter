using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RailMover : MonoBehaviour
{
    public float moveSpeed;
    public static bool move = true;
    public static int level = 1;
    public static float levelLength = 5000;
    public static RailMover instance;
    public static float dist_covered;
    int flag;

    public GameObject wall;
    public GameObject sidewall;
    public GameObject fuel;
    public GameObject turrent;
    public GameObject bomber;
    public GameObject missile;
    public GameObject floor;
    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 100;
        instance = this;
        level = 1;
        levelLength = 5000;
        dist_covered = 0;
        flag = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(level);
        transform.Translate(transform.forward * moveSpeed * Time.deltaTime * 1);
        //if (transform.position.z > 100)
        //{
        //    transform.Translate(transform.forward * -1 * 100);
        //}

        if(level == 2)
        {
            levelLength = 5000;
        }
        if (level == 3)
        {
            levelLength = 7500;
        }
        if (level == 4)
        {
            levelLength = 7500;
        }
        if (level == 5)
        {
            levelLength = 10000;
        }
        if (level > 5)
        {
            Application.Quit();
        }
        if(transform.position.z > levelLength + dist_covered)
        {
            dist_covered = dist_covered + levelLength;
            level++;
            flag = 0;
        }
        int change = flag;
        if(level % 2 == 1 && flag == 0)
        {
            var x = Instantiate(wall, transform.position, Quaternion.identity);
            x.SetActive(true);
            x.gameObject.name = wall.name;

            var y = Instantiate(sidewall, transform.position, Quaternion.identity);
            y.SetActive(true);
            y.gameObject.name = sidewall.name;

            var z = Instantiate(fuel, transform.position, Quaternion.identity);
            z.SetActive(true);
            z.gameObject.name = fuel.name;

            var t = Instantiate(floor, transform.position + 2500 * Vector3.forward + -160 * Vector3.up, Quaternion.identity);
            t.SetActive(true);
            t.gameObject.name = floor.name;
            change = 1;
        }
        if(level % 2 == 0 && flag == 0)
        {
            var a = Instantiate(bomber, transform.position, Quaternion.identity);
            a.SetActive(true);
            a.gameObject.name = bomber.name;
            change = 1;
        }
        if(level == 3 && flag == 0)
        {
            var b = Instantiate(turrent, transform.position, Quaternion.identity);
            b.SetActive(true);
            b.gameObject.name = turrent.name;
            change = 1;
        }
        if(level == 4 && flag == 0)
        {
            MissileScript.shoot = 1;
            change = 1;
        }
        if(level == 5 && flag == 0)
        {
            var c = Instantiate(missile, transform.position, Quaternion.identity);
            c.gameObject.name = missile.name;
            c.SetActive(true);
            change = 1;
        }
        if(change == 1)
        {
            flag = 1;
        }
    }
}
