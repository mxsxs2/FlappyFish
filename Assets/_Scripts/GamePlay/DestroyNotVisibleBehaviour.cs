using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyNotVisibleBehaviour : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        DestroyIfNotVisible();
    }
    /// <summary>
    /// Destroy this game object if it is not wisible anymore
    /// </summary>
    private void DestroyIfNotVisible()
    {
        //Get the bound of the screen
        Vector2 screenBound = Camera.main.ScreenToWorldPoint(Vector2.zero);
        if (transform.position.x < screenBound.x)
            Destroy(gameObject);
    }
}
