﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyPickUp : MonoBehaviour {

    public int MoneyValue;

    public MoneyManager theMM;


	// Use this for initialization
	void Start () {
        theMM = FindObjectOfType<MoneyManager>();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name == "newPlayer")
        {
            theMM.AddMoney(MoneyValue);
            gameObject.SetActive(false);

        }
    }
}
