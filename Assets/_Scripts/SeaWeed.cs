using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeaWeed : MonoBehaviour
{
    [SerializeField]
    //Base length of the sea weed
    private int length = 10;
    [SerializeField]
    public bool flipUpsideDown = false;
    //The line renderer
    private LineRenderer lineRenderer;
    //Thick part of the weed
    private float maxWidth = 0.2f;
    //Skinny part of the weed
    private float miWidth = 0.03f;
    void Start()
    {
        //Add the line rendered
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        //Add the material
        lineRenderer.material = new Material(Shader.Find("Particles/Additive"));
        //Set base alpha
        float alpha = 1.0f;
        //Create new gradient
        Gradient gradient = new Gradient();
        //Add the colors and alphas
        gradient.SetKeys(
            new GradientColorKey[] { new GradientColorKey(new Color(0f, 256f, 0f), 0.0f), new GradientColorKey(new Color(0f, 1f, 0f), 1.0f) },
            new GradientAlphaKey[] { new GradientAlphaKey(alpha, 0.0f), new GradientAlphaKey(alpha, 1.0f) }
            );
        //Set gradient
        lineRenderer.colorGradient = gradient;
        //Set width
        lineRenderer.startWidth = flipUpsideDown ? maxWidth : miWidth;
        lineRenderer.endWidth = flipUpsideDown ? miWidth : maxWidth;
        //Add length
        lineRenderer.positionCount = length;
    }
    void Update()
    {
        //Set start
        int i = 0;
        //Set run until the length
        while (i < length)
        {
            //Generate vector for the line
            Vector2 pos = new Vector2(Mathf.Sin(i + Time.time) / 2, i * 0.5F);
            /*float radians = 90f * Mathf.Deg2Rad;
            float sin = Mathf.Sin(radians);
            float cos = Mathf.Cos(radians);

            float tx = pos.x;
            float ty = pos.y;

            pos = new Vector2(cos * tx - sin * ty, sin * tx + cos * ty);*/
            //Add the point to the line renderer
            lineRenderer.SetPosition(i, pos);
            i++;
        }

    }
}
