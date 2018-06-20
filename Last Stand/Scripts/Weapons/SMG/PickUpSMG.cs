using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpSMG : MonoBehaviour 
{


	// Variables
	public float TheDistance = PlayerCasting.DistanceFromTarget;	// Gets distance from target
	public GameObject TextDisplay;									// Displays Text 

	public GameObject MP5KDisplay;									// Gun in Scene
	public GameObject MP5K;											// Gun in Hand
	public AudioSource PickUpAudio;									// Pickup Audio

	public GameObject MP5KMechanics;									// MP5K Mechanics

	// Other Guns
	public GameObject M9;
	public GameObject M9Display;
	public GameObject M9Mechanics;

	public GameObject TypeDisplay;									// Display Type Label
	public GameObject Recticle;										// Recticle Object

	//public int InternalWeaponSelected;

	// [UPDATE]
	void Update () 
	{
		TheDistance = PlayerCasting.DistanceFromTarget;				// Get Distance using PlayerCasting, Assign to TheDistance
		//InternalWeaponSelected = GlobalWeaponSelect.WeaponSelected;

	}

	// [ON MOUSE OVER]
	void OnMouseOver()
	{
		// if the distance is less than or equal to 2
		if(TheDistance <= 2)
		{
			TextDisplay.GetComponent<Text>().text = "Take MP5K";			// Display Take MP5K
		}

		// if action button is pressed
		if(Input.GetButtonDown("Action"))
		{
			// if distance is less than or equal to 2
			if(TheDistance <= 2)
			{
				StartCoroutine(TakeMP5K());								// Run TakeMP5K Function

				Recticle.SetActive (true);

				// Disable other mechanics
				M9Mechanics.SetActive(false);

				MP5KMechanics.SetActive (true);								// Enable MP5K Mechanics
				Debug.Log("MP5K Mechanics: " + MP5KMechanics.activeSelf);
			}
		}
	}

	// [ON MOUSE EXIT]
	void OnMouseExit()
	{
		TextDisplay.GetComponent<Text>().text = "";						// Clears the TextDisplay variable
	}

	// [TAKE MP5K] - Function for taking MP5K
	IEnumerator TakeMP5K()
	{
		// Put Gun 01 Away
		M9.SetActive(false);
		M9Display.SetActive (true);

		PickUpAudio.Play ();											// Play Audio

		//transform.position = new Vector3(0, -1000, 0);					// Move Trigger Offscreen
		MP5KDisplay.SetActive (false);									// Disable Display Gun
		TextDisplay.GetComponent<Text>().text = "";						// Clear Text
		MP5K.SetActive (true);											// Enable Real Gun		
		GlobalWeaponSelect.WeaponSelected = 2;
		GlobalAmmo.CurrentAmmo = 60;									// Reserve Ammo
		GlobalAmmo.LoadedAmmo = 30;										// Mag Ammo
		TypeDisplay.GetComponent<Text>().text = "MP5K";					// Display MP5K Label
		yield return new WaitForSeconds (0.1f);							// Wait
	}
}