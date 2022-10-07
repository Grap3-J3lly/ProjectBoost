using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{

    private KeyboardControls keyboardController;
    private Rigidbody rocketRigidbody;

    [SerializeField] float thrustAmount = 1000f;
    [SerializeField] float tiltAmount = .1f;

    bool thrusting;
    bool tiltingLeft;
    bool tiltingRight;

    void Awake() {
        keyboardController = new KeyboardControls();
        
        keyboardController.Movement.Thrust.performed += OnThrustStart;
        keyboardController.Movement.TiltLeft.performed += OnTiltLeftStart;
        keyboardController.Movement.TiltRight.performed += OnTiltRightStart;

        keyboardController.Movement.Thrust.canceled += OnThrustEnd;
        keyboardController.Movement.TiltLeft.canceled += OnTiltLeftEnd;
        keyboardController.Movement.TiltRight.canceled += OnTiltRightEnd;
    }

    void OnEnable() {
        keyboardController.Enable();
    }

    void OnDisable() {
        keyboardController.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        rocketRigidbody = GetComponent<Rigidbody>();

        thrusting = false;
        tiltingLeft = false;
        tiltingRight = false;
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void OnThrustStart(InputAction.CallbackContext context) {
        thrusting = true;
    }
    void OnThrustEnd(InputAction.CallbackContext context) {
        thrusting = false;
    }

    void OnTiltLeftStart(InputAction.CallbackContext context) {
        tiltingLeft = true;
    }
    void OnTiltLeftEnd(InputAction.CallbackContext context) {
        tiltingLeft = false;
    }

    void OnTiltRightStart(InputAction.CallbackContext context) {
        tiltingRight = true;
    }
    void OnTiltRightEnd(InputAction.CallbackContext context) {
        tiltingRight = false;
    }

    void ProcessThrust() {
        if(thrusting) {
            rocketRigidbody.AddRelativeForce(Vector3.up * Time.deltaTime * thrustAmount);
        }        
    }

    void ProcessRotation() {
        if(tiltingLeft) {
            ApplyRotation(tiltAmount);
        }
        else if(tiltingRight) {
            ApplyRotation(-tiltAmount);
        }
    }

    void ApplyRotation(float rotationThisFrame) {

        // Freezing the Physics system so that collisions don't screw with custom controls
        rocketRigidbody.freezeRotation = true; // Freezing rotation so we can manually rotate
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rocketRigidbody.freezeRotation = false; // Unfreezing rotation so the physics system can take over
        
    }

}
