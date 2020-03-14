using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class managelives : MonoBehaviour
{
    private GameObject h1;
    private GameObject h2;
    private GameObject h3;
    private GameObject h4;
    private GameObject h5;
    int health;
    // Start is called before the first frame update
    void Start()
    {
        h1 = GameObject.Find("Heart 1");
        h2 = GameObject.Find("Heart 2");
        h3 = GameObject.Find("Heart 3");
        h4 = GameObject.Find("Heart 4");
        h5 = GameObject.Find("Heart 5");
    }

    // Update is called once per frame
    void Update()
    {
        health = RailController.lives;

        switch(health)
        {
            case 1:
                {
                    h1.SetActive(true);
                    h2.SetActive(false);
                    h3.SetActive(false);
                    h4.SetActive(false);
                    h5.SetActive(false);
                    break;
                }
            case 2:
                {
                    h1.SetActive(true);
                    h2.SetActive(true);
                    h3.SetActive(false);
                    h4.SetActive(false);
                    h5.SetActive(false);
                    break;
                }
            case 3:
                {
                    h1.SetActive(true);
                    h2.SetActive(true);
                    h3.SetActive(true);
                    h4.SetActive(false);
                    h5.SetActive(false);
                    break;
                }
            case 4:
                {
                    h1.SetActive(true);
                    h2.SetActive(true);
                    h3.SetActive(true);
                    h4.SetActive(true);
                    h5.SetActive(false);
                    break;
                }
            case 5:
                {
                    h1.SetActive(true);
                    h2.SetActive(true);
                    h3.SetActive(true);
                    h4.SetActive(true);
                    h5.SetActive(true);
                    break;
                }

        }

    }
}
