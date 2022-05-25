using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressBar : MonoBehaviour
{
    public float barDisplay; //current progress
    private Vector2 pos;
    private Vector2 size;
    public Texture2D emptyTex;
    public Texture2D fullTex;
    private GUIStyle currentStyle1 = null;
    private GUIStyle currentStyle2 = null;

    void OnGUI()
    {
        InitStyles();
        //draw the background:
        GUI.BeginGroup(new Rect(pos.x, pos.y, size.x, size.y));
        GUI.Box(new Rect(0, 0, size.x, size.y), "FUEL", currentStyle1);

        //draw the filled-in part:
        GUI.BeginGroup(new Rect(0, 0, size.x * barDisplay, size.y));
        GUI.Box(new Rect(0, 0, size.x, size.y), " ", currentStyle2);
        GUI.EndGroup();
        GUI.EndGroup();
    }

    private void InitStyles()
    {
        if (currentStyle1 == null)
        {
            currentStyle1 = new GUIStyle(GUI.skin.box);
            currentStyle1.normal.background = MakeTex(2, 2, new Color(0f, 0f, 0f, 0.5f));
            currentStyle1.fontSize = 30;
            currentStyle2 = new GUIStyle(GUI.skin.box);
            currentStyle2.normal.background = MakeTex(2, 2, new Color(0f, 1f, 0f, 0.5f));
            currentStyle2.fontSize = 30;
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
        pos = new Vector2(40.0f, 40.0f);
        size = new Vector2(250.0f, 50.0f);
    }

    // Update is called once per frame
    void Update()
    {
        barDisplay = RailController.fuel/RailController.maxFuel;
    }
}
