using UnityEngine;
using System.Collections;

public class JumpPlatform : MonoBehaviour {

    public float JumpForce = 15;

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(Tags.Player))
        {
            Rigidbody playerRigidbody = other.GetComponent<Rigidbody>();
            playerRigidbody.AddForce(Vector3.up*JumpForce, ForceMode.Impulse);
        }
    }

}
