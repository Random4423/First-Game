using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*	SCRIPT PURPOSE:
 * 		Play Ammo Pickup Sound
 * 		Add Ammo to selected weapon
*/


public class AmmoPickup : MonoBehaviour 
{

	// Variables
	public AudioSource AmmoSound;	// Ammo Pickup Sound

	public GameObject M9;
	public GameObject SMG;
	public GameObject M4;

	// On Ammo Pickup
	void OnTriggerEnter (Collider other)
	{
		if(M9.activeSelf || SMG.activeSelf || M4.activeSelf)
		{
			// >>> M9 <<<
			if (M9.activeSelf) {
				AmmoSound.Play ();							// Play Sound

				// If Magazine is empty
				if (GlobalAmmo.LoadedAmmo == 0) {
					GlobalAmmo.LoadedAmmo += 10;			// Add 10 Rounds to Mag
					GlobalAmmo.CurrentAmmo += 20;			// Add 20 Rounds to Inventory (2 Mags)
					this.gameObject.SetActive (false);		// Disable Ammo Box
				} else {
					GlobalAmmo.CurrentAmmo += 30;			// Add 30 rounds to Inventory
					this.gameObject.SetActive (false);		// Disable Ammo Box
				}
			} else {
				// >>> SMG <<<
				if (SMG.activeSelf || M4.activeSelf) { 
					AmmoSound.Play (); 						// Play Sound

					// If Magazine is empty
					if (GlobalAmmo.LoadedAmmo == 0) {
						GlobalAmmo.LoadedAmmo += 30;		// Add 30 rounds to Mag
						GlobalAmmo.CurrentAmmo += 60;		// Add 60 Rounds to Inventory (2 Mags)
						this.gameObject.SetActive (false);	// Disable Ammo Box
					} else {
						GlobalAmmo.CurrentAmmo += 90;		// Add 90 rounds to Inventory
						this.gameObject.SetActive (false);	// Disable Ammo Box
					}
				}// else // >>> M4 <<< (currently not in use)
				//{
				//	AmmoSound.Play (); 						// Play Sound

				//	// If Magazine is empty
				//	if (GlobalAmmo.LoadedAmmo == 0) 
				//	{
				//		GlobalAmmo.LoadedAmmo += 0;			// Add 0 rounds to Mag
				//		this.gameObject.SetActive (false);	// Disable Ammo Box
				//	} else 
				//	{
				//		GlobalAmmo.CurrentAmmo += 0;		// Add 0 rounds to Inventory
				//		this.gameObject.SetActive (false);	// Disable Ammo Box
				//	}
				//}
			}
		}
	}
}
// ----------------------------------NOTES----------------------------------
// Loaded Ammo: Ammo in Magazine (Ready to Shoot)
// Current Ammo: Ammo in Reserve (Extra Ammo you Carry)