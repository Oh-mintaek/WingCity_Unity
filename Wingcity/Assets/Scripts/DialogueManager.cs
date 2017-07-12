using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {


    public GameObject dBox;
    public Text dText;
    //
    public PlayerController thePC;
    public QuestTrigger theQT;

    public bool dialogueActive;
    public string[] dialogueLines;
    public int currentLine;


	// Use this for initialization
	void Start () {

        //처음에 안나오게.
        
        dBox.SetActive(false);
        dialogueActive = false;

        //
        thePC = FindObjectOfType<PlayerController>();
        theQT = FindObjectOfType<QuestTrigger>();
	}
	
	// Update is called once per frame
	void Update () {
        if (dialogueActive && Input.GetKeyDown(KeyCode.Space))
        {
            //dBox.SetActive(false);
            //dialogueActive = false;
            currentLine++;
        }

        if (currentLine >= dialogueLines.Length)
        {
            dBox.SetActive(false);
            dialogueActive = false;

            currentLine = 0;
            //
            thePC.playerNowDialogue = false;
        }
        dText.text = dialogueLines[currentLine];

    }

   /* public void ShowBox(string dialogue)
    {
        dialogueActive = true;
        dBox.SetActive(true);
        dText.text = dialogue;
    }*/

    public void ShowDialogue()
    {
        //
        thePC.playerNowDialogue = true;
        
        dialogueActive = true;
        dBox.SetActive(true);

    }
    //
    public void QuestDialogue()
    {
        thePC.playerNowDialogue = true;
        dialogueActive = true;
        dBox.SetActive(true);
        theQT.startQuest = true;
        theQT.QuestStart();
        
    }

    public void ClearDialogue()
    {
        thePC.playerNowDialogue = true;
        dialogueActive = true;
        dBox.SetActive(true);
        theQT.endQuest = false;
        theQT.startQuest = false;
        theQT.QuestStart();
    }
}
