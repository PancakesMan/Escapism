using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum LockType { Rigidbody, Interactable }

public class Lockable : MonoBehaviour {

    public LockType Type = LockType.Rigidbody;
    public bool Locked = false;

    public VRTK.Controllables.PhysicsBased.VRTK_PhysicsSlider[] DisabledObjectsWhenUnlocked;

    private void Update()
    {
        if (Locked)
        {
            switch (Type)
            {
                case LockType.Rigidbody:
                    GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                    break;
                case LockType.Interactable:
                    GetComponent<VRTK.VRTK_InteractableObject>().isGrabbable = false;
                    break;
                default:
                    break;
            }
            foreach (VRTK.Controllables.PhysicsBased.VRTK_PhysicsSlider drawer in DisabledObjectsWhenUnlocked)
                drawer.enabled = true;
        }
        else
        {
            switch (Type)
            {
                case LockType.Rigidbody:
                    GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                    break;
                case LockType.Interactable:
                    GetComponent<VRTK.VRTK_InteractableObject>().isGrabbable = true;
                    break;
                default:
                    break;
            }
            foreach (VRTK.Controllables.PhysicsBased.VRTK_PhysicsSlider drawer in DisabledObjectsWhenUnlocked)
                drawer.enabled = false;
        }
    }

    public void Lock()
    {
        Locked = true;
    }

    public void Unlock()
    {
        Locked = false;
    }
}
