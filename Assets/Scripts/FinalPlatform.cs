using UnityEngine;
using System.Collections;

public class FinalPlatform : MonoBehaviour {

    public Material NotFinishedMaterial;
    public Material FinishedMaterial;
    public float TimeToNextLevel = 5;

    private Items _itemScript;
    private bool _finished = false;
    private float _timer;
    private Rigidbody _playerBody;

    void Awake()
    {
        _itemScript = GameObject.FindGameObjectWithTag(Tags.GameController).GetComponent<Items>();
        GetComponent<Renderer>().material = NotFinishedMaterial;
    }

    void Update()
    {
        if (_itemScript.KeysCollected())
        {
            GetComponent<Renderer>().material = FinishedMaterial;
        }

        if(_finished)
        {
            _timer += Time.deltaTime;
            if(_timer >= TimeToNextLevel)
            {
                _playerBody.AddForce(Vector3.up*50, ForceMode.Impulse);
                _itemScript.FinishedLevel = true;
            }
            // Player Rotation effect
            _playerBody.gameObject.transform.rotation = Quaternion.AngleAxis(_timer * 15, Vector3.up) * _playerBody.gameObject.transform.rotation;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(Tags.Player))
        {
            // End the level
            if (_itemScript.KeysCollected())
            {
                _itemScript.TimerStopped = true;

                other.GetComponent<BallMovement>().AllowJumping = false;
                other.GetComponent<BallMovement>().LevelFinished = true;

                _playerBody = other.GetComponent<Rigidbody>();
                _playerBody.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;

                _finished = true;
            }
        }
    }

}
