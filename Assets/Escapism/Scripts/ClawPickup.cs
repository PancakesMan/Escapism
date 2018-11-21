using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class ClawPickup : MonoBehaviour {

    public bool ChangeMaterial = false;
    public VRTK.VRTK_SnapDropZone SnapDropZone;

    // Function for allowing the Claw Machine Claw to pickup objects
    private void OnTriggerEnter(Collider other)
    {
        // Don't pickup objects that aren't magnetic
        if (other.CompareTag("Magnetic") == false) return;

        // Force snap the object to the claw using it's SnapDropZone
        Debug.Log("Claw hit " + other.gameObject.name);
        SnapDropZone.ForceSnap(other.gameObject);

        GameObject obj = SnapDropZone.GetCurrentSnappedObject();
        if (obj)
        {
            // If the picked up object has an alternate material
            // Set it to use that material
            MaterialSelector ms = obj.GetComponent<MaterialSelector>();
            if (ChangeMaterial && ms)
                ms.SetMaterial(1);
        }
    }
}
