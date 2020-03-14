using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjFollow : MonoBehaviour
{
    public GameObject player;
    float distance;
    float height;
    float length;
    Quaternion init_rotation;
    public float smooth = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        distance = transform.position.z;
        height = transform.position.y;
        length = transform.position.x;
        init_rotation = transform.rotation;
        player = GameObject.Find("player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= Vector3.forward * distance;
        transform.position -= Vector3.up * height;
        transform.position += Vector3.left * length;
        transform.position = Vector3.Lerp(transform.position, player.transform.position, Time.deltaTime * smooth);
        transform.position += Vector3.forward * distance;
        transform.position += Vector3.up * height;
        transform.position -= Vector3.left * length;

        transform.rotation = Quaternion.RotateTowards(transform.rotation, player.transform.rotation * init_rotation, 1.0f);
    }
}
