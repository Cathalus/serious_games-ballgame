using UnityEngine;
using System.Collections;

public class FPC_Mouse : MonoBehaviour {

    public float MouseSensitivityX = 1.0f;
    public float MouseSensitivityY = 1.0f;
    public float PitchRange = 60.0f;
    public float ControllerDeadzoneX = 0.09f;
    public float ControllerDeadzoneY = 0.09f;

    public bool HideMouse = false;

    private CharacterController _characterController;
    private Camera _camera;
    private float _verticalRotation = 0.0f;
    
    public void Awake()
    {
        Settings.MouseLocked = HideMouse;
        _characterController = GetComponent<CharacterController>();
        _camera = GameObject.FindGameObjectWithTag(Tags.MainCamera).GetComponent<Camera>();
    }

	void Update () {
        if (Settings.MouseLocked)
        {
            // Rotate player transform
            float yaw = Input.GetAxis("Controller X");
            if (Mathf.Abs(yaw) < ControllerDeadzoneX)
                yaw = 0;
            transform.Rotate(0, yaw * MouseSensitivityX, 0);


            // Rotate main camera
            float pitch = Input.GetAxis("Controller Y");
            if (Mathf.Abs(pitch) < ControllerDeadzoneX)
                pitch = 0;

            _verticalRotation -= pitch * MouseSensitivityY;
            _verticalRotation = Mathf.Clamp(_verticalRotation, -PitchRange, PitchRange);

            _camera.transform.localRotation = Quaternion.Euler(_verticalRotation, 0, 0);
        }
        LockCursor();
	}

    void LockCursor()
    {
        if (Settings.MouseLocked)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
