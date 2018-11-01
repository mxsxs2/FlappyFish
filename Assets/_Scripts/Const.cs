using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Const
{

    //Player preferences
    public static string highScore = "highscore";
    public static string sound = "sound";
    public static string username = "username";

    //GameObject Names
    public static string gamePlayGameObject = "GamePlay";
    public static string screenGameObject = "Screens";
    public static string seaweedParentName = "Seaweeds";
    public static string seaweedSpawnerGameObject = "SeaweedSpawners";
    public static string scoreLinesParentName = "ScoreLines";

    //Texts
    public static string scoreText = "Score: ";
    public static string yourScoreText = "Your score is: ";
    public static string newHighScoreText = "New High Score!";


    //Predefined horizontal gaps
    public static Dictionary<int, float> seaweedHorizonalGap= new Dictionary<int, float>
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
