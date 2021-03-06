﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestObject : MonoBehaviour {

    public int questNumber;

    public QuestManager theQM;

    public string startText;
    public string endText;


    public bool isItemQuest;
    public string targetItem;
    

	// Use this for initialization
	void Start () {
        
        //theQM = FindObjectOfType<QuestManager>();

	}
	
	// Update is called once per frame
	void Update () {
        //아이템을 모아야 하는 퀘스트일 경우.
        if (isItemQuest)
        {
            if(theQM.itemCollected == targetItem)
            {
                theQM.itemCollected = null;
                
                EndQuest();
            }
        }


	}

    public void StartQuest()
    {
        theQM.ShowQuestText(startText);
    }

    public void EndQuest()
    {
        theQM.ShowQuestText(endText);

        theQM.questCompleted[questNumber] = true;

        gameObject.SetActive(false);

    }
}
