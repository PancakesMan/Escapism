using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

[RequireComponent(typeof(AudioSource), typeof(VRTK_InteractableObject))]
public class InteractionSoundsPlayer : MonoBehaviour {

    public AudioClip grabbedAudioClip;

    private VRTK_InteractableObject interactions;
    private AudioSource audioSource;

	// Use this for initialization
	void Start () {
        interactions = GetComponent<VRTK_InteractableObject>();
        interactions.InteractableObjectGrabbed += Interactions_InteractableObjectGrabbed;

        audioSource = GetComponent<AudioSource>();
	}

    private void Interactions_InteractableObjectGrabbed(object sender, InteractableObjectEventArgs e)
    {
        audioSource.PlayOneShot(grabbedAudioClip);
    }
}
