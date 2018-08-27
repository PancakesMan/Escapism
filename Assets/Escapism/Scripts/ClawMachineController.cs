using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClawMachineController : MonoBehaviour {

    public bool Active;
    public GameObject FrontBackMover, LeftRightMover, Claw;

    private int _TimesButtonPressed = -1;
    private bool _Resetting = false;
    private bool _BallPuzzle = false;

    private int _BallsDropped = 0;

    private float _ButtonCD = 0.5f;
    private float _ButtonCDTimer = 0.0f;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        _ButtonCDTimer += Time.deltaTime;
	}

    private void OnTriggerEnter(Collider other)
    {
        if (Active && !_Resetting && _ButtonCDTimer > _ButtonCD)
        {
            _ButtonCDTimer = 0.0f;
            if (other.CompareTag("Button"))
            {
                _TimesButtonPressed += 1;
                _TimesButtonPressed %= 3;

                Invoke("UpdateMovement", 0.1f);
            }
        }
        else if (other.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            Active = true;
        }
    }

    private void UpdateMovement()
    {
        switch (_TimesButtonPressed)
        {
            case 0:
                Claw.GetComponent<PlatformScript>().enabled = false;

                FrontBackMover.GetComponent<PlatformScript>().enabled = true;
                FrontBackMover.GetComponent<PlatformScript>().mode = MoveMode.PingPong;
                break;

            case 1:
                FrontBackMover.GetComponent<PlatformScript>().enabled = false;
                LeftRightMover.GetComponent<PlatformScript>().enabled = true;
                LeftRightMover.GetComponent<PlatformScript>().mode = MoveMode.PingPong;
                break;

            case 2:
                LeftRightMover.GetComponent<PlatformScript>().enabled = false;

                Claw.GetComponent<Collider>().enabled = true;
                Claw.GetComponent<PlatformScript>().enabled = true;
                Claw.GetComponent<PlatformScript>().mode = MoveMode.PingPong;

                _Resetting = true;
                Invoke("ResetMachine", Claw.GetComponent<PlatformScript>().MovingDistanceY * 2 * 15);
                break;

            default:
                break;
        }
    }

    private void ResetMachine()
    {
        Claw.GetComponent<PlatformScript>().mode = MoveMode.Resetting;

        FrontBackMover.GetComponent<PlatformScript>().enabled = true;
        FrontBackMover.GetComponent<PlatformScript>().mode = MoveMode.Resetting;

        LeftRightMover.GetComponent<PlatformScript>().enabled = true;
        LeftRightMover.GetComponent<PlatformScript>().mode = MoveMode.Resetting;

        Invoke("FinishResetting", 2.0f);
    }

    private void FinishResetting()
    {
        if (_BallPuzzle == false && Claw.GetComponent<ClawPickup>().SnapDropZone.GetCurrentSnappedInteractableObject())
        {
            LeftRightMover.GetComponent<PlatformScript>().mode = MoveMode.PingPong;
            Invoke("FinishResetting", 0.55f * _BallsDropped);
            _BallPuzzle = true;
            _BallsDropped++;
            _BallsDropped %= 4;
            return;
        }

        LeftRightMover.GetComponent<PlatformScript>().enabled = false;

        _Resetting = false;
        _BallPuzzle = false;

        VRTK.VRTK_SnapDropZone claw = Claw.GetComponent<ClawPickup>().SnapDropZone;
        if (claw)
        {
            Debug.Log("Claw is not null");
            VRTK.VRTK_InteractableObject obj = claw.GetCurrentSnappedInteractableObject();
            if (obj)
            {
                Debug.Log("Obj is not null");
                Claw.GetComponent<Collider>().enabled = false;
                claw.ForceUnsnap();

                obj.isGrabbable = true;
                //obj.gameObject.GetComponent<Rigidbody>().isKinematic = false;
            }
        }
    }

    public void ResetBallsDropped()
    {
        _BallsDropped = 0;
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
