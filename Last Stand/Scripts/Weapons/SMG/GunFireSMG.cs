using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunFireSMG : MonoBehaviour {

	// Variables
	public GameObject TheSMG;			// SMG GameObject
	public AudioSource SMGSound;		// SMG Audio
	public GameObject MuzzleFlash;		// SMG MuzzleFlash
	public int AmmoCount;				// Current Magazine Ammo Count
	public int Firing;					//

	public GameObject UpCurs;			// Up Recticle
	public GameObject DownCurs;			// Down Recticle
	public GameObject LeftCurs;			// Left Recticle
	public GameObject RightCurs;		// Right Recticle

	// UPDATE SCRIPT
	void Update () 
	{
		AmmoCount = GlobalAmmo.LoadedAmmo;	// Get Current Magazine Ammo Count

		// If Fire Button Pressed
		if (Input.GetButton ("Fire1")) 
		{
			// If Ammo Count is Greater than or Equal to 1
			if (AmmoCount >= 1) 
			{
				// If not Firing
				if(Firing == 0)
				{
					StartCoroutine(SMGFire ());	// Run SMGFire Script
				}
			}
		}
	}

	// SMG FIRING SCRIPT
	IEnumerator SMGFire()
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

		TheSMG.GetComponent<Animator>().enabled = true;			// Enable SMG Animations

		yield return new WaitForSeconds(0.1f);					// Wait

		MuzzleFlash.SetActive(false);							// Disable Muzzle Flash

		TheSMG.GetComponent<Animator>().enabled = false;		// Disable SMG Animations

		// Disable Recticle Animations
		UpCurs.GetComponent<Animator>().enabled = false;
		DownCurs.GetComponent<Animator>().enabled = false;
		LeftCurs.GetComponent<Animator>().enabled = false;
		RightCurs.GetComponent<Animator>().enabled = false;

		Firing = 0;												// Weapon is not Firing
	}

}
