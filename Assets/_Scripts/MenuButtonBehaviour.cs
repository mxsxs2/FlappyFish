using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuButtonBehaviour : MonoBehaviour {

    GameObject gamePlay;
    GameObject mainMenu;
    // Use this for initialization
    void Start()
    {
        gamePlay = GameObject.Find("GamePlay");
        mainMenu = GameObject.Find("MainMenu");
        Button btn = gameObject.GetComponent<Button>();

        //Calls the TaskOnClick/TaskWithParameters method when you click the Button
        btn.onClick.AddListener(() => {
            gamePlay.SetActive(false);
            mainMenu.SetActive(true);
        });
    }

    // Update is called once per frame
    void Update () {
		
	}
}
