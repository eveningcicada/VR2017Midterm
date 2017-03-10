using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class FallDetect : MonoBehaviour {

	[SerializeField] GameObject player;
	[SerializeField] GameObject disk;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter (Collider other) {
		if (other.name == "BodyCollider") {
			SteamVR_Fade.Start (Color.black, 1f);
			player.transform.position = Vector3.zero;
			disk.transform.position = Vector3.zero;
		}
	}
}
