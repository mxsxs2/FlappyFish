using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayBehaviour : MonoBehaviour {

    [SerializeField]
    //The scrolling speed of the game
    private float gameSpeed = 2f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
    //Return the game speed
    public float GetGameSpeed()
    {
        return gameSpeed;
    }
}
