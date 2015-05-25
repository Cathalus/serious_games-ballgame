using UnityEngine;
using System.Collections;

public class BallMovement : MonoBehaviour {

    public float MovementSpeed = 5;
    public bool AllowJumping = false;
    public bool LevelFinished = false;
    public float JumpForce = 2;
    public float ControllerDeadzone = 0.15f;
    public float RaycastDistance = 0.1f;
    public Vector3 Up = Vector3.up;
    public Vector3 Forward = Vector3.zero;

    private float _verticalVelocity = 0;
    private Rigidbody _rigidBody;
    private float _distanceToGround;
    private float _speed = 5;
    private bool _jump;
    private bool _jumpCooldown = false;
    private float counter = 0.0f;

    void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _distanceToGround = GetComponent<SphereCollider>().bounds.extents.y;
        Forward = transform.forward;
    }

    void Update()
    {
        _jump = Input.GetButton("Jump");
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        
       
        // Remove deadzone
        if (Mathf.Abs(horizontal) <= ControllerDeadzone)
            horizontal = 0;
        if (Mathf.Abs(vertical) <= ControllerDeadzone)
            vertical = 0;

        // Jump
        if (_jump && IsGrounded() && AllowJumping && !_jumpCooldown)
        {
            _rigidBody.AddForce(Up*JumpForce, ForceMode.Impulse);
            _jump = false;
            _jumpCooldown = true;
        }

        if(_jumpCooldown)
        {
            counter += Time.deltaTime;

            if(counter >= 0.5f)
            {
                counter = 0.0f;
                _jumpCooldown = false;
            }
        }

        Quaternion temp = transform.rotation;
        transform.rotation = Quaternion.LookRotation(new Vector3(Forward.x, 0, Forward.z));
        
        Vector3 target = new Vector3(horizontal * MovementSpeed, 0, vertical * MovementSpeed);
        target = Quaternion.LookRotation(transform.forward) * target;        
        _rigidBody.AddForce(target, ForceMode.Acceleration);
        transform.rotation = temp;

    }

    bool IsGrounded()
    {
        return Physics.Raycast(transform.position, -Up, _distanceToGround + RaycastDistance);
    }

}
