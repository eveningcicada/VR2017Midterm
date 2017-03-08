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
			Debug.Log ("hit");
			if (groundCheck.collider.tag == "Ground") {
				Debug.Log ("ground");
				if (Input.GetKeyDown(KeyCode.Space) ||
					se.VRHand1.controller.GetPressDown (Valve.VR.EVRButtonId.k_EButton_Grip) ||
					se.VRHand2.controller.GetPressDown (Valve.VR.EVRButtonId.k_EButton_Grip)) {

					Debug.Log ("teleport");
					player.transform.position = this.transform.position;
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
