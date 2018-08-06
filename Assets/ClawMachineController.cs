using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClawMachineController : MonoBehaviour {

    public bool Active = false;
    public GameObject FrontBackMover, LeftRightMover, Claw;

    private int _TimesButtonPressed = -1;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (Active)
        {
            if (other.CompareTag("Button"))
            {
                _TimesButtonPressed += 1;
                _TimesButtonPressed %= 3;

                switch (_TimesButtonPressed)
                {
                    case 0:
                        FrontBackMover.GetComponent<PlatformScript>().enabled = true;
                        break;

                    case 1:
                        FrontBackMover.GetComponent<PlatformScript>().enabled = false;
                        LeftRightMover.GetComponent<PlatformScript>().enabled = true;
                        break;

                    case 2:
                        LeftRightMover.GetComponent<PlatformScript>().enabled = false;
                        break;

                    default:
                        break;
                }
            }
        }
    }
}
