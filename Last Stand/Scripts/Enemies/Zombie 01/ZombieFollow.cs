using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*	SCRIPT PURPOSE:
 * 		Make Zombie follow the player
 * 		Allow Zombie to Attack the Player
 * 		Cause Damage to the Player
*/

public class ZombieFollow : MonoBehaviour {

	// Variables
	public GameObject ThePlayer;	// Player Variable
	public float TargetDistance;	// Distance
	public float AllowedRange = 50;	// Allowed Range
	public GameObject TheEnemy;		// Enemy Variable
	public float EnemySpeed;		// Enemy Speed
	public int AttackTrigger;		// Triggers Attack
	public RaycastHit Shot;			// Detects Hit

	public int IsAttacking;			// Attacking flag
	public GameObject ScreenFlash;	// Flash Screen
	public AudioSource Hurt01;		// Hurt Sound 01
	public AudioSource Hurt02;		// Hurt Sound 02
	public AudioSource Hurt03;		// Hurt Sound 03
	public int PainSound;			// Random number for hurt sound

	void Update () {
		// Look at the Player
		transform.LookAt (ThePlayer.transform);

		// If 
		if (Physics.Raycast (transform.position, transform.TransformDirection (Vector3.forward), out Shot)) 
		{
			
			// Assign Shot Distance to Target Distance
			TargetDistance = Shot.distance;
			// if enemy is not in range of player, enemy walk
			if (TargetDistance < AllowedRange) {
				EnemySpeed = 0.8f;

				// if enemy is not in attacking range, enemy walk toward player
				if (AttackTrigger == 0) {
					TheEnemy.GetComponent<Animation> ().Play ("Walking");
					transform.position = Vector3.MoveTowards (transform.position, ThePlayer.transform.position, EnemySpeed * Time.deltaTime);
				}
			} else { // else, enemy stop wallking remain idle
				EnemySpeed = 0;
				TheEnemy.GetComponent<Animation> ().Play ("Idle");
			}
		}
		// if enemy is in attacking range stop walking, run script
		if (AttackTrigger == 1) 
		{
			// if not attacking, run script
			if (IsAttacking == 0) 
			{
				StartCoroutine (EnemyDamage ());
			}

			EnemySpeed = 0;
			TheEnemy.GetComponent<Animation> ().Play ("Attacking");
		}
	}

	// When Enemy ...
	void OnTriggerEnter() {

            AttackTrigger = 1;
	}

	void OnTriggerExit(){
		AttackTrigger = 0;
	}


	IEnumerator EnemyDamage() 
	{
		// Activate Attacking
		// Select Random Damage Sound
		// Flash Damage Red
		// Take Damage from Player
		// Return to Normal
		IsAttacking = 1;
		PainSound = Random.Range (1, 4);
		yield return new WaitForSeconds (0.9f);
		ScreenFlash.SetActive (true);
		GlobalHealth.PlayerHealth -= 5;

		if (PainSound == 1) 
		{
			Hurt01.Play ();
		}
		if (PainSound == 2) 
		{
			Hurt02.Play ();
		}
		if (PainSound == 3) 
		{
			Hurt03.Play ();
		}

		yield return new WaitForSeconds (0.05f);
		ScreenFlash.SetActive (false);
		yield return new WaitForSeconds (1);
		IsAttacking = 0;
	}
}
