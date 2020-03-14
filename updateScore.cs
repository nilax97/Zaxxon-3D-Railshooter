using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class updateScore : MonoBehaviour
{
    public GameObject mytext;
    public GameObject pivot;
    public int dist_score;
    public static int hit_score;
    int old_hit;
    // Start is called before the first frame update
    void Start()
    {
        dist_score = 0;
        hit_score = 0;
        old_hit = 0;
    }

    // Update is called once per frame
    void Update()
    {
        dist_score = (int)(pivot.transform.position.z);
        int total_score = dist_score + hit_score;
        if((int)(Time.time * 100) % 10 == 0 || hit_score!=old_hit)
        {
            mytext.GetComponent<Text>().text = "Score: " + total_score.ToString();
        }
        old_hit = hit_score;
    }
}
