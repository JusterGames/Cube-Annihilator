using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DestroyEnemy : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("bullet"))
        {
            Destroy(gameObject);
            Debug.Log("I am dead. ;(");
        }
    }
}
