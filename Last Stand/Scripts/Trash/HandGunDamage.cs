using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*	SCRIPT PURPOSE:
 * 		This Script is for the Handgun
 * 		Allows for Damage by Handgun
 * 		Makes Bullet holes on items
 * 		Makes Blood on Enemies
*/

// This Script Allows you to inflict damage with your handgun
public class HandGunDamage : MonoBehaviour {

	// Variables
	public int DamageAmount;		// Damage Caused By Handgun
	public float TargetDistance;		// The Target Distance
	public float AllowedRange = 15;		// The Allowed Distance For Causing Damage

	RaycastHit Hit;
	public GameObject TheBullet;
	public GameObject TheBlood;


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
			if (Input.GetButtonDown ("Fire1")) 
			{
				RaycastHit Shot;

				if (Physics.Raycast (transform.position, transform.TransformDirection (Vector3.forward),out Shot)) 
				{
					TargetDistance = Shot.distance;

					if (TargetDistance < AllowedRange) 
					{
						//Shot.transform.SendMessage ("DeductPoints", DamageAmount); // (Moved Down)

						if (Physics.Raycast (transform.position, transform.TransformDirection (Vector3.forward), out Hit)) 
						{
							// Make Zombie Bleed
							if(Hit.transform.tag == "Zombie" || Hit.transform.tag == "Boss")
							{
								Instantiate (TheBlood, Hit.point, Quaternion.FromToRotation (Vector3.up, Hit.normal));
							}
							// Headshot Zombie01
							if(Hit.collider.tag == "Zombie01Head")
							{
								DamageAmount = 10;
								Instantiate (TheBlood, Hit.point, Quaternion.FromToRotation (Vector3.up, Hit.normal));
							}

							// Make Bullet Hole
							if (Hit.transform.tag == "untagged") 
							{
								Instantiate (TheBullet, Hit.point, Quaternion.FromToRotation (Vector3.up, Hit.normal));
							}
						}
						Shot.transform.SendMessage ("DeductPoints", DamageAmount);
						DamageAmount = 5;
					}
				}
			}
		}
	}
}
