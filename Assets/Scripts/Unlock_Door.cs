using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Unlock_Door : MonoBehaviour
{
    public SlidingDoorWKey DoorToUnLock;
   
   
    void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("Player"))
        {
            DoorToUnLock.UnLock();
            Destroy(gameObject);
        }
    }

}
