using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class ClawPickup : MonoBehaviour {
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Claw hit something");
        GetComponentInChildren<VRTK_SnapDropZone>().ForceSnap(other.gameObject);
    }
}
