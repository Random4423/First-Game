using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeThrower : MonoBehaviour 
{
    // Variables
    public float throwForce = 40f;
    public GameObject GrenadePrefab;

	void Update()
	{
        if (GlobalAmmo.GrenadeCount >= 1)
        {
            if (Input.GetButtonDown("Grenade"))
            {
                ThrowGrenade();
            }
        }
	}

    void ThrowGrenade()
    {
        GameObject Grenade = Instantiate(GrenadePrefab, transform.position, transform.rotation);
        Rigidbody rb = Grenade.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * throwForce, ForceMode.VelocityChange);
        GlobalAmmo.GrenadeCount -= 1;
    }
}
