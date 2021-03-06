﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Rope : MonoBehaviour {

    GameObject chain;

    // Use this for initialization
    void Start() {
        //chain = transform.GetChild(0).gameObject;
        //HingeJoint joint = chain.AddComponent<HingeJoint>();
        //joint.useSpring = true;
        //joint.connectedBody = gameObject.GetComponent<Rigidbody>();

        HingeJoint joint;

        //for (int i = 1; i < Links; i++)
        for (int i = 0; i < transform.childCount; i++)
        {
            //GameObject nextLink = Instantiate(chain);
            //nextLink.transform.SetAsLastSibling();

            // Connect points on rope together
            joint = transform.GetChild(i).gameObject.AddComponent<HingeJoint>(); //nextLink.GetComponent<HingeJoint>();
            joint.connectedBody = i == 0 ? transform.GetComponent<Rigidbody>() : transform.GetChild(i - 1).GetComponent<Rigidbody>();
            //joint.useSpring = true;

            //JointSpring spr = new JointSpring();
            //spr.damper = 50000;
            //spr.spring = 5000000;

            //joint.spring = spr;
            joint.anchor = Vector3.zero;
            joint.connectedAnchor = -Vector3.up;
        }
	}
	
	// Update is called once per frame
	void Update () {
        // Update points in LineRenderer based on children of rope object
        LineRenderer rope = GetComponent<LineRenderer>();
        rope.positionCount = transform.childCount + 1;
        rope.SetPosition(0, transform.position);
        for (int i = 0; i < transform.childCount; i++)
            rope.SetPosition(i + 1, transform.GetChild(i).position);
    }
}
