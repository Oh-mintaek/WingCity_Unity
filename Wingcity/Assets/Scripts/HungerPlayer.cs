using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HungerPlayer : MonoBehaviour {


    public int hungerToGive;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D other)
    {
       if(other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerHungerManager>().HungerPlayer(hungerToGive);

        } 
    }
}
