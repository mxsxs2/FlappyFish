﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class FishBehaviour : MonoBehaviour {
    public enum FishCollisionEvents
    {
        FISHHIT,
        SCOREHIT
    }

    //Get the screen boundaries
    private Vector2 screenTop;
    private Vector2 ScreenBottom;
    //The current object
    private Rigidbody2D rb;
    //The original gravity of the fish
    private float originalGvaity;
    //Offset of fish
    private float fishOffset;
    //FishCollisionEvent handlers
    public delegate void FishCollision(FishCollisionEvents e);
    //Fish collision event
    public static FishCollision FishCollisionEvent;
    //The original position of the fish
    public Vector2 originalPosition;

    void Start () {
        //Save the original position
        originalPosition = transform.position;
        // Get the current object
        rb = GetComponent<Rigidbody2D>();
        //Get the original gravity
        originalGvaity = rb.gravityScale;
        //Get the top of the screen
        screenTop = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        //Get the bottom of the screen
        ScreenBottom = Camera.main.ScreenToWorldPoint(Vector2.zero);
        //Get the renderer of the fish
        Renderer rend = GetComponent<Renderer>();
        fishOffset = rend.bounds.size.y / 2;

    }
	
	void FixedUpdate () {
        //Get current position
        Vector3 pos = transform.position;
        //Check if the fish is within boundaries and act on if not
        CheckBottomBoundary(pos);
        CheckTopBoundary(pos);
    }

    void CheckTopBoundary(Vector3 pos)
    {
        //Check if the fish is jumping out
        if (pos.y > screenTop.y- fishOffset)
        {
            //Kill the upward foce
            rb.velocity = Vector2.zero;
            //Dont let the fish go out of the sceen
            transform.position = new Vector2(transform.position.x, screenTop.y- fishOffset);
            //Turn jumping off
            var jumping = GetComponent<Jumping>();
            jumping.enabled = false;
        }
        else
        {
            //Turn on jumping
            var jumping = GetComponent<Jumping>();
            jumping.enabled = true;
        }
    }

    void CheckBottomBoundary(Vector3 pos)
    {
        //Check if the fish is fallen out
        if (pos.y <= ScreenBottom.y + fishOffset)
        {
            //The fish dies when touching the bottom
            PublishFishCollisionEvent(FishCollisionEvents.FISHHIT);
            //Reset fish back to the middle
            transform.position = new Vector2(transform.position.x, 0);
            //Turn of gravity
            rb.gravityScale = 0f;
            
        }
        else
        {
            //Turn gravity on
            rb.gravityScale = originalGvaity;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // need to determin the type of "collision"
        var seaweed = collision.GetComponent<Seaweed>();
        if (seaweed)
        {
            PublishFishCollisionEvent(FishCollisionEvents.FISHHIT);
            //The fish dies when the fish is hit so the original position can set 
            transform.position = originalPosition;
            return;
        }
        var score = collision.GetComponent<ScoreLineBehaviour>();
        if (score)
        {
            PublishFishCollisionEvent(FishCollisionEvents.SCOREHIT);
        }
    }

    private void PublishFishCollisionEvent(FishCollisionEvents e)
    {
        if (FishCollisionEvent != null)
        {
            FishCollisionEvent(e);
        }

    }


}
