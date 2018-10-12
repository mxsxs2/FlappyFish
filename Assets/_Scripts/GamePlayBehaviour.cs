using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayBehaviour : MonoBehaviour
{
    private const string SEAWEED_PARENT_NAME = "Seaweeds";

    [SerializeField]
    [Range(1, 10)]
    //The scrolling speed of the game between 1 and 10
    private int gameSpeed = 2;
    [SerializeField]
    //The spawnerparent game object
    private GameObject spawnerParent;
    [SerializeField]
    //the fish
    private GameObject fish;
    //Container of the seaweeds
    private GameObject seaweedParent;
    //Game score
    private int score = 0;
    
    
    //Game Play events
    public static int GameSpeedChanged;



    // Use this for initialization
    void Start()
    {
        //Check if there is a parent object
        seaweedParent = GameObject.Find(SEAWEED_PARENT_NAME);
        if (!seaweedParent)
        {
            //Create one if there was not
            seaweedParent = new GameObject(SEAWEED_PARENT_NAME);
        }
    }

    // Update is called once per frame
    void Update()
    {
  
    }

    //Return the game speed
    public float GetGameSpeed()
    {
        return gameSpeed;
    }

}
