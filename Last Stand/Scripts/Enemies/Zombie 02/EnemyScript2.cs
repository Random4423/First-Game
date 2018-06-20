using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*	SCRIPT PURPOSE:
 * 		Keep Count of Enemy Health
 * 		If Enemy Dies Play Animation and Destroy Enemy
 * 		> This Script is Only for Zombie 2 <
*/
public class EnemyScript2 : MonoBehaviour {


	// Variables
	public int EnemyHealth = 10;	// Enemy Health
	public GameObject TheZombie2;	// Zombie Variable


	// Function Deducts damage from Enemy Health
	void DeductPoints (int DamageAmount )
	{
		EnemyHealth -= DamageAmount;
		if (tag == "Zombie") 
		{
			GlobalScore.CurrentScore += 50;
		}
	}

	// If enemy health is less than or equal to 0, destroy enemy
	void Update () 
	{
		if (EnemyHealth <= 0) 
		{
			this.GetComponent<ZombieFollow2> ().enabled = false;
			TheZombie2.GetComponent<Animation> ().Play ("back_fall");

			StartCoroutine (EndZombie ());
		}
	}

	public IEnumerator EndZombie() 
	{
		yield return new WaitForSeconds (1);
		Destroy (gameObject);
	}
}
