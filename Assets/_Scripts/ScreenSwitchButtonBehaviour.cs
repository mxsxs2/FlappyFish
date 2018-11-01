using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenSwitchButtonBehaviour : MonoBehaviour {

    [SerializeField]
    //The screen wich should be enabled when the button is clicked
    private ScreenControl.SCREENS EnableScreenOnClick;
    //The screen control script
    private ScreenControl screensControl;
   
    // Use this for initialization
    void Start()
    {
        Init();
    }

    /// <summary>
    /// Initialize the class
    /// </summary>
    private void Init()
    {
        //Get the screen control
        screensControl = GameObject.Find(Const.screenGameObject).GetComponent<ScreenControl>();
        AddClickListener(EnableScreenOnClick);
    }

    /// <summary>
    /// Adds a click listener to the button component
    /// </summary>
    /// <param name="screen">Screen name</param>
    private void AddClickListener(ScreenControl.SCREENS screen)
    {
        //Get the button component of this game object
        Button btn = gameObject.GetComponent<Button>();
        //Calls the TaskOnClick/TaskWithParameters method when the button is clicked
        btn.onClick.AddListener(() =>
        {
            //Enable the desired screen
            screensControl.EnableScreen(screen);
        });
    }
}
