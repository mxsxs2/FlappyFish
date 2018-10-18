using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Jumping : MonoBehaviour {
    [SerializeField]
    //The volocity of the jump
    private float velocity = 400f;
    //The current object
    private Rigidbody2D rb;
    
    void Start()
    {
        // Get the current object
        rb = GetComponent<Rigidbody2D>();
    }

	void FixedUpdate() {
        //Get space key
        if (Input.GetKeyDown(KeyCode.Space) || Input.touchCount == 1)
        {
            //Reset the velocity so the force is never adde more than once a.k.a the fish not going to go mad high on quick space press
            rb.velocity = Vector2.zero;
            //Add upwards force
            rb.AddForce(Vector2.up * velocity * Time.deltaTime, ForceMode2D.Impulse);
        }
    }
}
