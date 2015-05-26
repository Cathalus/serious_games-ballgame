using UnityEngine;
using System.Collections;

/// <summary>
/// Platform that emits Wind and applies force to the player
/// </summary>
public class Platform_Wind : MonoBehaviour {

    public float WindStrength = 5.0f;

	void OnTriggerStay(Collider other)
    {
        if(other.CompareTag(Tags.Player))
        {
            // Do Stuff
            Rigidbody playerBody = other.GetComponent<Rigidbody>();
            playerBody.AddForce(transform.up*WindStrength*10*Time.deltaTime, ForceMode.Force);
        }
    }

}
