using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShepherdingQuest : MonoBehaviour {

    //private QuestTrigger theQT;
    //private QuestManager theQM;
    public QuestOnOffClear theQOOC;

    public int questNumber;
    public GameObject player;
    public GameObject[] sheeps;
    public Vector3[] sheepsDistance;
    public int sheepNumber;
    public float sum;
    

	// Use this for initialization
	void Start () {
        player = GameObject.Find("newPlayer");
        //theQT = FindObjectOfType<QuestTrigger>();
        //theQM = FindObjectOfType<QuestManager>();
        theQOOC = FindObjectOfType<QuestOnOffClear>();

        sheepsDistance = new Vector3[sheeps.Length];
	}
	
	// Update is called once per frame
	void Update () {

        sum = 0;

        for (int i = 0; i <= sheepNumber; i++)
        {
            sheepsDistance[i] = sheeps[i].transform.position - player.transform.position;
            sum += sheepsDistance[i].sqrMagnitude;

        }

        Shepherding();

	}

    void Shepherding()
    {
        if (sum <= 200 && theQOOC.startQuest[questNumber])
        {
            Debug.Log("Shephering success");
            theQOOC.endQuest[questNumber] = true;

            
            //theQM.quests[questNumber].gameObject.SetActive(false);
            //theQM.quests[questNumber].EndQuest();
        }
        else
        {

        }
    }
}
