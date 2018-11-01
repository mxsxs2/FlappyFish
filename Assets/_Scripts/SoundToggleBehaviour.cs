using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Toggle))]
public class SoundToggleBehaviour : MonoBehaviour {

    private Toggle toggle;

	// Use this for initialization
	void Awake () {
        //Get the toggle
        toggle = gameObject.GetComponent<Toggle>();
        //Add the event listener
        toggle.onValueChanged.AddListener((value)=>{
            //Set the new preference
            PlayerPrefs.SetInt(Const.sound, Convert.ToInt32(value));
            //Turn audio on or off
            AudioListener.pause = !value;
        });
	}

    /// <summary>
    /// Update the input text when the input field is enabled again
    /// </summary>
    void OnEnable()
    {
        //Set the username if there is any
        toggle.isOn = PlayerPrefs.GetInt(Const.sound) ==1;
    }
}
