using UnityEngine;
using System.Collections;

/// <summary>
/// Controls the Movement of the Ball
/// </summary>
public class BallMovement : MonoBehaviour {

    /// <summary>
    /// Defines how fast the ball accelerates
    /// </summary>
    public float MovementSpeed = 5;
    /// <summary>
    /// Enables/Disables jumping
    /// </summary>
    public bool AllowJumping = false;
    /// <summary>
    /// Whether or not the level is finished
    /// </summary>
    public bool LevelFinished = false;
    /// <summary>
    /// Force of a Jump
    /// </summary>
    public float JumpForce = 2;
    /// <summary>
    /// Deadzone of the controller
    /// </summary>
    public float ControllerDeadzone = 0.15f;
    /// <summary>
    /// Distance to raycast beneath the ball
    /// </summary>
    public float RaycastDistance = 0.1f;
    /// <summary>
    /// The global Up direction can be changed e.g when the gravity changes
    /// </summary>
    public Vector3 Up = Vector3.up;
    /// <summary>
    /// Forward direction of the ball
    /// </summary>
    public Vector3 Forward = Vector3.zero;

    /// <summary>
    /// Reference to the RigidBody Component
    /// </summary>
    private Rigidbody _rigidBody;
    /// <summary>
    /// Distance from the ball to the ground
    /// </summary>
    private float _distanceToGround;
    /// <summary>
    /// True when the player hits jump
    /// </summary>
    private bool _jump;
    /// <summary>
    /// Defines whether the jump is on cooldown
    /// </summary>
    private bool _jumpCooldown = false;
    /// <summary>
    /// Counting variable for jump cooldown
    /// </summary>
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
        
        // Cull deadzone
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

        // Wait for jump to become ready again
        if(_jumpCooldown)
        {
            counter += Time.deltaTime;

            if(counter >= 0.5f)
            {
                counter = 0.0f;
                _jumpCooldown = false;
            }
        }

        // Cache ball rotation
        Quaternion temp = transform.rotation;

        // Rotate ball to camera look rotation (stored in Forward)
        transform.rotation = Quaternion.LookRotation(new Vector3(Forward.x, 0, Forward.z));
        
        // Calculate target force
        Vector3 target = new Vector3(horizontal * MovementSpeed, 0, vertical * MovementSpeed);
        // Turn target to forward rotation
        target = Quaternion.LookRotation(transform.forward) * target;        
        // Move Ball
        _rigidBody.AddForce(target, ForceMode.Acceleration);

        // Revert to cached ball rotation
        transform.rotation = temp;

    }

    /// <summary>
    /// Raycasts beneath the ball and checks if it's on the ground
    /// </summary>
    /// <returns>True when ball is on the ground | False when ball isn't on the ground</returns>
    bool IsGrounded()
    {
        return Physics.Raycast(transform.position, -Up, _distanceToGround + RaycastDistance);
    }

}
