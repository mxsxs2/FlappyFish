using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeaWeed : MonoBehaviour
{
    [SerializeField]
    //Base length of the sea weed
    private int length = 10;
    [SerializeField]
    //Wether or not the seaweed is at the bottom or at the top of the screen
    public bool flipUpsideDown = false;
    [SerializeField]
    //The line renderer
    private LineRenderer lineRenderer;
    //Thick part of the weed
    private float maxWidth = 0.2f;
    //Skinny part of the weed
    private float miWidth = 0.03f;
    //Collider of the prefab
    PolygonCollider2D polygonCollider;


    void Awake()
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

        //Get the collider
        polygonCollider = lineRenderer.gameObject.AddComponent<PolygonCollider2D>();
        polygonCollider.isTrigger = true;
        //Set the path size
        polygonCollider.pathCount = 1;
    }

    void Update()
    {
        //Array of positions on the line
        Vector2[] points = new Vector2[length];
        //Set start
        int i = 0;
        //Set run until the length
        while (i < length)
        {
            //Generate vector for the line. Transform position has to be added, otherwise it is always in the middle
            Vector2 pos = new Vector2(Mathf.Sin(i + Time.time) / 2+transform.position.x, i * 0.5F + transform.position.y);
            //Add the point to the line renderer
            lineRenderer.SetPosition(i, pos);
            //Add to the points array. Without transform posotion.
            points[i] = new Vector2(Mathf.Sin(i + Time.time) / 2, i * 0.5F);
            i++;
        }
        //Add points to the collider
        polygonCollider.SetPath(0, points);

    }
}
