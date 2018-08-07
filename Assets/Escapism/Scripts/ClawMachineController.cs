using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClawMachineController : MonoBehaviour {

    public bool Active = false;
    public GameObject FrontBackMover, LeftRightMover, Claw;

    private int _TimesButtonPressed = -1;
    private bool _Resetting = false;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

    private void OnTriggerEnter(Collider other)
    {
        if (Active && !_Resetting)
        {
            if (other.CompareTag("Button"))
            {
                _TimesButtonPressed += 1;
                _TimesButtonPressed %= 3;

                Invoke("UpdateMovement", 0.1f);
            }
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

                Claw.GetComponent<PlatformScript>().enabled = true;
                Claw.GetComponent<PlatformScript>().mode = MoveMode.PingPong;


                //FrontBackMover.GetComponent<PlatformScript>().enabled = true;
                //FrontBackMover.GetComponent<PlatformScript>().mode = MoveMode.Resetting;

                //LeftRightMover.GetComponent<PlatformScript>().enabled = true;
                //LeftRightMover.GetComponent<PlatformScript>().mode = MoveMode.Resetting;

                Invoke("ResetMachine", Claw.GetComponent<PlatformScript>().MovingDistanceY * 2);
                break;

            default:
                break;
        }
    }

    private void ResetMachine()
    {
        _Resetting = true;

        Claw.GetComponent<PlatformScript>().mode = MoveMode.Resetting;

        FrontBackMover.GetComponent<PlatformScript>().enabled = true;
        FrontBackMover.GetComponent<PlatformScript>().mode = MoveMode.Resetting;

        LeftRightMover.GetComponent<PlatformScript>().enabled = true;
        LeftRightMover.GetComponent<PlatformScript>().mode = MoveMode.Resetting;

        Invoke("FinishResetting", 3.0f);
    }

    private void FinishResetting()
    {
        _Resetting = false;
    }
}
