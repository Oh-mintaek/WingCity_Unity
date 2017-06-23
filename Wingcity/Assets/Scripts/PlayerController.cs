using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private Animator animator;


    public float moveSpeed;
    public
	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetAxisRaw("Horizontal") > 0.3f || Input.GetAxisRaw("Horizontal") < -0.3f)
        {
            transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f));


        }
        if (Input.GetAxisRaw("Vertical") > 0.3f || Input.GetAxisRaw("Vertical") < -0.3f)
        {
            transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime, 0f));

        }

        animator.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
        animator.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));

    }
}
