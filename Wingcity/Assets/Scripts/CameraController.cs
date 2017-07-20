using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject followTarget;
    private Vector3 targetPos;
    public float moveSpeed;

    public BoxCollider2D boundary;
    private Vector3 minBoundary;
    private Vector3 maxBoundary;
    private Camera theCamera;
    private float halfHeight;
    private float halfWidth;


	// Use this for initialization
	void Start () {

        minBoundary = boundary.bounds.min;
        maxBoundary = boundary.bounds.max;
        theCamera = GetComponent<Camera>();
        halfHeight = theCamera.orthographicSize;
        halfWidth = halfHeight * Screen.width / Screen.height;

		
	}
	
	// Update is called once per frame
	void Update () {
        targetPos = new Vector3(followTarget.transform.position.x, followTarget.transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPos, moveSpeed * Time.smoothDeltaTime);

        /*if(boundary == null)
        {
            boundary = FindObjectOfType<Bounds>().GetComponent<BoxCollider2D>();
            minBoundary = boundary.bounds.min;
            maxBoundary = boundary.bounds.max;
        }*/

        float clampedX = Mathf.Clamp(transform.position.x, minBoundary.x + halfWidth, maxBoundary.x - halfWidth);
        float clampedY = Mathf.Clamp(transform.position.y, minBoundary.y + halfHeight, maxBoundary.y - halfHeight);
        transform.position = new Vector3(clampedX, clampedY, transform.position.z);

    }

    public void SetBoundary(BoxCollider2D newBoundary)
    {
        boundary = newBoundary;
        minBoundary = boundary.bounds.min;
        maxBoundary = boundary.bounds.max;
    }
}
