using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandgunReloading : MonoBehaviour 
{

	// Variables
	public AudioSource ReloadSound;		// Reload Sound
	public GameObject RecticleObject;	// For Disabling Recticle
	public GameObject MechanicsObject;	// For Disabling Mechanics
	public int MagCount;				// [Internal] Magazine Count
	public int ReserveCount;			// [Internal] Reserve Ammo
	public int ReloadAvailable;			// [Internal] Available ammo to load into Magazine (Used to Fill Mag)
	GunFire GunComponent;				// [Internal] Controls Gunfire Component



	void Start () 
	{
		GunComponent = GetComponent<GunFire> ();	// Assign GunComponent access of GunFire Component
	}
	

	void Update () 
	{
		MagCount = GlobalAmmo.LoadedAmmo;		// Get Magazine Count
		ReserveCount = GlobalAmmo.CurrentAmmo;	// Get Reserve Ammo Count

		// IF reserve = 0, no reloads available
		if (ReserveCount == 0) 
		{
			ReloadAvailable = 0;
		} else // ELSE ReloadAvailable = 10 minus Magcount
		{
			ReloadAvailable = 10 - MagCount;
		}


		// IF player presses reload
		if (Input.GetButtonDown ("Reload")) 
		{
			// if ReloadAvailable is greater or equal to 1 
			if (ReloadAvailable >= 1) 
			{
				// If ReserveCount is less than or equal to ReloadAvailable
				if (ReserveCount <= ReloadAvailable) 
				{
					GlobalAmmo.LoadedAmmo += ReserveCount;
					GlobalAmmo.CurrentAmmo -= ReserveCount;
					ActionReload ();
				} else
				{
					GlobalAmmo.LoadedAmmo += ReloadAvailable;
					GlobalAmmo.CurrentAmmo -= ReloadAvailable;
					ActionReload ();
				}
			}
			// RUN EnableScripts()
			StartCoroutine (EnableScripts ());
		}
	}

	// ENABLE SCRIPTS FUNCTION
	IEnumerator EnableScripts ()
	{
		yield return new WaitForSeconds (1.1f);	// Wait
		GunComponent.enabled = true;			// Enable GunComponent
		RecticleObject.SetActive (true);		// Enable Recticle
		MechanicsObject.SetActive (true);		// Enable Mechanics
	}
		
	// RELOAD FUNCTION
	void ActionReload()
	{
		GunComponent.enabled = false;						// Disable GunComponent
		RecticleObject.SetActive (false);					// Disable Recticle
		MechanicsObject.SetActive (false);					// Disable Mechanics
		ReloadSound.Play ();								// Play Reload Sound
		GetComponent<Animation> ().Play ("HandgunReload");	// Play Reload Animations
	}

}