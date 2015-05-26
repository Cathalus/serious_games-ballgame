using UnityEngine;
using System.Collections;

/// <summary>
/// Resets the player to the Spawn Point if below a certain level
/// </summary>
public class DeathPlane : MonoBehaviour {

    /// <summary>
    /// The lowest point the player is allowed to be
    /// </summary>
    public float LowLevelBounds = 0;

    /// <summary>
    /// Reference to the Level's Spawn point
    /// </summary>
    private Transform _spawnPoint;

    void Awake()
    {
        _spawnPoint = GameObject.FindGameObjectWithTag(Tags.Respawn).GetComponent<Transform>();
    }

    void FixedUpdate()
    {
        // Check if Player is Below the Level bounds
        if(transform.position.y < LowLevelBounds)
        {
            // Respawn
            transform.position = _spawnPoint.position;
            transform.rotation = _spawnPoint.rotation;
        }
    }
	    
}
