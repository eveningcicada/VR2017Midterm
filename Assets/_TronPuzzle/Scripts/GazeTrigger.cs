using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GazeTrigger : MonoBehaviour {

	[SerializeField] float timeLookedAt = 0f;
	[SerializeField] Image reticule;
	[Space(10)]
	public UnityEvent OnGazeComplete = new UnityEvent();
	public UnityEvent OnGazeBroken = new UnityEvent();

	void Update ()
	{
		// is the camera looking / pointing at something?
	
		// get direction the user is looking
		Vector3 camLookDir = Camera.main.transform.forward;

		// direction from player to the target object (A to B = B-A)
		Vector3 vectorFromCamToTarget = transform.position - Camera.main.transform.position;

		// get the angle between our lookDir vs. the object's direction
		float angle = Vector3.Angle( camLookDir, vectorFromCamToTarget );

		// do stuff based on that angle
		if ( angle < 10f )
		{
			timeLookedAt =  Mathf.Clamp01(timeLookedAt + Time.deltaTime);

			if(timeLookedAt == 1)
			{
				timeLookedAt = 0;
				OnGazeComplete.Invoke();
			}
		}
		else
		{
			// decays progress if not being looked at
			timeLookedAt = Mathf.Clamp01(timeLookedAt - Time.deltaTime);

			if(timeLookedAt == 0)
			{
				OnGazeBroken.Invoke();			
			}
		}

		reticule.fillAmount = timeLookedAt;
	}
}
