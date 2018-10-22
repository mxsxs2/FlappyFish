using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartUpScript : MonoBehaviour {
    //The screen control script
    private ScreenControl screensControl;
    // Use this for initialization
    void Start()
    {
        //Get the screen control
        screensControl = GameObject.Find(ScreenControl.gameObjectName).GetComponent<ScreenControl>();

        //Check if the username is set. If not the show the panel and hide buttons panel
        if (PlayerPrefs.GetString("username").Equals(""))
        {
            //Enable main menu
            screensControl.EnableScreen(ScreenControl.SCREENS.UsernameMenu);
        }
        else
        {
            //Switch to username menu
            screensControl.EnableScreen(ScreenControl.SCREENS.MainMenu);
        }
    }
}
