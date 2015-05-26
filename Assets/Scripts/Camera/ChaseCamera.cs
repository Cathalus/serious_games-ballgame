using UnityEngine;
using System.Collections;

/// <summary>
/// The Chase Camera is a camera that chases a target.
/// It can be rotated.
/// </summary>
public class ChaseCamera : MonoBehaviour {

    /// <summary>
    /// The GameObject that is going to be chased
    /// </summary>
    public GameObject Target;
    /// <summary>
    /// Lowest rotation value on the Y axis
    /// </summary>
    public float MinRotationY = 60;
    /// <summary>
    /// Highest rotation value on the Y axis
    /// </summary>
    public float MaxRotationY = 0;
    /// <summary>
    /// Speed of the rotation in X direction
    /// </summary>
    public float RotationXSpeed = 5;
    /// <summary>
    /// Speed of the rotation in Y direction
    /// </summary>
    public float RotationYSpeed = 5;
    /// <summary>
    /// The forward vector of the camera
    /// </summary>
    //public Vector3 Forward = Vector3.zero;

    /// <summary>
    /// Predefined distance to the target
    /// </summary>
    private Vector3 _distanceToTarget;
    /// <summary>
    /// Reference to the Camera Object
    /// </summary>
    private Camera _camera;
    /// <summary>
    /// Current rotation in the X direction
    /// </summary>
    private float _rotationX = 0;
    /// <summary>
    /// Current rotation in the Y direction
    /// </summary>
    private float _rotationY = 0;
    /// <summary>
    /// Reference to the BallMovement Script
    /// </summary>
    private BallMovement _movementScript;

    void Awake()
    {
        _distanceToTarget = gameObject.transform.position - Target.transform.position;
        _camera = GameObject.FindGameObjectWithTag(Tags.MainCamera).GetComponent<Camera>();
        _movementScript = Target.GetComponent<BallMovement>();
    }

    void Update()
    {
        // Follow the target only when the level isn't finished yet
        if (!Target.GetComponent<BallMovement>().LevelFinished)
        {
            // Yaw is the rotation on the y axis
            float yaw = Input.GetAxis("Controller X");
            _rotationY += yaw * Time.deltaTime * RotationXSpeed;

            // Pitch is the rotation on the x axis
            float pitch = Input.GetAxis("Controller Y");
            if ((_rotationX >= MinRotationY && pitch > 0) || (_rotationX < -MaxRotationY && pitch < 0))
                pitch = 0;
            _rotationX += pitch * Time.deltaTime * RotationYSpeed;

            // Update the position to follow the target and rotate the camera to the given rotation
            transform.position = Target.transform.position + Quaternion.Euler(_rotationX, _rotationY, 0) * _distanceToTarget;
            transform.LookAt(Target.transform.position);
            _movementScript.Forward = transform.forward;
        }
    }
	
}
