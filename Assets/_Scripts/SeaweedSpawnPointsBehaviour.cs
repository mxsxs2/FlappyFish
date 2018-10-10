using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeaweedSpawnPointsBehaviour : MonoBehaviour {

    [SerializeField]
    private float verticalGap = 5f;
    [SerializeField]
    private float horizontalGap = 5f;
    [SerializeField]
    private float scrollSpeed = 2f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public float GetScrollSpeed()
    {
        return scrollSpeed;
    }
}
