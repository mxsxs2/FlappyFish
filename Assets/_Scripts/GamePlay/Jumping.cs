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
    //Whether to jump or not
    private bool jump;
    [SerializeField]
    //Jumping sound audio source
    public AudioSource jumpSound;
    
    void Start()
    {
        // Get the current object
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        //Get space key
        if (Input.GetKeyDown(KeyCode.Space) || Input.touchCount == 1)
        {
            jump = true;
            //Play the jump sound
            jumpSound.Play();

        }
        else
        {
            jump = false;
        }
    }

	void FixedUpdate() {
        //If should jump
        if (jump)
        {
            
            //Reset the velocity so the force is never adde more than once a.k.a the fish not going to go mad high on quick space press
            rb.velocity = Vector2.zero;
            //Add upwards force
            rb.AddForce(transform.up * velocity);
            jump = false;
        }
    }
}
