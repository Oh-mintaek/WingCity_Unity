using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MenuManager : MonoBehaviour {

    public GameObject[] mBox;
    public Text[] dText;
    public int menuNumber;
    public bool[] menuActive;
    public int menuOnOff;

    protected bool paused;


	// Use this for initialization
	void Start () {
        for(int i = 0; i <= menuNumber; i++)
        {
            mBox[i].SetActive(false);           

        }
        menuOnOff = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if(menuOnOff !=2 && Input.GetKeyDown(KeyCode.Escape))
        {
            for (int i = 0; i <= menuNumber; i++)
            {                
                mBox[i].SetActive(true);                
            }

            menuOnOff++;
            Time.timeScale = 0;
        }

        if (menuOnOff == 2)
        {
            for (int i = 0; i <= menuNumber; i++)
            {
                mBox[i].SetActive(false);                
            }
            menuOnOff = 0;
            Time.timeScale = 1;
        }

	}
}
