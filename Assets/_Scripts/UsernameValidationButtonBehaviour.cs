using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Button))]
public class UsernameValidationButtonBehaviour : MonoBehaviour
{

    [SerializeField]
    //Reference to the length error message
    Text lengthErrorMessage;
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
        screensControl = GameObject.Find(ScreenControl.gameObjectName).GetComponent<ScreenControl>();
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
            //If the error message is inactive
            if (!lengthErrorMessage.IsActive())
                //Enable the desired screen
                screensControl.EnableScreen(screen);
        });
    }
}
