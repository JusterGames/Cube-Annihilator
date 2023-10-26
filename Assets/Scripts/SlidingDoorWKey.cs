using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class SlidingDoorWKey : MonoBehaviour
{
    bool unLocked = false;
    Animator _Anim;
    
    void Start()
    {
        _Anim = this.GetComponent<Animator>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            print("I have Entered the trigger");
            if (unLocked == true)
            {
                _Anim.SetTrigger("DoorTrigger");    
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            print("I have left the trigger");
            if (unLocked == true)
            {
                _Anim.SetTrigger("DoorTrigger");
            }
        }
    }
    public void UnLock()
    {
        unLocked = true;
        print(unLocked);
    }
}