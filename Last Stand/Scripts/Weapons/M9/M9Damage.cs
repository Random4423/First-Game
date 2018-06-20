using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*	SCRIPT PURPOSE:
 * 		This Script is for M9
 * 		Allows for Damage by M9
 * 		Makes Bullet holes on items
 * 		Makes Blood on Enemies
*/

// This Script Allows you to inflict damage with your M9
public class M9Damage : MonoBehaviour {

	// Variables
	public int DamageAmount;			// Damage Caused By Handgun
	public float TargetDistance;		// The Target Distance
	public float AllowedRange = 15;		// The Allowed Distance For Causing Damage

	RaycastHit Hit;
	public GameObject TheBullet;		// Bullet
	public GameObject TheBlood;			// Blood


	void Start()
	{
		DamageAmount = 5;
	}


	void Update () 
	{
        // if magazine ammo is >= 1, Check for Player Shooting, Grab Raycast Data, Check if in range, cause damage to enemy
        if (GlobalAmmo.LoadedAmmo >= 1)
        {
            // When Shot fired, use raycast..., calculate distance from enemy, if distance is allowed, inflict damage
            if (Input.GetButtonDown("Fire1"))
            {
                RaycastHit Shot;

                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out Shot))
                {
                    TargetDistance = Shot.distance;

                    if (TargetDistance < AllowedRange)
                    {
                        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out Hit))
                        {
                            // Make Zombie Bleed
                            if (Hit.transform.tag == "Zombie" || Hit.transform.tag == "Boss")
                            {
                                Instantiate(TheBlood, Hit.point, Quaternion.FromToRotation(Vector3.up, Hit.normal));
                                Debug.Log("Body Hit" + " | " + "M9 Damage: " + DamageAmount);
                            }
                            // Headshot Zombie01
                            //if(Hit.collider.tag == "Zombie01Head" || Hit.collider.tag == "BossHead")
                            //{
                            //  DamageAmount = 10;
                            //  Instantiate (TheBlood, Hit.point, Quaternion.FromToRotation (Vector3.up, Hit.normal));
                            //  Debug.Log ("Head Hit" + " | " + "Damage: " + DamageAmount);
                            //}

                            // Make Bullet Hole
                            if (Hit.transform.tag == "untagged")
                            {
                                Debug.Log("firing hole");
                                Instantiate(TheBullet, Hit.point, Quaternion.FromToRotation(Vector3.up, Hit.normal));
                                Debug.Log("Hole Fired");
                            }
                        }
                        Shot.transform.SendMessage("DeductPoints", DamageAmount);
                        DamageAmount = 5;
                    }
                }
            }
        }
	}
}
