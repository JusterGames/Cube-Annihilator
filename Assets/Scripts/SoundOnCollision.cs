using UnityEngine;

public class SoundOnCollision : MonoBehaviour
{
    public string targetTag; // The tag of the objects you want to react to.
    public AudioClip soundClip; // The sound clip to play when the object is hit.

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag(targetTag))
        {
            if (soundClip != null && audioSource != null)
            {
                audioSource.PlayOneShot(soundClip);
            }
        }
    }
}
