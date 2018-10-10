using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeaweedSpawner : MonoBehaviour
{

    private const string SPWAN_METHOD = "Spawn";
    private const string SEAWEED_PARENT_NAME = "Seaweeds";
    private const string SPAWNER_PARENT = "SeaweedSpawners";

    [SerializeField]
    private float spawnDelay = 0.5f;
    [SerializeField]
    private float spawnInterval = 1.3f;
    [SerializeField]
    private Seaweed seaweedPrefab;
    [SerializeField]
    private bool flipSeaweeds = false;
    [SerializeField]
    private float defaultSize = 8f;
    //Container for the seaweeds
    private GameObject seaweedParent;
    //The parent game object
    private GameObject spawnerParent;
    //Internal timer for spawning
    private float timer=0;
    // Use this for initialization
    void Start()
    {
        //Check if there is a parent object
        seaweedParent = GameObject.Find(SEAWEED_PARENT_NAME);
        if (!seaweedParent)
        {
            //Create one if there was not
            seaweedParent = new GameObject(SEAWEED_PARENT_NAME);
        }
        spawnerParent = GameObject.Find(SPAWNER_PARENT);

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
        var obj = Instantiate(seaweedPrefab, seaweedParent.transform);
        //Set the position to the parent
        obj.transform.position = transform.position;
        //Flip the seaweed if needed
        if (flipSeaweeds) obj.flipUpsideDown = true;
        //Set scrolling speed
        obj.GetComponent<Scrolling>().scrollingSpeed = GetNewScrollSpeed();
        //Set size
        obj.GetComponent<Seaweed>().baseLength = defaultSize+(flipSeaweeds ? GetVerticalGap() * -1 : GetVerticalGap());

        UpdateScrollSpeedOfSpawnedSeaweeds();
    }
    /// <summary>
    /// Updates every seaweeds's speed which are spawned by this spawner
    /// </summary>
    private void UpdateScrollSpeedOfSpawnedSeaweeds()
    {
        //Get all the spawned seaweeds
        Seaweed[] seaweeds = seaweedParent.GetComponentsInChildren<Seaweed>();
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
        //Get scrolling field from parent
        SeaweedSpawnPointsBehaviour behaviour = spawnerParent.GetComponent<SeaweedSpawnPointsBehaviour>();
        return behaviour.GetScrollSpeed();
    }

    /// <summary>
    /// Gets the vertical gap from the parent and returns it
    /// </summary>
    /// <returns>Seaweed size</returns>
    private float GetVerticalGap()
    {
        //Get gap field from parent
        SeaweedSpawnPointsBehaviour behaviour = spawnerParent.GetComponent<SeaweedSpawnPointsBehaviour>();
        return behaviour.GetRandomVerticalGap();
    }

    private float GetHorizontalGap()
    {
        //Get gap field from parent
        SeaweedSpawnPointsBehaviour behaviour = spawnerParent.GetComponent<SeaweedSpawnPointsBehaviour>();
        return behaviour.GetHorizontalGap();
    }
}
