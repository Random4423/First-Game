using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponPickup : MonoBehaviour 
{
	// Variables

	//Real Guns
	public GameObject Gun01;
	public GameObject Gun02;
	//public GameObject Gun03;

	// Display Guns
	public GameObject DGun01;
	public GameObject DGun02;

	public float TheDistance = PlayerCasting.DistanceFromTarget;
	public GameObject TextDisplay;

	public AudioSource PickUpAudio;

	public GameObject TypeDisplay;

	// --------------------------------------------------------------

	void Update()
	{
		TheDistance = PlayerCasting.DistanceFromTarget;
	}


	//TRASH THIS


	//pickup 9mm
	// disable 9mm






}
