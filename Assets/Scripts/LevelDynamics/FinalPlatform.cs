using UnityEngine;
using System.Collections;

/// <summary>
/// Platform that acts as the exit of the level.
/// Allows the player to advance to the next level when all keys were collected.
/// </summary>
public class FinalPlatform : MonoBehaviour {

    /// <summary>
    /// Material when the level isn't finished yet
    /// </summary>
    public Material NotFinishedMaterial;
    /// <summary>
    /// Material when the level is finished
    /// </summary>
    public Material FinishedMaterial;
    /// <summary>
    /// Time to wait until the next level starts
    /// </summary>
    public float TimeToNextLevel = 5;

    /// <summary>
    /// Reference to the CollectableItems Script
    /// </summary>
    private CollectableItems _itemScript;
    /// <summary>
    /// Reference to the LevelController
    /// </summary>
    private LevelController _levelController;
    /// <summary>
    /// Stores the status of the level
    /// </summary>
    private bool _finished = false;
    /// <summary>
    /// End of level wait Timer
    /// </summary>
    private float _timer;
    /// <summary>
    /// Reference to player's Rigidbody
    /// </summary>
    private Rigidbody _playerBody;

    void Awake()
    {
        _itemScript = GameObject.FindGameObjectWithTag(Tags.GameController).GetComponent<CollectableItems>();
        _levelController = GameObject.FindGameObjectWithTag(Tags.GameController).GetComponent<LevelController>();
        GetComponent<Renderer>().material = NotFinishedMaterial;
    }

    void Update()
    {
        if (_itemScript.RequiredKeysCollected())
        {
            GetComponent<Renderer>().material = FinishedMaterial;
        }

        if(_finished)
        {
            _timer += Time.deltaTime;
            if(_timer >= TimeToNextLevel)
            {
                _playerBody.AddForce(Vector3.up*50, ForceMode.Impulse);
                _levelController.FinishedLevel = true;

                // Advance to next level
                if(Input.GetButtonDown("Jump") && _levelController.NextLevel != -1)
                {
                    Application.LoadLevel(_levelController.NextLevel);
                }
            }
            // Player Rotation effect
            _playerBody.gameObject.transform.rotation = Quaternion.AngleAxis(_timer * 15, Vector3.up) * _playerBody.gameObject.transform.rotation;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(Tags.Player))
        {
            // End the level if player has enough keys
            if (_itemScript.RequiredKeysCollected())
            {
                _levelController.TimerStopped = true;

                other.GetComponent<BallMovement>().AllowJumping = false;
                other.GetComponent<BallMovement>().LevelFinished = true;

                _playerBody = other.GetComponent<Rigidbody>();
                _playerBody.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;

                _finished = true;
            }
        }
    }

}
