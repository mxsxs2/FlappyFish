using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartButtonBehaviour : MonoBehaviour {

    GameObject gamePlay;
    GameObject mainMenu;
    // Use this for initialization
    void Start () {
        gamePlay = GameObject.Find("GamePlay");
        mainMenu = GameObject.Find("MainMenu");
        gamePlay.SetActive(false);
        Button btn = gameObject.GetComponent<Button>();

        //Calls the TaskOnClick/TaskWithParameters method when you click the Button
        btn.onClick.AddListener(()=>{
            gamePlay.SetActive(true);
            mainMenu.SetActive(false);
        });
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
