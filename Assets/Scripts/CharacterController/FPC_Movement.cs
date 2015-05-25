using UnityEngine;
using System.Collections;

public class FPC_Movement : MonoBehaviour {

    public float MovementSpeed = 5;
    public float RunningSpeed = 7;
    public bool AllowJumping = false;
    public bool AllowMultiJump = false;
    public float JumpSpeed = 20;
    public float ControllerDeadzone = 0.15f;

    private CharacterController _characterController;
    private bool running = false;
    private float _verticalVelocity = 0;
    private bool speedyJump = false;

    void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }
	
	void Update () {
        
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        running = Input.GetButton("Run");

        if (Mathf.Abs(horizontal) <= ControllerDeadzone)
            horizontal = 0;

        Vector3 movement = Vector3.zero;
        movement = new Vector3(horizontal, 0, vertical);
        movement = transform.rotation * movement;

        // Normalize Movement
        if (movement.magnitude > 1)
        {
            movement /= movement.magnitude;
        }

        // Speed
        if (_characterController.isGrounded)
        {
            movement *= (running ? RunningSpeed : MovementSpeed) * Time.deltaTime;
        }else{
            movement *= (speedyJump ? RunningSpeed : MovementSpeed) * Time.deltaTime;
        }

        // Jumping
        if (Input.GetButtonDown("Jump") && (_characterController.isGrounded || AllowMultiJump))        // Jump
        {
            _verticalVelocity = JumpSpeed;
        }

        // Gravity
        _verticalVelocity += Physics.gravity.y * Time.deltaTime;
        //_verticalVelocity = Mathf.Clamp(_verticalVelocity, Physics.gravity.y, JumpSpeed);

        movement += new Vector3(0, _verticalVelocity * Time.deltaTime, 0);

        _characterController.Move(movement);

        if(_characterController.isGrounded)
        {
            speedyJump = running;
        }
	}
}
