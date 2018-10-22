using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeaweedSpawner : SpawnPointBehaviour
{

    private const string PARENT_NAME = "Seaweeds";
    private const string SPAWNER_PARENT = "SeaweedSpawners";
    [SerializeField]
    private bool flipSeaweeds = false;
    //Get the screen boundaries
    private Vector2 screenTop;
    private Vector2 screenBottom;

    // Use this for initialization
    void Start()
    {
        //Get the top of the screen
        screenTop = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        //Get the bottom of the screen
        screenBottom = Camera.main.ScreenToWorldPoint(Vector2.zero);

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
        //Flip the seaweed if needed
        Seaweed component= obj.GetComponent<Seaweed>();
        if (flipSeaweeds) component.flipUpsideDown = true;
        //Set size
        component.baseLength = (screenTop.y-screenBottom.y)-2 + (flipSeaweeds ? GetVerticalGap() * -1 : GetVerticalGap());
    }

    protected override void CreateSpawnerContainer()
    {
        //Check if there is a parent object
        spawnedContainer = GameObject.Find(PARENT_NAME);
        if (!spawnedContainer)
        {
            //Create one if there was not
            spawnedContainer = new GameObject(PARENT_NAME);
            spawnedContainer.transform.parent = GameObject.Find(SPAWNER_PARENT).transform;
        }
    }

    /// <summary>
    /// Gets the vertical gap from the parent and returns it
    /// </summary>
    /// <returns>Seaweed size</returns>
    private float GetVerticalGap()
    {
        //Get gap field from parent
        SeaweedSpawnPointsBehaviour behaviour = GameObject.Find(SPAWNER_PARENT).GetComponent<SeaweedSpawnPointsBehaviour>();
        return behaviour.GetRandomVerticalGap();
    }

}
