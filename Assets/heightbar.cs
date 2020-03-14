using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heightbar : MonoBehaviour
{
    public float barDisplay; //current progress
    private Vector2 pos;
    private Vector2 size;
    public Texture2D emptyTex;
    public Texture2D fullTex;
    private GUIStyle currentStyle1 = null;
    private GUIStyle currentStyle2 = null;
    private GameObject pivot;

    void OnGUI()
    {
        InitStyles();
        //draw the background:
        GUI.BeginGroup(new Rect(pos.x, pos.y, size.x, size.y));
        GUI.Box(new Rect(0, 0, size.x, size.y), " ", currentStyle1);

        //draw the filled-in part:
        GUI.BeginGroup(new Rect(0, 0, size.x, size.y * barDisplay));
        GUI.Box(new Rect(0, 0, size.x, size.y), " ", currentStyle2);
        GUI.EndGroup();
        GUI.EndGroup();
    }

    private void InitStyles()
    {
        if (currentStyle1 == null)
        {
            currentStyle2 = new GUIStyle(GUI.skin.box);
            currentStyle2.normal.background = MakeTex(2, 2, new Color(0f, 0f, 0f, 1.0f));
            currentStyle2.fontSize = 30;
            currentStyle1 = new GUIStyle(GUI.skin.box);
            currentStyle1.normal.background = MakeTex(2, 2, new Color(1f, 1f, 1f, 0.75f));
            currentStyle1.fontSize = 30;
        }
    }

    private Texture2D MakeTex(int width, int height, Color col)
    {
        Color[] pix = new Color[width * height];
        for (int i = 0; i < pix.Length; ++i)
        {
            pix[i] = col;
        }
        Texture2D result = new Texture2D(width, height);
        result.SetPixels(pix);
        result.Apply();
        return result;
    }

    // Start is called before the first frame update
    void Start()
    {
        pivot = GameObject.Find("pivot");
        pos = new Vector2(50.0f, 400.0f);
        size = new Vector2(65.0f, 400.0f);
    }

    // Update is called once per frame
    void Update()
    {
        float height = pivot.transform.position.y;
        barDisplay = 1 - (height - RailController.yMin) / (RailController.yMax - RailController.yMin);
        //Debug.Log(barDisplay);
    }
}
