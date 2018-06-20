using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour {



    // Variables ----------------------------------------------------
    public float delay = 3f;                    // Grenade Delay
    float countdown;                            // Countdown till...
    bool hasExploded = false;                   // Explosion Flag
    public GameObject explosionEffect;          // Explosion Particles
    public float radiusBlast = 5f;              // Blast Radius
    public float force = 200f;                  // Explosion Force
    public int GDamageAmount = 10;              // Damage to Cause
    // Variables ----------------------------------------------------
    public GameObject GrenadeObj;


	void Start()
	{
        countdown = delay;
	}

	void Update()
	{
        countdown -= Time.deltaTime;

        if(countdown <= 0f && !hasExploded)
        {
            Explode();

            hasExploded = true; 
        }
	}



    void Explode()
    {
        GrenadeObj.GetComponent<AudioSource>().Play();
        // Show Effect
        Instantiate(explosionEffect, transform.position, transform.rotation);




        // Get Nearby Objects
       Collider[] collidersToMove = Physics.OverlapSphere(transform.position, radiusBlast);
     
        // Add Force
        foreach(Collider nearbyObject in collidersToMove)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();

            if(rb != null)
            {
                rb.AddExplosionForce(force, transform.position, radiusBlast);
            }

            if(nearbyObject.tag == "Zombie" || nearbyObject.tag == "Boss")
            {
                nearbyObject.transform.SendMessage("DeductPoints", GDamageAmount);
                GlobalScore.CurrentScore += 50;
            }
        }

        StartCoroutine(DestroyGren());

        // Destroy Object
        //Destroy(gameObject);
    }

    IEnumerator DestroyGren()
    {
        yield return new WaitForSeconds(1.3f);
        Destroy(gameObject);
    }

}
