using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turret : MonoBehaviour
{
    //public GameObject laser;
    //public GameObject target;
    public int degreePerSecond;
    public int currDirection;
    float t;
    public float secondsToLerp;
    public GameObject laser;
    public float laserspeed = 50000.0f;
    public float laserInterval = 3;
    public float laserCount = 0;
    private Vector3 desiredDirection;
    // Start is called before the first frame update
    void Start()
    {
        degreePerSecond = 5;
        currDirection = -1;
        secondsToLerp = 0.09f;
        laserspeed = 200.0f;
        desiredDirection = new Vector3(0, 1, 1);
    }


    // Update is called once per frame
    void Update()
    {
        // If current angle is greater than -90 then rotate anti clockwise (multiply with -1)
        // If current angle is greater than less than -180 then rotate clockwise 
        t += Time.deltaTime / secondsToLerp;

        if (transform.localEulerAngles.y <= 180f && transform.localEulerAngles.y >= 175f)
        {
            currDirection = 1;

        }
        else if (transform.localEulerAngles.y >= 270f && transform.localEulerAngles.y <= 275f)
        {
            currDirection = -1;
        }

        transform.Rotate(new Vector3(0, currDirection*10, 0) * Time.deltaTime * degreePerSecond);
        laserCount += Time.deltaTime;

        //Quaternion tempQ = Quaternion.Euler(0, 0, 45); // rotate angle by 45 in z direction 
        //float angleRadians = tempQ.eulerAngles.z * Mathf.Deg2Rad; // I now find the radians of this angle
        //// calculate the new position which is 45 degrees upwards
        //Vector3 createPosition = new Vector3(transform.position.x + (Mathf.Sin(angleRadians) * 0.7f), transform.position.y + (Mathf.Cos(angleRadians) * 0.7f), 1);

        if (laserCount > laserInterval)
        {
            laserCount = 0;
            var s = Instantiate(laser.GetComponent<Rigidbody>(), transform.position + transform.forward * 50.0f, Quaternion.identity);
            s.gameObject.SetActive(true);
            //s.velocity = transform.forward * laserspeed * 1 + Vector3.up * laserspeed * 1;
            s.velocity = transform.forward * laserspeed * 0.5f + transform.up * laserspeed * 0.5f;
            Destroy(s.gameObject, 5);
        }
    }

}
