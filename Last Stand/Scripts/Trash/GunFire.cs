using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Gunfire script for FPS

public class GunFire : MonoBehaviour 
{

	// Variables
	AudioSource m9Sound; 		// Sound for M9
	public GameObject Flash;	// Control Flash


	void Update () 
	{
		// if Magazine ammo is >= 1, Check for Player Shooting, Run Shooting Process
		if (GlobalAmmo.LoadedAmmo >= 1) 
		{
			// If shot fired, play sound, animate weapon, Remove 1 round from magazine
			if (Input.GetButtonDown ("Fire1")) 
			{
				m9Sound = GetComponent<AudioSource>();

				m9Sound.Play();

				Flash.SetActive (true);

				StartCoroutine (MuzzleOff ());

				GetComponent<Animation>().Play("GunShots");

				GlobalAmmo.LoadedAmmo -= 1;
			}
		}
	}

	// Turn Off Flash Animation Function
	public IEnumerator MuzzleOff()
	{
		yield return new WaitForSeconds (0.1f);
		Flash.SetActive (false);
	}
}
