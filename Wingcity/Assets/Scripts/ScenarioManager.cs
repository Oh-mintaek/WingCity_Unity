using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScenarioManager : MonoBehaviour {

    public GameObject sBox;
    public Text sText;
    
    //public ScenarioScript theSS;


    public bool scenarioActive;
    public string[] scenarioLines;
    public int currentLine;


    // Use this for initialization
    void Start()
    {
        
        //theSS = FindObjectOfType<ScenarioScript>();
        sBox.SetActive(true);
        scenarioActive = true;
        currentLine = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (scenarioActive && Input.GetKeyDown(KeyCode.Space))
        {
            currentLine++;
        }

        if (currentLine >= scenarioLines.Length)
        {
            sBox.SetActive(false);
            scenarioActive = false;

            currentLine = 0;
            SceneManager.LoadScene("Map004-1");
            
        }
        sText.text = scenarioLines[currentLine];

    }

    

    /*public void ShowScenario()
    {
        //
        //scenarioLines = theSS.scenarioLines;
        
        scenarioActive = true;
        sBox.SetActive(true);

    }*/
}
