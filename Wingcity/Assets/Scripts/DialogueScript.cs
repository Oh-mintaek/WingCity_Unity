using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueScript : MonoBehaviour {
    //public string dialogue;
    private DialogueManager theDM;
    public QuestOnOffClear theQOOC;

    public int questNumber;
    public string[] dialogueLines;
    public string[] questDialogueLines;
    public string[] ingQuestDialogueLines;
    public string[] clearDiaglogueLines;


    // Use this for initialization
    void Start()
    {

        //theDM = FindObjectOfType<DialogueManager>();
        //theQOOC = FindObjectOfType<QuestOnOffClear>();

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("dialogue script -ing");
    }

    private void OnTriggerStay2D(Collider2D other)
    {

        if (other.gameObject.name == "newPlayer")
        {
            theDM = FindObjectOfType<DialogueManager>();
            theQOOC = FindObjectOfType<QuestOnOffClear>();

            if (Input.GetKeyUp(KeyCode.Space))
            {
                
                if (!theDM.dialogueActive)
                {


                    if (!theQOOC.startQuest[questNumber]&&!theQOOC.triggerQuest[questNumber])
                    {
                        theDM.dialogueLines = dialogueLines;
                        theDM.currentLine = 0;
                        theDM.ShowDialogue();
                    }

                    else if (!theQOOC.startQuest[questNumber] && theQOOC.triggerQuest[questNumber])
                    {
                        theDM.dialogueLines = questDialogueLines;

                        theDM.currentLine = 0;
                        theDM.QuestDialogue();
                                                
                    }

                    else if (theQOOC.startQuest[questNumber]&&!theQOOC.endQuest[questNumber])
                    {
                        theDM.dialogueLines = ingQuestDialogueLines;
                        theDM.currentLine = 0;
                        theDM.IngQuestDialogue();
                    }

                    else if (theQOOC.startQuest[questNumber] && theQOOC.endQuest[questNumber])
                    {
                        theDM.dialogueLines = clearDiaglogueLines;
                        theDM.currentLine = 0;
                        theDM.ClearDialogue();
                    }

                }
                //NPC 멈추게 하는 함수
                if (transform.parent.GetComponent<NPCController>() != null)
                {
                    transform.parent.GetComponent<NPCController>().canMove = false;
                }

            }
        }
    }
}
