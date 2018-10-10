using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seaweed : MonoBehaviour
{
    [SerializeField]
    //Base length of the sea weed
    public float baseLength = 8;
    [SerializeField]
    //Wether or not the seaweed is at the bottom or at the top of the screen
    public bool flipUpsideDown = false;
    [SerializeField]
    //The line renderer
    private LineRenderer lineRenderer;
    //Thick part of the weed
    private float maxWidth = 0.2f;
    //Skinny part of the weed
    private float minWidth = 0.03f;
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



        //Get the collider
        polygonCollider = lineRenderer.gameObject.AddComponent<PolygonCollider2D>();
        polygonCollider.isTrigger = true;
        //Set the path size
        polygonCollider.pathCount = 1;
    }

    void Start()
    {
        //Set width
        lineRenderer.startWidth = maxWidth;
        lineRenderer.endWidth = minWidth;   
    }

    void Update()
    {
        //Add length
        lineRenderer.positionCount = (int)Mathf.Ceil(baseLength);
        //Generate the line and points
        GeneratePoints();
        //Remove the seaweed if not wisible anymore
        DestroyIfNotVisible();
    }

    /// <summary>
    /// Generates the points for the line and polygon and sets them.
    /// </summary>
    private void GeneratePoints()
    {
        //Array of positions on the line
        Vector2[] points = new Vector2[(int)Mathf.Ceil(baseLength)];
        //Set start
        int i = 0;
        //Set run until the length
        while (i < baseLength)
        {

            //Generate sin
            float sinX = Mathf.Sin(i + Time.time) / 2;

            //Generate vector for the line. Transform position has to be added, otherwise it is always in the middle
            Vector2 pos = new Vector2((flipUpsideDown ? sinX * -1 : sinX) + transform.position.x, (flipUpsideDown ? i * -1 : i) * 0.5F + transform.position.y);
            //Add the point to the line renderer
            lineRenderer.SetPosition(i, pos);
            //Add to the points array. Without transform posotion.
            points[i] = new Vector2((flipUpsideDown ? sinX * -1 : sinX), (flipUpsideDown ? i * -1 : i) * 0.5F);
            i++;
        }
        //Add points to the collider
        polygonCollider.SetPath(0, points);
    }

    /// <summary>
    /// Destroy this game object if it is not wisible anymore
    /// </summary>
    private void DestroyIfNotVisible()
    {
        //Get the bound of the screen
        Vector2 screenBound = Camera.main.ScreenToWorldPoint(Vector2.zero);
        if (transform.position.x < screenBound.x)
            Destroy(gameObject);
    }
}
