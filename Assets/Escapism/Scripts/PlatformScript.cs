using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MoveMode { PingPong, Resetting }

public class PlatformScript : MonoBehaviour
{
    private Vector3 _InitialPosition;
    public MoveMode mode = MoveMode.PingPong;

    [Range(0, float.MaxValue), Space(10)]
    public float MovingDistanceX = 0;
    public bool NegativeX = false;

    [Range(0, float.MaxValue), Space(10)]
    public float MovingDistanceY = 0;
    public bool NegativeY = false;

    [Range(0, float.MaxValue), Space(10)]
    public float MovingDistanceZ = 0;
    public bool NegativeZ = false;

    public float SpeedReduction = 1.0f;

    // Use this for initialization
    void Start()
    {
        // Store initial position
        _InitialPosition = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        switch (mode)
        {
            case MoveMode.PingPong:
                PingPong();
                break;
            case MoveMode.Resetting:
                ResetPosition();
                break;
            default:
                break;
        }
    }

    void ResetPosition()
    {
        transform.localPosition = Vector3.MoveTowards(transform.localPosition, _InitialPosition, Time.deltaTime);
    }

    void PingPong()
    {
        // PingPong the platform from Initial Position to
        // Initial Position + DistanceX, Y, and Z
        transform.localPosition = _InitialPosition
            + (MovingDistanceX == 0 ? 0 : Mathf.PingPong(Time.time / SpeedReduction, MovingDistanceX)) * Vector3.right * (NegativeX ? -1 : 1)
            + (MovingDistanceY == 0 ? 0 : Mathf.PingPong(Time.time / SpeedReduction, MovingDistanceY)) * Vector3.up * (NegativeY ? -1 : 1)
            + (MovingDistanceZ == 0 ? 0 : Mathf.PingPong(Time.time / SpeedReduction, MovingDistanceZ)) * Vector3.forward * (NegativeZ ? -1 : 1);
    }
}