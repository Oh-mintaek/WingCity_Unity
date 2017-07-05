using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpNewArea : MonoBehaviour {

    public string levelToLoad;

    public string exitPoint;

    private PlayerController thePlayer;

	// Use this for initialization
	void Start () {
        thePlayer = FindObjectOfType<PlayerController>();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name == "newPlayer")
        {
            Application.LoadLevel(levelToLoad);
            thePlayer.startPoint = exitPoint;
        }
    }
}
