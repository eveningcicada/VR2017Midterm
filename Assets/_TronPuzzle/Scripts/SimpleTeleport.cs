using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleTeleport : MonoBehaviour {

	Ray ray;
	RaycastHit groundCheck;
    Rigidbody myRB;


    public float length = 0f;

	SwitchEnvironment se;
	[SerializeField] GameObject player;

    void Start() {
        se = GameObject.Find("GameManager").GetComponent<SwitchEnvironment>();
        myRB = GetComponent<Rigidbody>();
    }

    void FixedUpdate () {
        ray = new Ray (this.transform.position, Vector3.down);

		if (Physics.Raycast (ray, out groundCheck, length) == true) {

            myRB.constraints = RigidbodyConstraints.None;

			if (groundCheck.collider.tag == "Ground") {
				//Getting to here means that the disk is on the floor. Now check for input.
				if (SteamVR.active == false) {
					if (Input.GetKeyDown (KeyCode.Space)) {
						player.transform.position = this.transform.position;
					}
				} else {
					if (se.VRHand1.controller.GetPressDown (Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger) ||
						se.VRHand2.controller.GetPressDown (Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger)) {
						player.transform.position = this.transform.position;
					}
				}
			}
		}
        else {
            myRB.constraints = RigidbodyConstraints.FreezeRotationX;
            myRB.constraints = RigidbodyConstraints.FreezeRotationZ;
        }

        Debug.DrawRay (this.transform.position, Vector3.down * length);
	}
}
