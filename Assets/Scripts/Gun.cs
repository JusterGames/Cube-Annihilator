using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject projectilePrefab;
    public GameObject muzzlePosition;
    public float muzzleVelocity;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Fire();
        }
    }
    void Fire()
    {
        GameObject projectile = Instantiate(projectilePrefab,
            muzzlePosition.transform.position,
            muzzlePosition.transform.rotation);
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        rb.velocity = transform.forward * muzzleVelocity;
        Destroy(projectile, 5F);
    }
}
