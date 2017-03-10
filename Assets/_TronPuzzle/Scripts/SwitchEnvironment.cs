using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Valve.VR.InteractionSystem;

public class SwitchEnvironment : MonoBehaviour {

	public Hand VRHand1;
	public Hand VRHand2;
	public Hand fallbackHand;

	public GameObject room1;
	public GameObject room2;

	// Use this for initialization
	void Start () {
		room1.SetActive (true);
		room2.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (VRHand1.gameObject.activeInHierarchy == true) {
			if (VRHand1.controller.GetPressDown (Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad)
				|| VRHand2.controller.GetPressDown (Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad)) {
				if (room1.activeInHierarchy == false) {
					room1.SetActive (true);
					room2.SetActive (false);
				} else {
					room1.SetActive (false);
					room2.SetActive (true);
				}
			}
		} else {
			if (fallbackHand.GetStandardInteractionButtonDown ()) {
				if (room1.activeInHierarchy == false) {
					room1.SetActive (true);
					room2.SetActive (false);
				} else {
					room1.SetActive (false);
					room2.SetActive (true);
				}
			}
		}
	}


}
