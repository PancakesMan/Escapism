﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class ClawPickup : MonoBehaviour {

    public VRTK.VRTK_SnapDropZone SnapDropZone;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Claw hit " + other.gameObject.name);
        SnapDropZone.ForceSnap(other.gameObject);
    }
}
