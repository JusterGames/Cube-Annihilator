using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetOnFall : MonoBehaviour
{
    public float resetHeight = -10f;
    public Vector3 resetPosition = Vector3.zero;

    private void FixedUpdate()
    {
        if(transform.position.y < resetHeight)
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            transform.position = resetPosition;
        }
    }
}
