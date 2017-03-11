using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class discBalancer : MonoBehaviour {

    public float torqueAmount = 50f;
    public bool canRotate;
    float rotationX = 0f;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void FixedUpdate () {

//      float h = torqueAmount * Time.deltaTime;
        float v = torqueAmount * Time.deltaTime;
        
        if (canRotate)
        {
            GetComponent<Rigidbody>().AddTorque(transform.up * v);
        }

        Ray ray = new Ray(transform.position, Vector3.down);
        RaycastHit rayHitInfo = new RaycastHit();

        if (Physics.Raycast(ray, out rayHitInfo, 5f))
        {
            canRotate = false; 
        }
        else
        {
            canRotate = true;
        }

        rotationX = transform.rotation.x;
        rotationX = Mathf.Clamp(rotationX, -40f, 40f);

    }
}
