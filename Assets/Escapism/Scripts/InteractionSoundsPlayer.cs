using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

[RequireComponent(typeof(AudioSource), typeof(VRTK_InteractableObject))]
public class InteractionSoundsPlayer : MonoBehaviour {

    public AudioClip grabbedAudioClip;
    public AudioClip droppedAudioClip;
    public AudioClip collidedAudioClip;

    private VRTK_InteractableObject interactable;
    private AudioSource audioSource;

	// Use this for initialization
	void Start () {
        interactable = GetComponent<VRTK_InteractableObject>();

        if (grabbedAudioClip)
            interactable.InteractableObjectGrabbed += Interactions_InteractableObjectGrabbed;

        if (droppedAudioClip)
            interactable.InteractableObjectUngrabbed += Interactions_InteractableObjectUngrabbed;

        audioSource = GetComponent<AudioSource>();
	}

    private void Interactions_InteractableObjectGrabbed(object sender, InteractableObjectEventArgs e)
    {
        audioSource.PlayOneShot(grabbedAudioClip);
    }

    private void Interactions_InteractableObjectUngrabbed(object sender, InteractableObjectEventArgs e)
    {
        audioSource.PlayOneShot(droppedAudioClip);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collidedAudioClip)
            audioSource.PlayOneShot(collidedAudioClip);
    }
}
