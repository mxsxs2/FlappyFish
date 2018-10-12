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
    //Game score
    private int gameScore = 0;
    //Hoizontal gap between spawning
    private Dictionary<int, float> horizontalGaps;

    //GameSpeedChangeEvent handlers
    public delegate void GameSpeedChange(int speed);
    //GameSpeedChange event collision event
    public static GameSpeedChange GameSpeedChangeEvent;

    void Awake()
    {
        //Map the speed to the gap. Tryed to keep kind of even.
        horizontalGaps = new Dictionary<int, float>
        {
            { 1, 4 },
            { 2, 2.8f },
            { 3, 2 },
            { 4, 1.7f },
            { 5, 1.4f },
            { 6, 1.1f },
            { 7, 0.9f },
            { 8, 0.8f },
            { 9, 0.7f },
            { 10, 0.6f }
        };
    }

    // Use this for initialization
    void Start()
    {

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


    private void OnEnable()
    {
        FishBehaviour.FishCollisionEvent += HandleFishCollision;
    }
    private void OnDisable()
    {
        FishBehaviour.FishCollisionEvent -= HandleFishCollision;
    }

    /// <summary>
    /// Handles the fish collision events
    /// </summary>
    /// <param name="e">Event type</param>
    private void HandleFishCollision(FishBehaviour.FishCollisionEvents e)
    {
        //Check if its a score hit
        if (e == FishBehaviour.FishCollisionEvents.SCOREHIT)
        {
            //Increase score
            gameScore += 1;
            Debug.Log("Score: " + gameScore);
            //Check if score can should be increased
            if(gameScore%10==0 && gameSpeed < 11)
            {
                //Increase the speed
                gameSpeed += 1;
                PublishGameSpeedChange();
            }
        }
    }

    public float GetHorizontalGap()
    {
        return horizontalGaps[gameSpeed];
    }

    private void PublishGameSpeedChange()
    {
        if (GameSpeedChangeEvent != null)
        {
            GameSpeedChangeEvent(gameSpeed);
        }

    }

}
