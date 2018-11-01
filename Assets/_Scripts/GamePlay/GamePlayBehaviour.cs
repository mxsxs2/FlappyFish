using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayBehaviour : MonoBehaviour
{
    [SerializeField]
    [Range(1, 10)]
    //The scrolling speed of the game between 1 and 10
    private int gameSpeed = 2;
    //The original game speed
    private int originalGameSpeed;
    [SerializeField]
    //The spawnerparent game object
    private GameObject spawnerParent;
    [SerializeField]
    //Game score
    private int gameScore = 0;
    [SerializeField]
    //Score text
    private Text scoreTextField;
    //GameSpeedChangeEvent handlers
    public delegate void GameSpeedChange(int speed);
    //GameSpeedChange event collision event
    public static GameSpeedChange GameSpeedChangeEvent;
    //ResetGameEvent handlers
    public delegate void ResetGame();
    //GameSpeedChange event collision event
    public static ResetGame ResetGameEvent;

    // Use this for initialization
    void Start()
    {
        //Set the original game speed
        originalGameSpeed = gameSpeed;
    }

    //Return the game speed
    public float GetGameSpeed()
    {
        return gameSpeed;
    }

    //Set the game score
    private void SetGameScore(int score)
    {
        //Set the score
        gameScore = score;
        //Add score to score text
        scoreTextField.text = Const.scoreText + gameScore;
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
            //Set the game score
            SetGameScore(gameScore + 1);
            //Check if score can should be increased
            if(gameScore%10==0 && gameSpeed < 11)
            {
                //Increase the speed
                gameSpeed += 1;
                PublishGameSpeedChange();
            }
        }else if(e== FishBehaviour.FishCollisionEvents.FISHHIT) {
            //Get the screen control
            ScreenControl screenControl=GameObject.Find(Const.screenGameObject).GetComponent<ScreenControl>();
            //Set the score for the finish menu
            screenControl.GetScreen(ScreenControl.SCREENS.FinishMenu).GetComponent<FinishMenuControl>().SetGameScore(gameScore);
            //Reset the game play
            ResetGamePlay();
            //Enable the finish menu screen
            screenControl.EnableScreen(ScreenControl.SCREENS.FinishMenu);
            
        }
    }

    /// <summary>
    /// Returns the gap between two items
    /// </summary>
    /// <returns></returns>
    public float GetHorizontalGap()
    {
        return Const.seaweedHorizonalGap[gameSpeed];
    }

    /// <summary>
    /// Publishes the game speed change event
    /// </summary>
    private void PublishGameSpeedChange()
    {
        if (GameSpeedChangeEvent != null)
        {
            GameSpeedChangeEvent(gameSpeed);
        }

    }

    /// <summary>
    /// Publishes the reset game event
    /// </summary>
    private void PublishResetGame()
    {
        if (ResetGameEvent != null)
        {
            ResetGameEvent();
        }

    }

    /// <summary>
    /// Resets the game play
    /// </summary>
    public void ResetGamePlay()
    {
        gameSpeed = originalGameSpeed;
        SetGameScore(0);
        PublishGameSpeedChange();
        PublishResetGame();
    }

}
