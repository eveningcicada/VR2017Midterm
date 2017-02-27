using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hover : MonoBehaviour {

    public float hoverForce;
    
    void OnTriggerStay (Collider other)
    {
        if(other.gameObject.name == "Disc")
        {
            other.GetComponent<Rigidbody>().AddForce(Vector3.up * hoverForce, ForceMode.Acceleration);
        }
    }
}
