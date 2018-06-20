using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;	// Required for UI Use

public class GlobalAmmo : MonoBehaviour {

	// Variables
	public static int CurrentAmmo; 		// Ammo Currently in Reserve
	public int InternalAmmo;       		// Local Copy of Ammo Currently in Reserve
	public GameObject AmmoDisplay; 		// Displays Reserve Ammo

	public static int LoadedAmmo; 		// Ammo Currently in Magazine
	public int InternalLoaded;			// Local Copy of Ammo Currently in Magazine
	public GameObject LoadedDisplay;	// Displays Magazine Ammo

	public static int GrenadeCount;		// Amount of Available Grenades
	public int InternalGrenade;		// Internal Grenade Variable
	public GameObject GrenadeDisplay;	// Displays Grenade Count

	void Update () 
	{
		InternalAmmo = CurrentAmmo;   								// Get Reserve Ammo Count
		InternalLoaded = LoadedAmmo;								// Get Magazine Ammo Count
		AmmoDisplay.GetComponent<Text> ().text = "" + InternalAmmo;	// Display Reserve Ammo
		LoadedDisplay.GetComponent<Text> ().text = "" + LoadedAmmo;	// Display Magazine Ammo

		InternalGrenade = GrenadeCount;
		GrenadeDisplay.GetComponent<Text> ().text = "" + InternalGrenade;
	}
}
