using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SeaweedSpawnPointsBehaviour : MonoBehaviour {

    [SerializeField]
    //Gap between the seeweed where the fish will go through
    private float verticalGap = 5f;
    [SerializeField]
    [Range(1,10)]
    //The scrolling speed of seaweed
    public int scrollSpeed = 1;

    private Dictionary<int, float> horizontalGaps;
    //Counter for the used random number
    private int usageCounter = 0;
    private int previousRandom;
    //Random number exclusion
    private int[] exclude = { -1, 0, 1 };

	// Use this for initialization
	void Start () {
        //Map the speed to the gap. Tryed to keep kind of even.
        horizontalGaps = new Dictionary<int, float>
        {
            { 1, 4 },
            { 2, 2.8f },
            { 3, 2 },
            { 4, 1.7f },
            { 5, 1.4f },
            { 6, 1.1f },
            { 7, 0.9f },
            { 8, 0.8f },
            { 9, 0.7f },
            { 10, 0.6f }
        };

    }
	
	// Update is called once per frame
	void Update () {
        //If both spawner took the number. Generate a new one and reset cunter.
        if (usageCounter == 2)
        {
            GetRandom();
            usageCounter = 0;
        }
    }
    /// <summary>
    /// Returns a random number betwwen -4 and 4. 
    /// This number is never -1,0 or 1 also it never has the same sign one after the other.
    /// </summary>
    /// <returns></returns>
    private int GetRandom()
    {
        int random = 0;
        //Make sure it is not the same as previous and it is not in the exclusion array
        while(random == previousRandom || exclude.Contains(random)){
            //Generate number
            random = UnityEngine.Random.Range(-4, 4);
            //Makesure it does not have the same sign as previous
            if (previousRandom < 0 && random < 0 || previousRandom > 0 && random > 0) random = 0;
        }
        previousRandom = random;
        return random;
    }

    public float GetRandomVerticalGap()
    {
        usageCounter += 1;
        return previousRandom;
    }

    public float GetVerticalGap()
    {
        return verticalGap;
    }

    public float GetHorizontalGap()
    {
        return horizontalGaps[scrollSpeed];
    }

    public float GetScrollSpeed()
    {
        return scrollSpeed;
    }

    public void SetScrollSpeed(int speed)
    {
        
        scrollSpeed = speed;
    }
}
