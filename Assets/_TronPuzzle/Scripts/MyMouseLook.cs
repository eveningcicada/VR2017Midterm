using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR;

public class MyMouseLook : MonoBehaviour {

	float scrollHeight;

	// Use this for initialization
	void Start ()
	{
		// VRSettings.renderViewportScale = // Changes the scale of the viewport

		if(VRDevice.isPresent)
		{
			Debug.Log("VR is enabled! Using " + VRDevice.model);
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(!VRDevice.isPresent)
		{
			// Run if VR is not working
			var myCam = Camera.main.transform;

			// Rotate camera based on mouse delta
			myCam.Rotate(-Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0f);

			// Unroll the Camera
			myCam.localEulerAngles = new Vector3(myCam.localEulerAngles.x, myCam.localEulerAngles.y, 0f);

			// Scroll Camera height
			scrollHeight += Input.GetAxis("Mouse ScrollWheel");
			scrollHeight = Mathf.Clamp(scrollHeight, 0f, 2f);

			myCam.transform.position = new Vector3(0f, scrollHeight, 0f);
		}	
	}
}
