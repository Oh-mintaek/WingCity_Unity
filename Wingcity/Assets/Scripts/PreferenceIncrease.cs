using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreferenceIncrease : MonoBehaviour {

    public int addPreference;

    public PreferenceManager thePM;
   
    public QuestOnOffClear theQOOC;

    public int questNumber;

    // Use this for initialization
    void Start()
    {
        thePM = FindObjectOfType<PreferenceManager>();
        
        theQOOC = FindObjectOfType<QuestOnOffClear>();

    }

    // Update is called once per frame
    void Update()
    {

        Debug.Log("preference -ing");
        if (theQOOC.clearQuest[questNumber])
        {
            Debug.Log("clearQuest");
            thePM.AddPreference(addPreference);
            theQOOC.clearQuest[questNumber] = false;
        }     
        
    }
}
