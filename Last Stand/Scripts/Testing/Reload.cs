using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reload : MonoBehaviour 
{
	// Variables
	public AudioSource ReloadSound;		// Reload Sound
	public GameObject RecticleObject;	// For Disabling Recticle
	public GameObject MechanicsObject;	// For Disabling Mechanics
	public int MagCount;				// [Internal] Magazine Count
	public int ReserveCount;			// [Internal] Reserve Ammo
	public int ReloadAvailable;			// [Internal] Available ammo to load into Magazine (Used to Fill Mag)
	GunFire GunComponent;				// [Internal] Controls Gunfire Component

	// New
	public int CurrentWeapon = 0;			// Take into account current weapon in hand / initialized to 0 (No Weapon)

	// [START] -
	void Start () 
	{
		GunComponent = GetComponent<GunFire> ();	// Assign GunComponent access of GunFire Component
	}





	// [UPDATE] -
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
			if (CurrentWeapon == 1) 
			{
				ReloadAvailable = 10 - MagCount;
			}
			if (CurrentWeapon == 2) {
				ReloadAvailable = 30 - MagCount;
			}
		}



	}







	// [ENABLE SCRIPTS] - 
	IEnumerator EnableScripts ()
	{
		yield return new WaitForSeconds (1.1f);	// Wait
		GunComponent.enabled = true;			// Enable GunComponent
		RecticleObject.SetActive (true);		// Enable Recticle
		MechanicsObject.SetActive (true);		// Enable Mechanics
	}

	// [ACTION RELOAD] -
	void ActionReload()
	{
		GunComponent.enabled = false;						// Disable GunComponent
		RecticleObject.SetActive (false);					// Disable Recticle
		MechanicsObject.SetActive (false);					// Disable Mechanics
		ReloadSound.Play ();								// Play Reload Sound
		GetComponent<Animation> ().Play ("HandgunReload");	// Play Reload Animations
	}
}
