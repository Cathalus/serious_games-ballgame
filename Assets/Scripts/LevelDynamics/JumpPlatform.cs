using UnityEngine;
using System.Collections;

/// <summary>
/// Platform that launches the player into the air
/// </summary>
public class JumpPlatform : MonoBehaviour {

    /// <summary>
    /// Force of the Jump
    /// </summary>
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
