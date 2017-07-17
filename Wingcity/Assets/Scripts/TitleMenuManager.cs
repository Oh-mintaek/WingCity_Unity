using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleMenuManager : MonoBehaviour {

    public GameObject[] tBox;
    public int menuNumber;
    public SaveLoad theSL;

	// Use this for initialization
	void Start () {
        theSL = FindObjectOfType<SaveLoad>();

		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StartButton()
    {
        SceneManager.LoadScene("Map004");
    }

    public void LoadButton()
    {
        theSL.LoadData();
    }

    public void ExitButton()
    {

    }

}
