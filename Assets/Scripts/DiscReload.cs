using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class DiscReload : MonoBehaviour {

	private Hand _hand;
	private SteamVR_Camera _hmd;

    private Valve.VR.EVRButtonId triggerButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;

    public Throwable disc;
	

	// Use this for initialization
	void Start () {
		_hand = GetComponent<Hand>();
		_hmd = FindObjectOfType<SteamVR_Camera>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0) && Input.GetKey(KeyCode.Space)){
            ReloadDisc();
        }

        Debug.Log(_hand.controller);
        if(_hand.controller != null) {

            if (_hand.GetStandardInteractionButtonDown()){
                HandleTriggerClicked();
            }
        }

    }

	private void HandleTriggerClicked(){
		Vector3 hmdLookDir = _hmd.transform.forward;
		Vector3 hmdToHand = _hand.transform.position - _hmd.transform.position;

		float angle = Vector3.Angle (hmdLookDir, hmdToHand);

        Debug.Log(angle);

		if(angle > 115 && angle < 150){
            ReloadDisc();
		}

	}

	private void ReloadDisc(){
		_hand.AttachObject (disc.gameObject);
	}
}
