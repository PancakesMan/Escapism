using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class ClawPickup : MonoBehaviour {

    public bool ChangeMaterial = false;
    public VRTK.VRTK_SnapDropZone SnapDropZone;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Magnetic") == false) return;

        Debug.Log("Claw hit " + other.gameObject.name);
        SnapDropZone.ForceSnap(other.gameObject);

        GameObject obj = SnapDropZone.GetCurrentSnappedObject();
        if (obj)
        {
            MaterialSelector ms = obj.GetComponent<MaterialSelector>();
            if (ChangeMaterial && ms)
                ms.SetMaterial(1);
        }
    }
}
