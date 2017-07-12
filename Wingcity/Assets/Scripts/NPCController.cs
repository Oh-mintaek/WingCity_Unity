using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour {


    public float moveSpeed;
    private Rigidbody2D myRigidbody;
    private bool moving;

    public float timeIdle;
    private float timeIdleCounter;

    public float timeMove;
    private float timeMoveCounter;

    private Vector3 moveDirection;

    public bool canMove;
    private DialogueManager theDM;

    //
    //private Animator animator;

    // Use this for initialization
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        //
        //animator = GetComponent<Animator>();

        theDM = FindObjectOfType<DialogueManager>();


        timeIdleCounter = Random.Range(timeIdle * 0.5f, timeIdle * 1.5f);

        timeMoveCounter = Random.Range(timeMove * 0.5f, timeMove * 1.5f);

        canMove = true;

    }

    // Update is called once per frame
    void Update()
    {

        if (!theDM.dialogueActive)
        {
            canMove = true;
        }

        if (!canMove)
        {
            myRigidbody.velocity = Vector2.zero;
            return;

        }

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

                moveDirection = new Vector3(Random.Range(-1f, 1f) * moveSpeed, Random.Range(-1f, 1f) * moveSpeed, 0f);

            }
        }

        //animator.SetFloat("MoveX", moveDirection.x);
        //animator.SetFloat("MoveY", moveDirection.y);
        //animator.SetBool("sheepMoving", moving);
        //animator.SetFloat("lastMoveX", );
        //animator.SetFloat("lastMoveY", );

    }
}
