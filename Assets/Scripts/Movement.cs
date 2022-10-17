using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{

    private KeyboardControls keyboardController;
    private Rigidbody rocketRigidbody;
    private AudioSource audioSource;

    [SerializeField] float thrustAmount = 1000f;
    [SerializeField] float tiltAmount = .1f;
    [SerializeField] AudioClip mainEngine;

    [SerializeField] ParticleSystem mainJetParticles;
    [SerializeField] ParticleSystem rightJetParticles;
    [SerializeField] ParticleSystem leftJetParticles;

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
        audioSource = GetComponent<AudioSource>();

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
            StartThrust();
        }     
        else {
            StopThrust();
        } 
    }

    void StartThrust()
    {
        rocketRigidbody.AddRelativeForce(Vector3.up * Time.deltaTime * thrustAmount);
        if(!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(mainEngine);
        }

        if(!mainJetParticles.isPlaying)
        {
            mainJetParticles.Play();
        }
    }

    void StopThrust()
    {
        audioSource.Stop();
        mainJetParticles.Stop();
    }

    void ProcessRotation() {
        if(tiltingLeft) {
            TiltingLeft();
        }
        else if(tiltingRight) {
            TiltingRight();
        }
        else
        {
            StopTilting();
        }
    }

    void TiltingLeft()
    {
        if(!rightJetParticles.isPlaying)
        {
            rightJetParticles.Play();
        }
        ApplyRotation(tiltAmount);
    }

    void TiltingRight()
    {
        if(!leftJetParticles.isPlaying)
        {
            leftJetParticles.Play();
        }
        ApplyRotation(-tiltAmount);
    }

    void StopTilting()
    {
        rightJetParticles.Stop();
        leftJetParticles.Stop();
    }

    void ApplyRotation(float rotationThisFrame) {

        // Freezing the Physics system so that collisions don't screw with custom controls
        rocketRigidbody.freezeRotation = true; // Freezing rotation so we can manually rotate
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rocketRigidbody.freezeRotation = false; // Unfreezing rotation so the physics system can take over
        
    }

}
