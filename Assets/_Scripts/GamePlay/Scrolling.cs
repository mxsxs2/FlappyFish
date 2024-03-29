﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Scrolling : MonoBehaviour
{

    [SerializeField]
    //Scrolling speed
    public float scrollingSpeed = 2f;
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
        rb.velocity = Vector2.left * scrollingSpeed;
    }

    private void OnEnable()
    {
        GamePlayBehaviour.GameSpeedChangeEvent += HandleFGameSpeedChange;
    }
    private void OnDisable()
    {
        GamePlayBehaviour.GameSpeedChangeEvent -= HandleFGameSpeedChange;
    }

    /// <summary>
    /// Handles game speed change
    /// </summary>
    /// <param name="e">Event type</param>
    private void HandleFGameSpeedChange(int speed)
    {
        scrollingSpeed=speed;
    }
}