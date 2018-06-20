using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour 
{
	public int CurrentHealth;
	public int FullHealth = 100;
	public int HealthCalc;
	public AudioSource HealthUp;
    //PickupManager HealthFlag;

	void Update()
	{
		CurrentHealth = GlobalHealth.PlayerHealth;
		HealthCalc = FullHealth - CurrentHealth;
	}
	
	// On Health Pickup
	void OnTriggerEnter (Collider other) 
	{
		if (CurrentHealth < 100 && CurrentHealth > 0) 
		{
			if (CurrentHealth > 80) {
				HealthUp.Play ();
				this.gameObject.SetActive (false);
                PickupManager.HealthIsActive = 0;

				GlobalHealth.PlayerHealth += HealthCalc;

			} else {
				HealthUp.Play ();
				this.gameObject.SetActive (false);
                PickupManager.HealthIsActive = 0;
				GlobalHealth.PlayerHealth += 20;
			}
		}
	}
}
