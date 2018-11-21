using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClawMachineController : MonoBehaviour {

    // Is the Claw Machine active
    public bool Active;

    // Game Objects for the moving parts of the claw machine
    public GameObject FrontBackMover, LeftRightMover, ClawCable, Claw, TractorBeam;

    // Counter for Claw Machine State
    private int _TimesButtonPressed = -1;

    // Is the claw Machine resetting moving parts to the default position
    private bool _Resetting = false;
    // Is the claw dropping the ball in a bucket
    private bool _BallPuzzle = false;

    private int _BallsDropped = 0;

    // Activation Cooldown for Claw Machine Button
    private float _ButtonCD = 0.5f;
    private float _ButtonCDTimer = 0.0f;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        // Cooldown timer
        _ButtonCDTimer += Time.deltaTime;
	}

    private void OnTriggerEnter(Collider other)
    {
        // Detects if Button was pressed via collider beaneath the button
        // If machine is active, not resetting, and button not on cooldown
        if (Active && !_Resetting && _ButtonCDTimer > _ButtonCD)
        {
            // Reset the timer for the cooldown
            _ButtonCDTimer = 0.0f;
            if (other.CompareTag("Button"))
            {
                // Incremement Claw Machine State
                _TimesButtonPressed += 1;
                _TimesButtonPressed %= 3;

                // Update the claw machine based on state
                Invoke("UpdateMovement", 0.1f);
            }
        }
        // Detects if coin was put in claw machine via collider beaneath coin slot
        else if (other.CompareTag("Coin"))
        {
            // Destroy the coin and turn on the machine
            Destroy(other.gameObject);
            TractorBeam.SetActive(true);
            Active = true;
        }
    }

    // Update the state of the Claw Machines moveable parts
    private void UpdateMovement()
    {
        switch (_TimesButtonPressed)
        {
            // First state is the claw moving from front to back
            case 0:
                Claw.GetComponent<PlatformScript>().enabled = false;

                FrontBackMover.GetComponent<PlatformScript>().enabled = true;
                FrontBackMover.GetComponent<PlatformScript>().mode = MoveMode.PingPong;
                break;

            // Second state is the claw moving left to right
            case 1:
                FrontBackMover.GetComponent<PlatformScript>().enabled = false;
                LeftRightMover.GetComponent<PlatformScript>().enabled = true;
                LeftRightMover.GetComponent<PlatformScript>().mode = MoveMode.PingPong;
                break;

            // Third state is the claw moving up and down to pickup an object
            // to move to a bucket at the back, then resetting the claw machine
            case 2:
                LeftRightMover.GetComponent<PlatformScript>().enabled = false;

                // Enable claw collider so it can pickup object
                Claw.GetComponent<Collider>().enabled = true;
                //Claw.GetComponent<PlatformScript>().enabled = true;
                //Claw.GetComponent<PlatformScript>().mode = MoveMode.PingPong;
                ClawCable.GetComponent<TimedScale>().ResetTimer();

                // Stop state changing while machine is resetting
                _Resetting = true;
                Invoke("ResetMachine", Claw.GetComponent<PlatformScript>().MovingDistanceY * 2 * 15);
                break;

            default:
                break;
        }
    }

    // Reset the moving parts to their initial position via the PlatformScript component
    private void ResetMachine()
    {
        Claw.GetComponent<PlatformScript>().mode = MoveMode.Resetting;

        FrontBackMover.GetComponent<PlatformScript>().enabled = true;
        FrontBackMover.GetComponent<PlatformScript>().mode = MoveMode.Resetting;

        LeftRightMover.GetComponent<PlatformScript>().enabled = true;
        LeftRightMover.GetComponent<PlatformScript>().mode = MoveMode.Resetting;

        Invoke("FinishResetting", 2.0f);
    }

    // After all moving parts are in their initial position
    // move the claw to the appropriate bucket and drop
    // what ever was picked up
    private void FinishResetting()
    {
        // Controls the claw and makes it move to the relevant position
        if (_BallPuzzle == false && Claw.GetComponent<ClawPickup>().SnapDropZone.GetCurrentSnappedInteractableObject())
        {
            LeftRightMover.GetComponent<PlatformScript>().mode = MoveMode.PingPong;
            // Call is function again after waiting for the claw
            // to move to the proper position
            Invoke("FinishResetting", 0.55f * _BallsDropped);
            // Variable to make this if statement skipped when it is called from within this if
            _BallPuzzle = true;
            _BallsDropped %= 4;
            return;
        }

        // Stop the claw from moving left to right so that it
        // stays above the bucket it must drop an object into
        LeftRightMover.GetComponent<PlatformScript>().enabled = false;

        // Allow the button to be pressed again
        _Resetting = false;
        // Make next function call enter above if statement
        _BallPuzzle = false;

        // Null checks
        VRTK.VRTK_SnapDropZone claw = Claw.GetComponent<ClawPickup>().SnapDropZone;
        if (claw)
        {
            Debug.Log("Claw is not null");
            VRTK.VRTK_InteractableObject obj = claw.GetCurrentSnappedInteractableObject();
            if (obj)
            {
                Debug.Log("Obj is not null");
                // Disabled collider so object isn't immediately picked up when dropped
                Claw.GetComponent<Collider>().enabled = false;
                //TractorBeam.SetActive(false);

                // Change the material on the obejct if it has functionality for it
                MaterialSelector ms = claw.GetCurrentSnappedObject().GetComponent<MaterialSelector>();
                if (ms)
                    ms.SetMaterial(0);

                // Make the claw drop what it's holding
                claw.ForceUnsnap();
            }
        }
    }

    public void ResetBallsDropped()
    {
        _BallsDropped = 0;
    }

    public void IncrementBallsDropped()
    {
        _BallsDropped += 1;
    }

    public void SetActive()
    {
        Active = true;
    }

    public void SetInactive()
    {
        Active = false;
    }
}
