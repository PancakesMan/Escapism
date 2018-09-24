using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachWithHinge : MonoBehaviour {

    private List<GameObject> AttachedPreviously;

	// Use this for initialization
	void Start () {
        AttachedPreviously = new List<GameObject>();
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.GetComponent<AttachWithHinge>() ||
            AttachedPreviously.Contains(collision.gameObject)) return;

        Rigidbody body = collision.rigidbody;
        if (!body)
            body = collision.gameObject.AddComponent<Rigidbody>();

        FixedJoint joint = gameObject.AddComponent<FixedJoint>();
        joint.breakForce = 50;
        joint.connectedBody = body;

        AttachedPreviously.Add(collision.gameObject);
    }
}
