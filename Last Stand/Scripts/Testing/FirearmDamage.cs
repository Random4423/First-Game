using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirearmDamage : MonoBehaviour {

// Variables
//	public int DamageAmount;		// Damage Calused
//	public float TargetDistance;	// The Target Distance
//	public float AllowedRange;		// The Allowed Distance for Causing Damage
//
//	RaycastHit Hit;					// Raycast Get
//
//	public GameObject TheBullet;	// Bullet Hole
//	public GameObject TheBlood;		// Blood Splatter
//
//	public int CurrentFirearm = 0;	// Current Firearm in Use

	void Start()
	{
		
	}

	void Update()
	{
//		// if M9
//		if (CurrentFirearm = 1) 
//		{
//			// if magazine ammo is >= 1, Check for Player Shooting, Grab Raycast Data, Check if in range, cause damage to enemy
//			if (GlobalAmmo.LoadedAmmo >= 1) 
//			{
//				// When Shot fired, use raycast..., calculate distance from enemy, if distance is allowed, inflict damage
//				if (Input.GetButtonDown ("Fire1")) 
//				{
//					RaycastHit Shot;
//
//					if (Physics.Raycast (transform.position, transform.TransformDirection (Vector3.forward),out Shot)) 
//					{
//						TargetDistance = Shot.distance;
//
//						if (TargetDistance < AllowedRange) 
//						{
//							//Shot.transform.SendMessage ("DeductPoints", DamageAmount); // (Moved Down)
//
//							if (Physics.Raycast (transform.position, transform.TransformDirection (Vector3.forward), out Hit)) 
//							{
//								// Make Zombie Bleed
//								if(Hit.transform.tag == "Zombie" || Hit.transform.tag == "Boss")
//								{
//									Debug.Log ("Body Hit" + " | " + "MP5K Damage: " + DamageAmount);
//									Instantiate (TheBlood, Hit.point, Quaternion.FromToRotation (Vector3.up, Hit.normal));
//								}
//								// Headshot Zombie01
//								if(Hit.collider.tag == "Zombie01Head" || Hit.collider.tag == "BossHead")
//								{
//									Debug.Log ("Head Hit");
//									DamageAmount = 10;
//									Instantiate (TheBlood, Hit.point, Quaternion.FromToRotation (Vector3.up, Hit.normal));
//								}
//
//								// Make Bullet Hole
//								if (Hit.transform.tag == "untagged") 
//								{
//									Instantiate (TheBullet, Hit.point, Quaternion.FromToRotation (Vector3.up, Hit.normal));
//								}
//							}
//							Shot.transform.SendMessage ("DeductPoints", DamageAmount);
//							DamageAmount = 5;
//						}
//					}
//				}
//			}
//		}
//
//		// if MP5K
//		if (CurrentFirearm = 2) 
//		{
//			// if magazine ammo is >= 1, Check for Player Shooting, Grab Raycast Data, Check if in range, cause damage to enemy
//			if (GlobalAmmo.LoadedAmmo >= 1) 
//			{
//				// When Shot fired, use raycast..., calculate distance from enemy, if distance is allowed, inflict damage
//				if (Input.GetButtonDown ("Fire1")) 
//				{
//					RaycastHit Shot;
//
//					if (Physics.Raycast (transform.position, transform.TransformDirection (Vector3.forward),out Shot)) 
//					{
//						TargetDistance = Shot.distance;
//
//						if (TargetDistance < AllowedRange) 
//						{
//							//Shot.transform.SendMessage ("DeductPoints", DamageAmount); // (Moved Down)
//
//							if (Physics.Raycast (transform.position, transform.TransformDirection (Vector3.forward), out Hit)) 
//							{
//								// Make Zombie Bleed
//								if(Hit.transform.tag == "Zombie" || Hit.transform.tag == "Boss")
//								{
//									Debug.Log ("Body Hit" + " | " + "MP5K Damage: " + DamageAmount);
//									Instantiate (TheBlood, Hit.point, Quaternion.FromToRotation (Vector3.up, Hit.normal));
//								}
//								// Headshot Zombie01
//								if(Hit.collider.tag == "Zombie01Head" || Hit.collider.tag == "BossHead")
//								{
//									Debug.Log ("Head Hit");
//									DamageAmount = 10;
//									Instantiate (TheBlood, Hit.point, Quaternion.FromToRotation (Vector3.up, Hit.normal));
//								}
//
//								// Make Bullet Hole
//								if (Hit.transform.tag == "untagged") 
//								{
//									Instantiate (TheBullet, Hit.point, Quaternion.FromToRotation (Vector3.up, Hit.normal));
//								}
//							}
//							Shot.transform.SendMessage ("DeductPoints", DamageAmount);
//							DamageAmount = 5;
//						}
//					}
//				}
//			}
//		}
	}
}
