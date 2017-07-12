using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectMenu : MonoBehaviour {

    
    public MenuManager theMM;

	// Use this for initialization
	void Start () {

        theMM = FindObjectOfType<MenuManager>();

	}
	
	// Update is called once per frame
	void Update () {
		
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


}
