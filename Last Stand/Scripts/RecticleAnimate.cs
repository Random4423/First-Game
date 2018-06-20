using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecticleAnimate : MonoBehaviour {

	// Variables
	public GameObject UpRecticle;		// Up Recticle
	public GameObject DownRecticle;		// Down Recticle
	public GameObject LeftRecticle;		// Left Recticle
	public GameObject RightRecticle;	// Right Recticle

	// UPDATE SCRIPT
	void Update () 
	{
		// if Magazine ammo greater than or equal to 1
		if (GlobalAmmo.LoadedAmmo >= 1) 
		{
			// If Fire Button Pressed
			if(Input.GetButtonDown("Fire1"))
			{
				UpRecticle.GetComponent<Animator>().enabled = true;		// Enable Up Recticle
				DownRecticle.GetComponent<Animator>().enabled = true;	// Enable Down Recticle
				LeftRecticle.GetComponent<Animator>().enabled = true;	// Enable Left Recticle
				RightRecticle.GetComponent<Animator>().enabled = true;	// Enable Right Recticle
				StartCoroutine(WaitingAnim());							// Run WaitingAnim Script
			}
		}
	}

	// DISABLE RECTICLE SCRIPT
	IEnumerator WaitingAnim()
	{
		yield return new WaitForSeconds(0.1f);					// Wait
		UpRecticle.GetComponent<Animator>().enabled = false;	// Disable Up Recticle
		DownRecticle.GetComponent<Animator>().enabled = false;	// Disable Down Recticle
		LeftRecticle.GetComponent<Animator>().enabled = false;	// Disable Left Recticle
		RightRecticle.GetComponent<Animator>().enabled = false;	// Disable Right Recticle
	}

}