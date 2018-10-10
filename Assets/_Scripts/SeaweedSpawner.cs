using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeaweedSpawner : MonoBehaviour {

    private const string SPWAN_METHOD = "Spawn";
    private const string SEAWEED_PARENT_NAME = "Seaweeds";

    [SerializeField]
    private float spawnDelay = 0.5f;
    [SerializeField]
    private float spawnInterval = 1.3f;
    [SerializeField]
    private Seaweed seaweedPrefab;
    [SerializeField]
    private float scrollStartSpeed = 2f;
    [SerializeField]
    private bool flipSeaweeds = false;

    private GameObject seaweedParent;
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
        //Start spawning
        SpawnRepeating();
    }

    private void SpawnRepeating()
    {
        //Invoke spawn method periodically
        InvokeRepeating(SPWAN_METHOD, spawnDelay, spawnInterval);
    }

    private void Spawn()
    {
        //Get a new seaweed instance
        var obj = Instantiate(seaweedPrefab, seaweedParent.transform);
        //Set the position to the parent
        obj.transform.position = transform.position;
        //Flip the seaweed if needed
        if (flipSeaweeds) obj.flipUpsideDown = true;
        //Set scrolling speed
        obj.GetComponent<Scrolling>().scrollingSpeed= scrollStartSpeed;
    }
}
