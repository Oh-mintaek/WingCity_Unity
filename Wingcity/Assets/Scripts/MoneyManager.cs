using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MoneyManager : MonoBehaviour {

    public Text MoneyText;
    public int currentMoney;
    public int savedMoney;


	// Use this for initialization
	void Start () {
        //
        PlayerPrefs.SetInt("CurrentMoney", 0);

        if (PlayerPrefs.HasKey("CurrentMoney"))
        {
            currentMoney = PlayerPrefs.GetInt("CurrentMoney");
        }
        else
        {
            currentMoney = 0;
            PlayerPrefs.SetInt("CurrentMoney", 0);
        }

        MoneyText.text = "Money : " + currentMoney;


	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void AddMoney(int moneyToAdd)
    {
        currentMoney += moneyToAdd;
        PlayerPrefs.SetInt("CurrentMoney", currentMoney);
        MoneyText.text = "Money : " + currentMoney;

    }

    public void SavedMoney()
    {
        PlayerPrefs.SetInt("CurrentMoney", savedMoney);
        MoneyText.text = "Money : " + savedMoney;
    }
}
