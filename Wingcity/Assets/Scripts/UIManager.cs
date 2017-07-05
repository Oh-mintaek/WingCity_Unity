using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public Slider hungerBar;
    public Text HungerText;
    public PlayerHungerManager playerHunger;

    private static bool UIExist;

	// Use this for initialization
	void Start () {
        if (!UIExist)
        {
            UIExist = true;
            DontDestroyOnLoad(transform.root.gameObject);
            
        }
        else
        {
            Destroy(gameObject);


        }
	}
	
	// Update is called once per frame
	void Update () {
        hungerBar.maxValue = playerHunger.playerMaxHunger;
        hungerBar.value = playerHunger.playerCurrentHunger;
        HungerText.text = "Hunger : " + playerHunger.playerCurrentHunger + "/" + playerHunger.playerMaxHunger;

	}
}
