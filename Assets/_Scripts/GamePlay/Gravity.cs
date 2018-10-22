using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Gravity : MonoBehaviour
{
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
        //Make the object fall on every frame
        rb.velocity = Vector2.down * speed; 

    }
}
