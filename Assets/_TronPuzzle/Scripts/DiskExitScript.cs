using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class DiskExitScript : MonoBehaviour {

	public Transform indicator;
	public Material glow;
	public Material keyHole;

    bool inHole = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (inHole == true) {
            this.transform.position = indicator.position;
            this.transform.rotation = indicator.rotation;
        }
	}

	void HandAttachedUpdate (Hand hand) {
		if (Vector3.Distance (this.transform.position, indicator.position) <= 0.1) {
			indicator.gameObject.GetComponent<MeshRenderer> ().material = glow;

			if (hand.GetStandardInteractionButton () == false) {
				hand.DetachObject (gameObject);

				this.transform.position = indicator.position;
				this.transform.rotation = indicator.rotation;

                inHole = true;
			}
		} else {
			indicator.gameObject.GetComponent<MeshRenderer> ().material = keyHole;
		}
	}
}
