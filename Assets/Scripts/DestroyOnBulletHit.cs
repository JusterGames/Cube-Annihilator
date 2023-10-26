using UnityEngine;

public class DestroyOnBulletHit : MonoBehaviour
{
    // The tag of the object that will trigger the destruction
    public string bulletTag = "bullet";
    
    // The sound effect to play when the object is destroyed (optional)
    public AudioClip destroySound;
    
    // The amount of time to delay before destroying the object (optional)
    public float destroyDelay = 5f; // Change this value to adjust the destroy time

    // Called when the object collides with another object
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision detected!");

        // Check if the other object has the "bullet" tag
        if (collision.gameObject.CompareTag(bulletTag))
        {
            // Play the destruction sound effect (if provided)
            if (destroySound != null)
            {
                AudioSource.PlayClipAtPoint(destroySound, transform.position);
            }
            
            // Destroy the object after a delay (if provided)
            if (destroyDelay > 0f)
            {
                Destroy(gameObject, destroyDelay);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
