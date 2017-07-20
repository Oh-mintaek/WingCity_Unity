using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundary : MonoBehaviour {

    private BoxCollider2D boundary;
    private CameraController theCC;


	// Use this for initialization
	void Start () {
        boundary = GetComponent<BoxCollider2D>();
        theCC = FindObjectOfType<CameraController>();
        theCC.SetBoundary(boundary);
	}
	
	// Update is called once per frame
	
}
