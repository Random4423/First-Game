using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrenadesPickup : MonoBehaviour 
{
	// Variables
	public AudioSource GrenadePickupSound;								// Sound when picking up grenades

	void OnTriggerEnter(Collider other)
	{
		if (GlobalAmmo.GrenadeCount == 0) 
		{
			GrenadePickupSound.Play ();
			GlobalAmmo.GrenadeCount += 6;
            //this.gameObject.SetActive (false);
            PickupManager.GrenadeIsActive = 0;
            Destroy(gameObject);
		}
	}



}
