using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Events;

public class ThrowEffects : MonoBehaviour {

    public UnityEvent TossActive = new UnityEvent();
    public UnityEvent TossInactive = new UnityEvent();

	void FixedUpdate ()
    {
        // if the object does not have a transform and it's velocity is greater than zero do stuffs!!
		if (!transform.parent && GetComponent<Rigidbody>().velocity != Vector3.zero)
        {
            TossActive.Invoke();
        }
        else
        {
            TossInactive.Invoke();
        }
	}
}
