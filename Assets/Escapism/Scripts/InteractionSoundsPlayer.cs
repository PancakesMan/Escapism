using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

[System.Serializable]
public struct GameObjectCollisionSoundPair
{
    // Struct to link clips to objects for sound
    // when an object collides with a specific object
    public GameObject obj;
    public AudioClip clip;
}

[RequireComponent(typeof(AudioSource), typeof(VRTK_InteractableObject))]
public class InteractionSoundsPlayer : MonoBehaviour {

    [Header("InteractableObject Events")]
    public AudioClip grabbedAudioClip;
    public AudioClip droppedAudioClip;
    public AudioClip usedAudioClip;

    [Header("Collision Events")]
    public AudioClip defaultAudioClip;
    public List<GameObjectCollisionSoundPair> ObjectSpecificCollisionSounds;

    private VRTK_InteractableObject interactable;
    private AudioSource audioSource;

	// Use this for initialization
	void Start () {
        // Get VRTK InteractableObject component
        interactable = GetComponent<VRTK_InteractableObject>();

        // Assign sounds to play when events are fired from the InteractableObject script

        if (grabbedAudioClip)
            interactable.InteractableObjectGrabbed += Interactions_InteractableObjectGrabbed;

        if (droppedAudioClip)
            interactable.InteractableObjectUngrabbed += Interactions_InteractableObjectUngrabbed;

        if (usedAudioClip)
            interactable.InteractableObjectUsed += Interactable_InteractableObjectUsed;

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

    private void Interactable_InteractableObjectUsed(object sender, InteractableObjectEventArgs e)
    {
        audioSource.PlayOneShot(usedAudioClip);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check for a specific sound for the colliding object
        foreach (GameObjectCollisionSoundPair collisionSound in ObjectSpecificCollisionSounds)
        {
            // If one is found, play the sound and exit function
            if (collisionSound.obj == collision.gameObject)
            {
                audioSource.PlayOneShot(collisionSound.clip);
                return;
            }
        }

        // If no object specific sound was found and played in the the loop
        // play default object collision sound
        if (defaultAudioClip)
            audioSource.PlayOneShot(defaultAudioClip);
    }
}
