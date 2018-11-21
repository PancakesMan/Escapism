using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedScale : MonoBehaviour {

    private Vector3 InitialScale;
    public Vector3 TargetScale;

    public float timer;

    public float Speed = 1.0f;
    private float TotalTime;
    public float alpha;

	// Use this for initialization
	void Start () {
        InitialScale = transform.localScale;
        TotalTime = 2;
        timer = TotalTime;

	}
	
	// Update is called once per frame
	void Update () {
        timer += Speed * Time.deltaTime;

        if (timer <= TotalTime) // not yet done one pingpong
        {
            //timer = 2.0f;
            alpha = Mathf.PingPong(timer, 1.0f);
            // PingPong the object between InitialScale and TargetScale based on timer
            transform.localScale = Vector3.Lerp(InitialScale, TargetScale, alpha);
        }

	}

    public void ResetTimer()
    {
        timer = 0;
    }

    [ContextMenu("Set Target Scale")]
    public void SetTargetScale()
    {
        TargetScale = transform.localScale;
    }
}
