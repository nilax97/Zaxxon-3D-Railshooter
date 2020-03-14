using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class LineBeam : MonoBehaviour
{
    public float maxLength;

    public bool requireRaycastHit;

    public bool requireEnabled;

    private LineRenderer lineRenderer;

    private float closestPoint;

    private Gradient gradient;

    private Vector3[] points;

    private float prototypeLength;

    public virtual void Start()
    {
        this.lineRenderer = this.GetComponent<LineRenderer>();
        if (!this.lineRenderer)
        {
            Debug.LogWarning(("The 'LineBeam' script on " + this.gameObject.name) + " requires a line renderer! Deactivating.");
            this.enabled = false;
        }
        //lineRenderer.numPositions = 2;
        this.lineRenderer.useWorldSpace = false;
        this.gradient = new Gradient();
        this.gradient.SetKeys(this.lineRenderer.colorGradient.colorKeys, this.lineRenderer.colorGradient.alphaKeys);
        if (this.points == null)
        {
            this.points = new Vector3[this.lineRenderer.positionCount];
        }
        this.lineRenderer.GetPositions(this.points);
        float prototypeLength = this.points[this.points.Length - 1].magnitude;
        int p = 0;
        while (p < this.points.Length)
        {
            this.points[p] = this.points[p] * (this.maxLength / prototypeLength);
            p++;
        }
    }

    public virtual void Update()
    {
        if (!this.lineRenderer)
        {
            this.Start();
        }
        if (this.requireEnabled)
        {
            this.lineRenderer.enabled = this.enabled;
        }
        if (this.requireRaycastHit)
        {
            this.lineRenderer.enabled = this.lineRenderer.enabled && Physics.Raycast(this.transform.position, this.transform.forward, this.maxLength);
        }
        if (!this.lineRenderer.enabled)
        {
            return;
        }
        bool wasObstructed = this.closestPoint < this.maxLength; //	Check for obstructions
        this.closestPoint = this.maxLength;
        foreach (RaycastHit hit in Physics.RaycastAll(this.transform.position, this.transform.forward, this.maxLength))
        {
            if ((hit.point - this.transform.position).sqrMagnitude < (this.closestPoint * this.closestPoint))
            {
                this.closestPoint = (hit.point - this.transform.position).magnitude;
            }
        }
        foreach (Vector3 p in this.points)
        {
            Debug.DrawLine(this.transform.TransformPoint(p), this.transform.TransformPoint(p) + (Vector3.up * 0.25f), Color.gray);
        }
        Debug.DrawLine(this.transform.position, this.transform.position + (this.transform.forward * this.closestPoint), Color.blue);
        if ((this.closestPoint >= this.maxLength) && wasObstructed) //	If obstruction has been cleared since last frame, reset beam
        {
            this.lineRenderer.colorGradient = this.gradient;
            this.lineRenderer.positionCount = this.points.Length;
            this.lineRenderer.SetPositions(this.points);
            return;
        }
        float progress = this.closestPoint / this.maxLength; //	Generate partial beam
        Gradient colorGradient = new Gradient();
        //print(progress + " * " + gradient.colorKeys.Length + " = " + progress * (gradient.colorKeys.Length - 1) + " | " + Mathf.Ceil(progress * (points.Length - 1)));
        GradientColorKey[] colorKeys = new GradientColorKey[(int)Mathf.Max(2, 1 + Mathf.Ceil(progress * (this.gradient.colorKeys.Length - 1)))];
        GradientAlphaKey[] alphaKeys = new GradientAlphaKey[(int)Mathf.Max(2, 1 + Mathf.Ceil(progress * (this.gradient.alphaKeys.Length - 1)))];
        int i = 0;
        while (i < Mathf.Max(colorKeys.Length, alphaKeys.Length))
        {
            if (i < colorKeys.Length)
            {
                colorKeys[i] = new GradientColorKey(this.gradient.colorKeys[i].color, Mathf.Clamp01(this.gradient.colorKeys[i].time / progress));
            }
            if (i < alphaKeys.Length)
            {
                alphaKeys[i] = new GradientAlphaKey(this.gradient.alphaKeys[i].alpha, Mathf.Clamp01(this.gradient.alphaKeys[i].time / progress));
            }
            i++;
        }
        colorKeys[colorKeys.Length - 1].color = this.gradient.Evaluate(progress);
        alphaKeys[alphaKeys.Length - 1].alpha = colorKeys[colorKeys.Length - 1].color.a;
        colorGradient.SetKeys(colorKeys, alphaKeys);
        this.lineRenderer.colorGradient = colorGradient;
        this.lineRenderer.positionCount = (int) Mathf.Max(2, Mathf.Min(1 + Mathf.Ceil(progress * (this.points.Length - 1)), this.points.Length));
        this.lineRenderer.SetPositions(this.points);
        this.lineRenderer.SetPosition(this.lineRenderer.positionCount - 1, Vector3.forward * this.closestPoint);
    }

    public virtual void OnEnable()
    {
        if (this.requireEnabled && this.lineRenderer)
        {
            this.lineRenderer.enabled = true;
        }
    }

    public virtual void OnDisable()
    {
        if (this.requireEnabled && this.lineRenderer)
        {
            this.lineRenderer.enabled = false;
        }
    }

    public LineBeam()
    {
        this.maxLength = 100f;
        this.requireEnabled = true;
    }

}