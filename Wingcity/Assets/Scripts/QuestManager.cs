﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour {


    public QuestObject[] quests;
    public DialogueManager theDM;

    public bool[] questCompleted;

    public string itemCollected;


    

	// Use this for initialization
	void Start () {
        
        //theDM = FindObjectOfType<DialogueManager>();
        questCompleted = new bool[quests.Length];

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ShowQuestText(string questText)
    {
        //theDM.dialogueLines.Clear();
        //theDM.dialogueLines.Add(questText);
        theDM.dialogueLines = new string[1];
        theDM.dialogueLines[0] = questText;

        theDM.currentLine = 0;
        
        theDM.ShowDialogue();
        
    }
}
