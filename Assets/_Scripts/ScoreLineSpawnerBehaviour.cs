using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreLineSpawnerBehaviour : MonoBehaviour {

    private const string SPWAN_METHOD = "Spawn";
    private const string PARENT_NAME = "ScoreLines";

    [SerializeField]
    private ScoreLineBehaviour scoreLinePrefab;
    //Container for the lines
    private GameObject scoreLineParent;
    //Internal timer for spawning
    private float timer = 0;
    // Use this for initialization
    void Start()
    {
        //Check if there is a parent object
        scoreLineParent = GameObject.Find(PARENT_NAME);
        if (!scoreLineParent)
        {
            //Create one if there was not
            scoreLineParent = new GameObject(PARENT_NAME);
        }

        //Start spawning
        SpawnRepeating();
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            timer = GetHorizontalGap();
            Spawn();
        }
    }

    /// <summary>
    /// Keep repeating the spawn method
    /// </summary>
    private void SpawnRepeating()
    {
        //Invoke spawn method periodically
        //InvokeRepeating(SPWAN_METHOD, spawnDelay, GetHorizontalGap());
    }

    /// <summary>
    /// Spawns a new seaweed
    /// </summary>
    private void Spawn()
    {
        //Get a new seaweed instance
        var obj = Instantiate(scoreLinePrefab, gameObject.transform);
        //Set the position to the parent
        obj.transform.position = transform.position;
        //Set scrolling speed
        obj.GetComponent<Scrolling>().scrollingSpeed = GetNewScrollSpeed();

        UpdateScrollSpeed();
    }
    /// <summary>
    /// Updates every seaweeds's speed which are spawned by this spawner
    /// </summary>
    private void UpdateScrollSpeed()
    {
        //Get all the spawned seaweeds
        Scrolling[] seaweeds = scoreLineParent.GetComponentsInChildren<Scrolling>();
        //Loop the seaweeds
        for (int i = 0; i < seaweeds.Length; i++)
        {
            //Set the new speed to it
            seaweeds[i].GetComponent<Scrolling>().scrollingSpeed = GetNewScrollSpeed();
        }
    }

    /// <summary>
    /// Gets the scrolling speed from the parent and returns it
    /// </summary>
    /// <returns>Scroll speed</returns>
    private float GetNewScrollSpeed()
    {
        //Get game speed
        GamePlayBehaviour behaviour = GameObject.Find("GamePlay").GetComponent<GamePlayBehaviour>();
        return behaviour.GetGameSpeed();
    }

    private float GetHorizontalGap()
    {
        //Get gap field from parent
        GamePlayBehaviour behaviour = GameObject.Find("GamePlay").GetComponent<GamePlayBehaviour>();
        return behaviour.GetHorizontalGap();
    }
}
