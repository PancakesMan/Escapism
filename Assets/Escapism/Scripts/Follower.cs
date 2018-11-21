using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour {

    public Transform target;
    public Vector3 offset;
	
	// Make the gameobject follow the target transform with an optional offset
	void Update () {
        transform.position = target.transform.position + offset;
	}
}
