using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreasePreference : MonoBehaviour {

    public int addPreference;

    public PreferenceManager thePM;
    public QuestManager theQM;
    public int questNumber;

	// Use this for initialization
	void Start () {
        thePM = FindObjectOfType<PreferenceManager>();
        theQM = FindObjectOfType<QuestManager>();

	}
	
	// Update is called once per frame
	void Update () {

        if (theQM.questCompleted[questNumber])
        {
            thePM.AddPreference(addPreference);
            theQM.questCompleted[questNumber] = false;

        }
        //theMM.AddMoney(MoneyValue);
        //gameObject.SetActive(false);
    }

    
}
