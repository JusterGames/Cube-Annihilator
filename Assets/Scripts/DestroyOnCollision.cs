using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        // Check if the colliding object has a tag "Player"
        if (collision.gameObject.CompareTag("Player"))
        {
            // Destroy the object that this script is attached to
            Destroy(gameObject);
        }
    }
}
