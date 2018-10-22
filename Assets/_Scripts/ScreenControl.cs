using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenControl : MonoBehaviour {

    //The name of the game object this scrript should be attached to 
    public const string gameObjectName="Screens";

    //Type with the screen names
    public enum SCREENS
    {
        GamePlay,
        MainMenu,
        PauseMenu
    }

    //A dictionary of all availabe screenes
    private IDictionary<SCREENS, GameObject> allScreenes = new Dictionary<SCREENS, GameObject>();

    // Use this for initialization
    void Start () {
        //Init screen dictionary
        InitScreenDictionary();
	}
    /// <summary>
    /// initiializes the allScreens dictionary by filling it up from the SCREENS enum
    /// </summary>
    void InitScreenDictionary()
    {
        //Convert enum to array
        Array a = Enum.GetValues(typeof(SCREENS));
        //Loop enums
        foreach (SCREENS s in a)
        {
            //Add a gameobject reference to the dictionary
            allScreenes.Add(s, GameObject.Find(s.ToString("g")));
        }
    }

    /// <summary>
    /// Enables a given screen and disable all others
    /// </summary>
    /// <param name="screen">Screen enum</param>
    public void EnableScreen(SCREENS screen)
    {
        //Loop the screenes
        foreach(KeyValuePair<SCREENS, GameObject> e in allScreenes)
        {
            if (e.Key == screen)
            {
                e.Value.SetActive(true);
            }
            else
            {
                e.Value.SetActive(false);
            }
        }
    }

    /// <summary>
    /// Returns the game object for a given screen
    /// </summary>
    /// <param name="screen">Screen enum</param>
    /// <returns></returns>
    public GameObject GetScreen(SCREENS screen)
    {
        return allScreenes[screen];
    }
}
