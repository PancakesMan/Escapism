using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyIgnoreColliders : MonoBehaviour {

    public GameObject Object;

	// Use this for initialization
	void Start () {
        // Get this obejects collider, and colliders of all children under Object
        Collider collider = GetComponent<Collider>();
        Collider[] colliders = Object.GetComponentsInChildren<Collider>();
        Debug.Log("Number of colliders: " + colliders.Length);

        foreach (Collider c in colliders)
        {
            // Ignore collisions between all colliders childed to Object and this object's collider
            Physics.IgnoreCollision(collider, c);
            Debug.Log("Collision ignored between " + collider.name + " and " + c.name);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
