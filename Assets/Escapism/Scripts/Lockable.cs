using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum LockType { Rigidbody, Interactable }

public class Lockable : MonoBehaviour {

    [System.Serializable]
    public class UnlockedEvent : UnityEvent { }

    [System.Serializable]
    public class LockedEvent : UnityEvent { }

    public LockType Type = LockType.Rigidbody;

    public bool Locked = false;
    private bool _Locked;

    public LockedEvent OnLocked;
    public UnlockedEvent OnUnlocked;

    private void Start()
    {
        _Locked = Locked;
        LockStateChangedHandler();
    }

    void LockStateChangedHandler()
    {
        // If the object is locked
        if (_Locked)
        {
            switch (Type)
            {
                // If this is a RigidBody type lock, freeze all constraints to lock the object
                case LockType.Rigidbody:
                    GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                    break;
                // If this is an interactable type lock, disable player interactions
                // and make the object kinematic
                case LockType.Interactable:
                    GetComponent<VRTK.VRTK_InteractableObject>().isGrabbable = false;
                    GetComponent<Rigidbody>().isKinematic = true;
                    break;
                default:
                    break;
            }
        }
        else
        {
            // unlock the object
            switch (Type)
            {
                // Unfreeze constraints if it is a RigidBody type lock
                case LockType.Rigidbody:
                    GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                    break;
               // Allow interactions if it is an interactable type lock
                case LockType.Interactable:
                    GetComponent<VRTK.VRTK_InteractableObject>().isGrabbable = true;
                    GetComponent<Rigidbody>().isKinematic = false;
                    break;
                default:
                    break;
            }
        }
    }

    public void Lock()
    {
        // Lock the obejct and fire OnLocked event
        _Locked = true;
        LockStateChangedHandler();
        OnLocked.Invoke();
    }

    public void Unlock()
    {
        // Unlock the object and fire OnUnlocked event
        _Locked = false;
        LockStateChangedHandler();
        OnUnlocked.Invoke();
    }
}
