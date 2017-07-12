using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestTrigger : MonoBehaviour {

    private QuestManager theQM;
    

    public int questNumber;
    public bool startQuest;
    public bool endQuest;


	// Use this for initialization
	void Start () {
        theQM = FindObjectOfType<QuestManager>();

        //임의로 추가.
        //theQM.quests[questNumber].gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name == "newPlayer")
        {
            /*
            //Debug.Log("newPlayer In");
            if (!theQM.questCompleted[questNumber])
            {
                //Debug.Log("quest not completed");

               
                if(startQuest && !theQM.quests[questNumber].gameObject.activeSelf)
                {
                    //Debug.Log("quest start");

                    theQM.quests[questNumber].gameObject.SetActive(true);
                    theQM.quests[questNumber].StartQuest();

                }
                

                if(endQuest && theQM.quests[questNumber].gameObject.activeSelf)
                {
                    theQM.quests[questNumber].gameObject.SetActive(false);
                    theQM.quests[questNumber].EndQuest();

                }
                


            }*/

            //위의 식 대신 QuestStart() 클래스로 치환.
            QuestStart();


        }
    }

    //
    public void QuestStart()
    {
        if (!theQM.questCompleted[questNumber])
        {
            //Debug.Log("quest not completed");


            if (startQuest && !theQM.quests[questNumber].gameObject.activeSelf)
            {
                Debug.Log("quest start1");

                theQM.quests[questNumber].gameObject.SetActive(true);
                theQM.quests[questNumber].StartQuest();

            }
            

            if (endQuest && theQM.quests[questNumber].gameObject.activeSelf)
            {

                Debug.Log("quest start2");

                theQM.quests[questNumber].gameObject.SetActive(false);
                theQM.quests[questNumber].EndQuest();

            }
           



        }
    }

}
