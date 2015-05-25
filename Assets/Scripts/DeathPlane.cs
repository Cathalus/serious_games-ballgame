using UnityEngine;
using System.Collections;

public class DeathPlane : MonoBehaviour {

    private Transform _spawnPoint;

    void Awake()
    {
        _spawnPoint = GameObject.FindGameObjectWithTag(Tags.Respawn).GetComponent<Transform>();
    }

    void Update()
    {
        if(transform.position.y < 0)
        {
            // Respawn
            transform.position = _spawnPoint.position;
            transform.rotation = _spawnPoint.rotation;
        }
    }
	    
}
