using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class JointBreakEvent : MonoBehaviour {

    [System.Serializable]
    public class JointBreakingEvent : UnityEvent { }

    public JointBreakingEvent OnJointBreaking;

    private void OnJointBreak(float breakForce)
    {
        OnJointBreaking.Invoke();
    }
}
