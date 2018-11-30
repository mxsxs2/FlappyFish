using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishMenuControl : MonoBehaviour
{


    [SerializeField]
    //Score text component
    private Text scoreTextComponent;
    [SerializeField]
    //High score text component
    private Text highScoreTextComponent;

    /// <summary>
    /// Set the game score
    /// </summary>
    /// <param name="score"></param>
    public void SetGameScore(int score)
    {
        //Set the score text
        scoreTextComponent.text = Const.yourScoreText + score;
        //Check if new highscore
        if (score > getHighScore())
        {
            //Set new high score text
            highScoreTextComponent.text = Const.newHighScoreText;
        }
        else
        {
            //Remove the new high score text
            highScoreTextComponent.text = "";
        }
        //Set the high score
        setHighScore(score);
    }


    /// <summary>
    /// Returns the current highscore
    /// </summary>
    /// <returns></returns>
    private int getHighScore()
    {
        return PlayerPrefs.GetInt(Const.highScore);
    }
    /// <summary>
    /// Sets the highs score is the current score is higher
    /// </summary>
    /// <param name="score"></param>
    private void setHighScore(int score)
    {

        if (score > getHighScore()) PlayerPrefs.SetInt(Const.highScore, score);
    }
}
