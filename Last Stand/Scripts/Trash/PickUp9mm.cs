using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*	SCRIPT PURPOSE:
 * 		Pick Up 9mm Pistol
 * 		Drop Ammo on Weapon Pickup
*/

public class PickUp9mm : MonoBehaviour 
{

	// Variables
	public float TheDistance = PlayerCasting.DistanceFromTarget;	// Gets distance from target
	public GameObject TextDisplay;									// Displays Text 

	public GameObject M9Display;									// Gun in Scene
	public GameObject M9;											// Gun in Hand
	public AudioSource PickUpAudio;									// Pickup Audio
	public GameObject M9Mechanics;									// M9 Mechanics

	// Other Guns
	public GameObject MP5K;											// MP5K
	public GameObject MP5KDisplay;									// Display MP5K
	public GameObject MP5KMechanics;								// MP5K Mechanics

	public GameObject TypeDisplay;									// Display Type Label
	public GameObject Recticle;										// Recticle Object

	// [UPDATE]
	void Update () 
	{
		// update distance and assign to variable
		TheDistance = PlayerCasting.DistanceFromTarget;
	}

	// [ON MOUSE OVER]
	void OnMouseOver()
	{
		// if the distance is lessthan or equal to 2, display message to get gun
		if(TheDistance <= 2)
		{
			TextDisplay.GetComponent<Text>().text = "Take M9";
		}

		// if action button is pressed and if the distance is lessthan or equal to 2, run TakeNineMill Function
		if(Input.GetButtonDown("Action"))
		{
			if(TheDistance <= 2)
			{
				StartCoroutine(TakeNineMil());

				Recticle.SetActive (true);

				// Disable Other Mechanics
				MP5KMechanics.SetActive(false);

				M9Mechanics.SetActive (true);
				Debug.Log("M9 Mechanics: " + M9Mechanics.activeSelf);
			}
		}
	}

	// [ON MOUSE EXIT]
	void OnMouseExit()
	{
		// Clears the TextDisplay variable
		TextDisplay.GetComponent<Text>().text = "";
	}

	// [TAKE 9MM] - Function for taking 9mm pistol
	IEnumerator TakeNineMil()
	{
		// Put gun 02 away
		MP5K.SetActive(false);
		MP5KDisplay.SetActive (true);

	
		PickUpAudio.Play ();								// Play Audio
		//transform.position = new Vector3(0, -1000, 0);		// Move Trigger Offscreen
		M9Display.SetActive (false);						// Disable Display Gun
		TextDisplay.GetComponent<Text>().text = "";			// Clear Text
		M9.SetActive (true);								// Enable Real Gun
		GlobalWeaponSelect.WeaponSelected = 1;				// Make Selection
		GlobalAmmo.CurrentAmmo = 20;						// Reserve Ammo
		GlobalAmmo.LoadedAmmo = 10;							// Mag Ammo
		TypeDisplay.GetComponent<Text>().text = "M9";		// Display 9mm Label
		yield return new WaitForSeconds (0.1f);				// Wait
	}
}