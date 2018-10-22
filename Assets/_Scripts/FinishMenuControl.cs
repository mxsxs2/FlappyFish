using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishMenuControl : MonoBehaviour {


    [SerializeField]
    //Score text component
    private Text scoreTextComponent;

    /// <summary>
    /// Set the game score
    /// </summary>
    /// <param name="score"></param>
    public void SetGameScore(int score)
    {
        scoreTextComponent.text = "Your score is: " + score;
    }
}
