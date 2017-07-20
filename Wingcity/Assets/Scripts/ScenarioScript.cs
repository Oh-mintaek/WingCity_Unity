using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenarioScript : MonoBehaviour {

    public ScenarioManager theSM;
    
    public string[] scenarioLines;
    

    // Use this for initialization
    void Start()
    {
        theSM = FindObjectOfType<ScenarioManager>();

        /*if (Input.GetKeyUp(KeyCode.Space))
        {

            if (!theSM.scenarioActive)
            {

                theSM.scenarioLines = scenarioLines;
                theSM.currentLine = 0;
                theSM.ShowScenario();

            }
        }*/

    }

    // Update is called once per frame
    void Update()
    {
        

        if (Input.GetKeyUp(KeyCode.Space))
        {

            if (!theSM.scenarioActive)
            {

                //theSM.scenarioLines = scenarioLines;
                theSM.currentLine = 0;
                //theSM.ShowScenario();

            }
        }
    }

}
