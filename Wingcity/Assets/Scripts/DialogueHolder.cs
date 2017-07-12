using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueHolder : MonoBehaviour {

    //public string dialogue;
    private DialogueManager dMAn;

    public string[] dialogueLines;


	// Use this for initialization
	void Start () {
        dMAn = FindObjectOfType<DialogueManager>();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.name == "newPlayer")
        {
            if (Input.GetKeyUp(KeyCode.Space))
            {
                //dMAn.ShowBox(dialogue);
                if (!dMAn.dialogueActive)
                {
                    dMAn.dialogueLines = dialogueLines;
                    dMAn.currentLine = 0;
                    dMAn.ShowDialogue();
                  
                }
                //NPC 멈추게 하는 함수
                /*if(transform.parent.GetComponent<NPCController>() != null)
                {
                    transform.parent.GetComponent<NPCController>().canMove = false;
                }*/
                
            }
        }
    }

}
