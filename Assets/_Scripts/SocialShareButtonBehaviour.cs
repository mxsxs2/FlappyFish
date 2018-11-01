using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class SocialShareButtonBehaviour : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        Button btn = gameObject.GetComponent<Button>();
        //Calls the TaskOnClick/TaskWithParameters method when the button is clicked
        btn.onClick.AddListener(() =>
        {
            Share();
        });
    }

    public void Share()
    {

        Application.OpenURL("https://www.facebook.com/dialog/feed?" +
              "app_id=340151006738562" +
              "&display=popup&caption=Some Caption" +
              "&link=https://google.com" +
              "&redirect_uri=https://google.com");
    }
}
