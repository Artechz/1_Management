using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour {

	Vector3 lastFramePosition;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 currentFramePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition); //Only working in Ortographic Camera Mode, use Raycast for Perspective (3D) Camera.

		if (Input.GetMouseButton (1) || Input.GetMouseButton (2)) { //Right and Middle Mouse Button (checking if pressed/held down)

			Vector3 diff = lastFramePosition - currentFramePosition;
			Camera.main.transform.Translate (diff);
			
		}

		lastFramePosition = currentFramePosition;

	}
}