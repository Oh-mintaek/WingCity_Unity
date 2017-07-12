using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MenuManager : MonoBehaviour {

    public GameObject[] mBox;
    //public Text[] dText;
    public int menuNumber;
    //public bool[] menuActive;
    public int menuOnOff;
    public GameObject[] iBox;
    public int itemMenuNumber;
    //public Text iText;


    protected bool paused;


	// Use this for initialization
	void Start () {
        for(int i = 0; i <= menuNumber; i++)
        {
            mBox[i].SetActive(false);           
            
        }
        for(int i = 0; i <= itemMenuNumber; i++)
        {
            iBox[i].SetActive(false);
        }
        menuOnOff = 0;
	}
	
	// Update is called once per frame
	void Update () {

        


        if (menuOnOff !=2 && Input.GetKeyUp(KeyCode.Escape))
        {

            for (int i = 0; i <= itemMenuNumber; i++)
            {
                iBox[i].SetActive(false);
            }

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

    public void ItemMenu()
    {
        for(int i=0; i<= itemMenuNumber; i++)
        {
            iBox[i].SetActive(true);
        }
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            for (int i = 0; i <= itemMenuNumber; i++)
            {
                iBox[i].SetActive(false);
            }
        }
    }


}
