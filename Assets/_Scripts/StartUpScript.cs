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
        //Enable main menu
        screensControl.EnableScreen(ScreenControl.SCREENS.MainMenu);
    }
}
