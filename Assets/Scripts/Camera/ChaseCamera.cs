using UnityEngine;
using System.Collections;

public class ChaseCamera : MonoBehaviour {

    public GameObject Target;
    public float ControllerDeadzoneX = 0.1f;
    public float ControllerDeadzoneY = 0.1f;
    public float MinRotationX = 60;
    public float MaxRotationX = 0;
    public float RotationXSpeed = 5;
    public float RotationYSpeed = 5;
    public Vector3 Forward = Vector3.zero;

    private Vector3 _distanceToTarget;
    private Camera _camera;
    private float _rotationX = 0;
    private float _rotationY = 0;
    private BallMovement _movementScript;

    void Awake()
    {
        _distanceToTarget = gameObject.transform.position - Target.transform.position;
        _camera = GameObject.FindGameObjectWithTag(Tags.MainCamera).GetComponent<Camera>();
        _movementScript = Target.GetComponent<BallMovement>();
    }

    void FixedUpdate()
    {
        if (!Target.GetComponent<BallMovement>().LevelFinished)
        {
            float yaw = Input.GetAxis("Controller X");

            _rotationY += yaw * Time.deltaTime * RotationXSpeed;

            float pitch = Input.GetAxis("Controller Y");
            if ((_rotationX >= MinRotationX && pitch > 0) || (_rotationX < -MaxRotationX && pitch < 0))
                pitch = 0;

            _rotationX += pitch * Time.deltaTime * RotationYSpeed;

            transform.position = Target.transform.position + Quaternion.Euler(_rotationX, _rotationY, 0) * _distanceToTarget;
            transform.LookAt(Target.transform.position);

            Forward = transform.forward;
            _movementScript.Forward = Forward;
        }
    }
	
}
