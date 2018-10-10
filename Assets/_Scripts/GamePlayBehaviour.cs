using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayBehaviour : MonoBehaviour
{
    [SerializeField]
    [Range(1, 10)]
    //The scrolling speed of the game between 1 and 10
    private int gameSpeed = 2;
    //The spawnerparent game object
    [SerializeField]
    private GameObject spawnerParent;
    
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //Change the speed of the seaweed scrolling
        spawnerParent.GetComponent<SeaweedSpawnPointsBehaviour>().scrollSpeed = gameSpeed;
    }

    //Return the game speed
    public float GetGameSpeed()
    {
        return gameSpeed;
    }
}
