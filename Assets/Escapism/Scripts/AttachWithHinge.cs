using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachWithHinge : MonoBehaviour {

    // List of bodies already attached to
    private List<GameObject> AttachedPreviously;

	// Use this for initialization
	void Start () {
        AttachedPreviously = new List<GameObject>();
	}

    // Attach via hinge to all rigid bodies that collide and have this component
    private void OnCollisionEnter(Collision collision)
    {
        // Check if component doesn't exist or if we're already attached to it
        if (!collision.gameObject.GetComponent<AttachWithHinge>() ||
            AttachedPreviously.Contains(collision.gameObject)) return;

        // Get the rigid body on the colliding object
        // if it doesn't exist, create one on it
        Rigidbody body = collision.rigidbody;
        if (!body)
            body = collision.gameObject.AddComponent<Rigidbody>();

        // Add a join to the current object
        // Set the connected body to be the colliding object
        FixedJoint joint = gameObject.AddComponent<FixedJoint>();
        joint.breakForce = 50;
        joint.connectedBody = body;

        // Add the colliding object to the list of previously attached objects
        AttachedPreviously.Add(collision.gameObject);
    }
}
