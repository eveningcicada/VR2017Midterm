using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtMe : MonoBehaviour {
	
	[SerializeField] ParticleSystem orb;

	RaycastHit lookRay;

	// Update is called once per frame
	void FixedUpdate ()
	{
		var particleEmitter = orb.emission;

		if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out lookRay, 5f) && lookRay.collider == GetComponent<Collider>())
		{
			particleEmitter.enabled = true;
		}
		else
		{
			particleEmitter.enabled = false;
		}
	}
}
