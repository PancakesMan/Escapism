using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour {

    public Transform target;
    public Vector3 offset;
	
	// Update is called once per frame
	void Update () {
        transform.position = target.transform.position + offset;
	}
}
