using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RailController : MonoBehaviour
{
    public static float xMax = 140;
    public static float xMin = -140;
    public static float yMax = 150;
    public static float yMin = -150;
    public float maxRoll;
    public float maxPitch;
    public float maxYaw;
    public float speed;

    public GameObject pivot;

    public GameObject shot;
    public float shotspeed;

    public static float maxFuel;
    public static float fuel;
    public static int lives;

    public float shotInterval;
    public float shotCount;

    public GameObject explode;
    public GameObject RailBox;

    public static RailController instance;
    // Start is called before the first frame update

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        instance = this;
        pivot = GameObject.Find("pivot");
        shot = GameObject.Find("Bullet");
        RailBox = GameObject.Find("RailBox");
        
        xMax = 140;
        xMin = -140;
        yMax = 150;
        yMin = -150;
        maxRoll = 15;
        maxPitch = 15;
        maxYaw = 0;
        speed = 5;
        shotspeed = 200.0f;
        lives = 5;
        maxFuel = 20;
        fuel = maxFuel;

        shotInterval = 0.2f;
        shotCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        float rollInput = 0;
        float pitchInput = 0;
        float xVel = 0;
        float yVel = 0;

        rollInput = -Input.GetAxis("Horizontal");
        pitchInput = -Input.GetAxis("Vertical");

        if(Input.GetKey("h"))
        {
            lives = 5;
            Debug.Log("Lives" + lives);
        }

        //if (Input.GetKey(KeyCode.LeftArrow))
        //{
        //    rollInput = 1;
        //}
        //else if (Input.GetKey(KeyCode.RightArrow))
        //{
        //    rollInput = -1;
        //}

        //if (Input.GetKey(KeyCode.DownArrow))
        //{
        //    pitchInput = -1;
        //}
        //else if (Input.GetKey(KeyCode.UpArrow))
        //{
        //    pitchInput = 1;
        //}

        if (pivot.transform.position.y <= yMin)
        {
            pitchInput = Mathf.Min(pitchInput, 0);
        }
        else if (pivot.transform.position.y >= yMax)
        {
            pitchInput = Mathf.Max(pitchInput, 0);
        }

        if (pivot.transform.position.x <= xMin)
        {
            rollInput = Mathf.Min(rollInput, 0);
        }
        else if (pivot.transform.position.x >= xMax)
        {
            rollInput = Mathf.Max(rollInput, 0);
        }

        Quaternion targetRotation = Quaternion.Euler(pitchInput * maxPitch, -rollInput * maxYaw, rollInput * maxRoll);

        pivot.transform.rotation = Quaternion.RotateTowards(pivot.transform.rotation, targetRotation, 1.0f);

        Vector3 angles = pivot.transform.rotation.eulerAngles;

        if (angles.x > maxPitch + 1)
        {
            yVel = ((360 - angles.x) / maxPitch) * speed;
        }
        else if (angles.x > 0)
        {
            yVel = -(angles.x / maxPitch) * speed;
        }

        if (angles.z > maxRoll + 1)
        {
            xVel = ((360 - angles.z) / maxRoll) * speed;
        }
        else if (angles.z > 0)
        {
            xVel = -(angles.z / maxRoll) * speed;
        }

        if (pivot.transform.position.y < yMin)
        {
            yVel = Mathf.Max(yVel, 0);
            float xpos = pivot.transform.position.x;
            float ypos = Mathf.Max(Mathf.Min(pivot.transform.position.y, yMax), yMin);
            float zpos = pivot.transform.position.z;
            pivot.transform.position = new Vector3(xpos, ypos, zpos);
        }
        if (pivot.transform.position.y > yMax)
        {
            yVel = Mathf.Max(yVel, 0);
            float xpos = pivot.transform.position.x;
            float ypos = Mathf.Max(Mathf.Min(pivot.transform.position.y, yMax), yMin);
            float zpos = pivot.transform.position.z;
            pivot.transform.position = new Vector3(xpos, ypos, zpos);
        }
        pivot.transform.position = pivot.transform.position + RailBox.transform.right * xVel + RailBox.transform.up * yVel;
        //pivot.transform.Translate(new Vector3(xVel, yVel, 0));


        shotCount += Time.deltaTime;

        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Fire1")) && shotCount > shotInterval)
        {
            shotCount = 0;
            var s = Instantiate(shot.GetComponent<Rigidbody>(), pivot.transform.position + pivot.transform.forward * 2, Quaternion.identity);
            s.gameObject.name = shot.name;
            s.velocity = pivot.transform.forward * shotspeed;
            Destroy(s.gameObject, 5);
        }

        fuel -= Time.deltaTime/2;
        if(fuel <= 0)
        {
            lives = lives - 1;
            fuel = maxFuel;
        }
        if(lives == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
