using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestSheepController : MonoBehaviour {

    private Vector3 moveDirection;
    private Animator animator;
    private Rigidbody2D myRigidbody;
    //
    //public PlayerController thePC;
    public GameObject player;
    public GameObject sheep;
    
    public float moveSpeed;
    public float timeIdle;
    private float timeIdleCounter;
    public float timeMove;
    private float timeMoveCounter;
    public Vector3 headingPlayer;
    

    private bool moving;
    
    
    // Use this for initialization
    void Start()
    {
        //
        //thePC = FindObjectOfType<PlayerController>();


        myRigidbody = GetComponent<Rigidbody2D>();

        //
        animator = GetComponent<Animator>();

        timeIdleCounter = Random.Range(timeIdle * 0.5f, timeIdle * 1.5f);

        timeMoveCounter = Random.Range(timeMove * 0.5f, timeMove * 1.5f);
        
    }

    // Update is called once per frame
    void Update()
    {
        headingPlayer = sheep.transform.position - player.transform.position;
        

       
        if (moving)
        {
            timeMoveCounter -= Time.smoothDeltaTime;
            myRigidbody.velocity = moveDirection;

            if (timeMoveCounter < 0f)
            {
                moving = false;
                timeIdleCounter = Random.Range(timeIdle * 0.5f, timeIdle * 1.5f);

            }
        }
        else
        {
            timeIdleCounter -= Time.smoothDeltaTime;
            myRigidbody.velocity = Vector2.zero;
            if (timeIdleCounter < 0f)
            {
                moving = true;
                timeMoveCounter = Random.Range(timeMove * 0.5f, timeMove * 1.5f);

                if(headingPlayer.sqrMagnitude > 1 && headingPlayer.sqrMagnitude < 10)
                {
                    //moveDirection = new Vector3(Random.Range(-1f, 1f) * moveSpeed, Random.Range(-1f, 1f) * moveSpeed, 0f);
                    moveDirection = headingPlayer * -1f;
                    Debug.Log("heading player");
                }
                else if(headingPlayer.sqrMagnitude <= 1)
                {
                    moveDirection = headingPlayer;
                    Debug.Log("so close");
                }
                else if(headingPlayer.sqrMagnitude >= 10)
                {
                    moveDirection = new Vector3(Random.Range(-1f, 1f) * moveSpeed, Random.Range(-1f, 1f) * moveSpeed, 0f);
                    Debug.Log("so far");
                }


            }
        }

        animator.SetFloat("MoveX", moveDirection.x);
        animator.SetFloat("MoveY", moveDirection.y);
        animator.SetBool("sheepMoving", moving);
        //animator.SetFloat("lastMoveX", );
        //animator.SetFloat("lastMoveY", );
    }
     
}
