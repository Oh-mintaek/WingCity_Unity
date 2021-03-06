﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectMenu : MonoBehaviour {

    
    public MenuManager theMM;
    public SaveLoad theSL;


	// Use this for initialization
	void Start () {

        theMM = FindObjectOfType<MenuManager>();
        theSL = FindObjectOfType<SaveLoad>();


	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SaveButton()
    {
        theSL.SaveData();

    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene("MainMenu");
        
    }

    public void CancelButton()
    {
        
        for(int i=0;i<=theMM.menuNumber; i++)
        {
            theMM.mBox[i].SetActive(false);
        }     
        
    }


    public void ItemButton()
    {
        theMM.ItemMenu();
    }


    public void FoodButton()
    {
        for (int i = 0; i <= theMM.equipmentItemNumber; i++)
        {
            theMM.equipmentItem[i].SetActive(false);

        }

        theMM.FoodMenu();

    }


    public void EquipmentButton()
    {

        for (int i = 0; i <= theMM.foodItemNumber; i++)
        {
            theMM.foodItem[i].SetActive(false);

        }

        theMM.EquipmentMenu();
    }

}
