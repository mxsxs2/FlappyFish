using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(InputField))]
public class UserNameInput : MonoBehaviour
{
    [SerializeField]
    //Length error message
    GameObject lengthErrorMessage;
    //Reference to the input field
    private InputField input;
    // Use this for initialization
    void Awake()
    {
        //Set the error massage to inactive
        lengthErrorMessage.SetActive(false);
        //Get input field
        input = gameObject.GetComponent<InputField>();
        //Set the username if there is any
        input.text = PlayerPrefs.GetString(Const.username);
        //Create a new submit event
        InputField.SubmitEvent se = new InputField.SubmitEvent();
        //Add listener
        se.AddListener((v) =>
        {
            //Check if the character is atleast 6 long
            if (v.Length > 6)
            {
                lengthErrorMessage.SetActive(false);
                //Update the username
                PlayerPrefs.SetString(Const.username, v);
            }
            else
            {
                lengthErrorMessage.SetActive(true);
            }
        });
        //Add event to button
        input.onEndEdit = se;

        // Sets the MyValidate method to invoke after the input field's default input validation invoke (default validation happens every time a character is entered into the text field.)
        input.onValidateInput += (input, charIndex, addedChar) => {
            return char.IsLetterOrDigit(addedChar)?addedChar: '\0';
        };
    }

    /// <summary>
    /// Update the input text when the input field is enabled again
    /// </summary>
    void OnEnable()
    {
        //Set the username if there is any
        input.text = PlayerPrefs.GetString(Const.username);
    }
}
