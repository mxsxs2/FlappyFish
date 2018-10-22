using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpawnPointBehaviour : MonoBehaviour {

    [SerializeField]
    protected GameObject spawnablePrefab;
    //Container for the seaweeds
    protected GameObject spawnedContainer;
    //Internal timer for spawning
    private float timer = 0;
 
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
    /// Spawns a new seaweed
    /// </summary>
    protected abstract void Spawn();

    /// <summary>
    /// Creates the parent container for the spawned items
    /// </summary>
    protected abstract void CreateSpawnerContainer();

    /// <summary>
    /// Gets the scrolling speed from the parent and returns it
    /// </summary>
    /// <returns>Scroll speed</returns>
    protected float GetNewScrollSpeed()
    {
        //Get game speed
        GamePlayBehaviour behaviour = GameObject.Find("GamePlay").GetComponent<GamePlayBehaviour>();
        return behaviour.GetGameSpeed();
    }

    protected float GetHorizontalGap()
    {
        //Get gap field from parent
        GamePlayBehaviour behaviour = GameObject.Find("GamePlay").GetComponent<GamePlayBehaviour>();
        return behaviour.GetHorizontalGap();
    }
}
