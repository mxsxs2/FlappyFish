using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Scrolling : MonoBehaviour {

    [SerializeField]
    //Falling speed
    public float speed = 2f;
    //The object that falls    
    private Rigidbody2D rb;
    void Start()
    {
        //Get the falling object
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        //Make the object go left on every frame
        rb.velocity = Vector2.left * speed;

    }
}
