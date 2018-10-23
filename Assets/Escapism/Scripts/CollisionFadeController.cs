using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionFadeController : MonoBehaviour {

    public VRTK.VRTK_HeadsetCollisionFade Fader;

	public void SetFadeTime(float time)
    {
        Fader.blinkTransitionSpeed = time;
    }
}
