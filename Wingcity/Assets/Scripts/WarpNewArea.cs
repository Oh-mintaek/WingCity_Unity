using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WarpNewArea : MonoBehaviour {

    public string levelToLoad;

    public string exitPoint;
    public GameObject player;
    public PlayerController thePlayer;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("newPlayer");

        thePlayer = FindObjectOfType<PlayerController>();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name == "newPlayer")
        {
            SceneManager.LoadScene(levelToLoad);
            thePlayer.startPoint = exitPoint;
        }
    }
}
