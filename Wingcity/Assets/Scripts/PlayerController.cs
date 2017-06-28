using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    //Animator 기능 사용.
    private Animator animator;

    //Rigidbody2D 기능 사용.
    private Rigidbody2D myRigidbody;
    
    //playerMoving을 boolean으로 사용해서 움직이고있나 멈춰있나를 판단. 이동애니메이션 사용.
    private bool playerMoving;
    private Vector2 lastMove;
    

    //입력방향 * movdSpeed * 시간을 곱해서 이동속도 결정.
    public float moveSpeed;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();

        
	}
	
	// Update is called once per frame
	void Update () {
        //기본적인 상태 = false;.

        playerMoving = false;

        //player가 움직일때 값을 입력받고 playerMoving을 true로 해줌.
        if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
        {

            transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.smoothDeltaTime, 0f, 0f));
           // myRigidbody.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.smoothDeltaTime, myRigidbody.velocity.y);
            playerMoving = true;
            lastMove = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);


        }
        if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
        {
            transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * moveSpeed * Time.smoothDeltaTime, 0f));
           // myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, Input.GetAxisRaw("Vertical") * moveSpeed * Time.smoothDeltaTime);
            playerMoving = true;
            lastMove = new Vector2(0f, Input.GetAxisRaw("Vertical"));
            
        }

       /* if (Input.GetAxisRaw("Horizontal") <= 0.5f && Input.GetAxisRaw("Horizontal") >= -0.5f)
        {
            myRigidbody.velocity = new Vector2(0, myRigidbody.velocity.y);
        }

        if (Input.GetAxisRaw("Vertical") <= 0.5f && Input.GetAxisRaw("Vertical") >= -0.5f)
        {
            myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, 0);
        }*/



        animator.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
        animator.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
        animator.SetBool("playerMoving", playerMoving);
        animator.SetFloat("lastMoveX", lastMove.x);
        animator.SetFloat("lastMoveY", lastMove.y);

        
    }
}
