using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueQuest : MonoBehaviour {

    //public string dialogue;
    private DialogueManager dMAn;
    //
    private QuestTrigger theQT;
    private QuestManager theQM;

    public int questNumber;

    public string[] ingQuestdialogueLines;
    public string[] questDialogueLines;
    public string[] clearDialogueLines;

    // Use this for initialization
    void Start()
    {
        dMAn = FindObjectOfType<DialogueManager>();
        //
        theQT = FindObjectOfType<QuestTrigger>();
        theQM = FindObjectOfType<QuestManager>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.name == "newPlayer")
        {
            if (Input.GetKeyUp(KeyCode.Space))
            {
                //dMAn.ShowBox(dialogue);
                if (!dMAn.dialogueActive)
                {
                    //dMAn.dialogueLines = dialogueLines;
                    dMAn.currentLine = 0;
                    if (!theQT.startQuest)
                    {
                        //
                        dMAn.dialogueLines = questDialogueLines;
                        dMAn.QuestDialogue();
                        //
                        //theQT.startQuest = true;
                    }
                    else if(theQT.startQuest&&!theQT.endQuest)
                    {
                        dMAn.dialogueLines = ingQuestdialogueLines;
                        dMAn.ShowDialogue();
                    }
                    else if (theQT.endQuest)
                    {
                        dMAn.dialogueLines = clearDialogueLines;
                        dMAn.ClearDialogue();
                        theQM.questCompleted[questNumber] = true;

                    }
                }
                /*
                if (transform.parent.GetComponent<NPCController>() != null)
                {
                    transform.parent.GetComponent<NPCController>().canMove = false;
                }
                */
            }
        }
    }
}
