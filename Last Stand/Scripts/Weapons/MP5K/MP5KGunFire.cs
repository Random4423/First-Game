using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MP5KGunFire : MonoBehaviour {

	// Variables
	public GameObject MP5K;			                            // MP5K GameObject
	public AudioSource SMGSound;	                        	// MP5K Audio
	public GameObject MuzzleFlash;	                        	// MP5K MuzzleFlash
	public int AmmoCount;				                        // Current Magazine Ammo Count
	public int Firing;				                        	// Firing Flag

	public GameObject UpCurs;		                        	// Up Recticle
	public GameObject DownCurs;		                        	// Down Recticle
	public GameObject LeftCurs;		                        	// Left Recticle
	public GameObject RightCurs;		                        // Right Recticle

    public GameObject MP5KMechanics;

	// UPDATE SCRIPT
	void Update () 
	{
		AmmoCount = GlobalAmmo.LoadedAmmo;	                    // Get Current Magazine Ammo Count

		// If Fire Button Pressed
		if (Input.GetButton ("Fire1")) 
		{
			// If Ammo Count is Greater than or Equal to 1
			if (AmmoCount >= 1) 
			{
				// If not Firing
				if(Firing == 0)
				{
					StartCoroutine(MP5KFire ());	            // Run SMGFire Script
				}
			}
		}
	}

	// SMG FIRING SCRIPT
	IEnumerator MP5KFire()
	{
		Firing = 1;												// Weapon is Firing

		// Enable Recticle Animations
		UpCurs.GetComponent<Animator>().enabled=true;
		DownCurs.GetComponent<Animator>().enabled=true;
		LeftCurs.GetComponent<Animator>().enabled=true;
		RightCurs.GetComponent<Animator>().enabled=true;

		GlobalAmmo.LoadedAmmo -= 1;								// Subtract 1 Round from Magazine


		SMGSound.Play();										// Play SMG Sound

		MuzzleFlash.SetActive(true);							// Activate Muzzle Flash

        MP5K.GetComponent<Animation>().Play("MP5KShot");	    // Enable SMG Animations

        // CAUSE ENEMY DAMAGE SHOULD GO HERE
        //MP5K.GetComponent<MP5KDamage>().CauseDamage();
        MP5KMechanics.GetComponent<MP5KDamage>().FullAuto = 1;
        //MP5KMechanics.GetComponent<MP5KDamage>().FullAutoDamage();

		yield return new WaitForSeconds(0.1f);					// Wait

		MuzzleFlash.SetActive(false);							// Disable Muzzle Flash

        MP5K.GetComponent<Animation>().Stop("MP5KShot");        // Disable SMG Animations

		// Disable Recticle Animations
		UpCurs.GetComponent<Animator>().enabled = false;
		DownCurs.GetComponent<Animator>().enabled = false;
		LeftCurs.GetComponent<Animator>().enabled = false;
		RightCurs.GetComponent<Animator>().enabled = false;

		Firing = 0;												// Weapon is not Firing
        MP5KMechanics.GetComponent<MP5KDamage>().FullAuto = 0;
	}

}