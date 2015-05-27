using UnityEngine;
using System.Collections;

/// <summary>
/// This platform attaches the player transform to the platform transform for smooth movement
/// </summary>
public class MovingPlatform : MonoBehaviour {

    private GameObject _player;
    private Transform _playerParent;

    void Awake()
    {
        _player = GameObject.FindGameObjectWithTag(Tags.Player);
        _playerParent = _player.transform.parent;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(Tags.Player))
        {
            _player.transform.parent = transform;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(Tags.Player))
        {
            _player.transform.parent = _playerParent;
        }
    }

}
