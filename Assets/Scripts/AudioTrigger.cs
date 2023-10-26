using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTrigger : MonoBehaviour
{
    public AudioClip audioClip;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        // Debug message to check if the AudioSource is found.
        if (audioSource == null)
        {
            Debug.LogError("AudioSource component not found.");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cube"))
        {
            // Debug message to confirm that the trigger event is working.
            Debug.Log("Player entered the trigger zone.");

            if (audioSource != null)
            {
                // Debug message to confirm that the audio clip is being played.
                Debug.Log("Playing audio clip.");
                audioSource.PlayOneShot(audioClip);
            }
            else
            {
                // Debug message if audio source is not found.
                Debug.LogError("AudioSource component not found.");
            }
        }
    }
}
