using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingDoor : MonoBehaviour
{
    Animator _Anim;
    // Start is called before the first frame update
    void Start()
    {
        _Anim = this.GetComponent<Animator>();  
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            print("I have entered the trigger");
            _Anim.SetTrigger("DoorTrigger");

        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            print("I have entered the trigger");
            _Anim.SetTrigger("DoorTrigger");

        }
    }
}
