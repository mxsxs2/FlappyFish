using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreLineBehaviour : MonoBehaviour {

    //Get the screen boundaries
    private Vector2 screenTop;
    private Vector2 screenBottom;

    // Use this for initialization
    void Start()
    {
        //Get the top of the screen
        screenTop = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        //Get the bottom of the screen
        screenBottom = Camera.main.ScreenToWorldPoint(Vector2.zero);
        //Initialize the collider and the line
        init();
    }

    private void init()
    {
        //Get the collider
        BoxCollider2D collider = gameObject.GetComponent<BoxCollider2D>();
        //Add points to the collider
        collider.size = new Vector2(0.1f, screenTop.y - screenBottom.y);
        //Set the horizontal position to 0
        gameObject.transform.position = new Vector2(gameObject.transform.position.x, 0);
    }
}
