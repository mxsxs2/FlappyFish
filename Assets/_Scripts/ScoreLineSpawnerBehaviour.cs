using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreLineSpawnerBehaviour : SpawnPointBehaviour{

    private const string PARENT_NAME = "ScoreLines";
  
    // Use this for initialization
    void Start()
    {
        CreateSpawnerContainer();
    }

    /// <summary>
    /// Spawns a new seaweed
    /// </summary>
    protected override void Spawn()
    {
        //Get a new seaweed instance
        var obj = Instantiate(spawnablePrefab, spawnedContainer.transform);
        //Set the position to the parent
        obj.transform.position = transform.position;
        //Set scrolling speed
        obj.GetComponent<Scrolling>().scrollingSpeed = GetNewScrollSpeed();
    }

    protected override void CreateSpawnerContainer()
    {
        //Check if there is a parent object
        spawnedContainer = GameObject.Find(PARENT_NAME);
        if (!spawnedContainer)
        {
            //Create one if there was not
            spawnedContainer = new GameObject(PARENT_NAME);
        }
    }
}
