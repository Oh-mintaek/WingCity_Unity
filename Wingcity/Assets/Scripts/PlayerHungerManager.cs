using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHungerManager : MonoBehaviour {

    public int playerMaxHunger;
    public int playerCurrentHunger;

	// Use this for initialization
	void Start () {
        playerCurrentHunger = playerMaxHunger;
	}
	
	// Update is called once per frame
	void Update () {
		if(playerCurrentHunger <= 0)
        {
            gameObject.SetActive(false);

        }

	}

    public void HungerPlayer(int hungerToGive)
    {
        playerCurrentHunger -= hungerToGive;

    }

    /*public void SetMaxHunger()
    {
        playerCurrentHunger = playerMaxHunger;
    }*/
}
