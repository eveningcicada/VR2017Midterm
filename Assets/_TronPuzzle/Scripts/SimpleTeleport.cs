using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleTeleport : MonoBehaviour {

	Ray ray;
	RaycastHit groundCheck;

	public float length = 0f;

	SwitchEnvironment se;
	[SerializeField] GameObject player;

	void FixedUpdate () {
		ray = new Ray (this.transform.position, Vector3.down);

		if (Physics.Raycast (ray, out groundCheck, length) == true) {
			if (groundCheck.collider.tag == "Ground") {
				//Getting to here means that the disk is on the floor. Now check for input.
				if (SteamVR.active == false) {
					if (Input.GetKeyDown (KeyCode.Space)) {
						player.transform.position = this.transform.position;
					}
				} else {
					if (se.VRHand1.controller.GetPressDown (Valve.VR.EVRButtonId.k_EButton_Grip) ||
						se.VRHand2.controller.GetPressDown (Valve.VR.EVRButtonId.k_EButton_Grip)) {
						player.transform.position = this.transform.position;
					}
				}
			}
		}
		Debug.DrawRay (this.transform.position, Vector3.down * length);
	}

	// Use this for initialization
	void Start () {
		se = GameObject.Find ("GameManager").GetComponent<SwitchEnvironment> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
