using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionFadeController : MonoBehaviour {

    public VRTK.VRTK_HeadsetCollisionFade Fader;

    // Helper function to set the fadeout time on the VRTK script via editor event
	public void SetFadeTime(float time)
    {
        Fader.blinkTransitionSpeed = time;
    }
}
