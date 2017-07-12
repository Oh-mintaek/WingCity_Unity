using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PreferenceManager : MonoBehaviour {

    public Text PreferenceText;
    public int currentPreference;
    
	// Use this for initialization
	void Start () {
        PlayerPrefs.SetInt("CurrentPreference", 0);

        if (PlayerPrefs.HasKey("CurrentPreference"))
        {
            currentPreference = PlayerPrefs.GetInt("CurrentPreference");
        }
        else
        {
            currentPreference = 0;
            PlayerPrefs.SetInt("CurrentPreference", 0);
        }

        PreferenceText.text = "Preference : " + currentPreference;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AddPreference(int preferenceToAdd)
    {
        currentPreference += preferenceToAdd;
        PlayerPrefs.SetInt("CurrentPreference", currentPreference);
        PreferenceText.text = "Preference : " + currentPreference;
    }
}
