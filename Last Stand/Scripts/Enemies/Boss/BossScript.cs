using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*	SCRIPT PURPOSE:
 * 		Keep Count of Enemy Health
 * 		If Enemy Dies Play Animation and Destroy Enemy
 * 		> This Script is Only for Boss <
*/

public class BossScript : MonoBehaviour {

	// Variables
	public int EnemyHealth = 60;	// Enemy Health
	public GameObject TheBoss;		// Zombie Variable
	public AudioSource BossDead;	// Boss Dead Sound
    public AudioSource BossHit;     // Boss Hit Sound

	// Function Deducts damage from Enemy Health
	void DeductPoints (int DamageAmount )
	{
        Debug.Log ("Boss Health: " + EnemyHealth);
        //TheBoss.GetComponent<Animation>().Play("creature1GetHit");
        BossHit.Play();
		EnemyHealth -= DamageAmount;

        //if (tag == "BossHead")
        //{
        //    GlobalScore.CurrentScore += 100;
        //}
		if (tag == "Boss") 
		{
			GlobalScore.CurrentScore += 50;
		}

	}

	// If enemy health is less than or equal to 0, destroy enemy
	void Update () 
	{
		if (EnemyHealth <= 0) 
		{
			BossDead.Play ();
			this.GetComponent<BossFollow> ().enabled = false;
			TheBoss.GetComponent<Animation> ().Play ("creature1Die");
			BossDead.Play ();
			//StartCoroutine (BossDying ());
			StartCoroutine (EndBoss ());
		}
	}

	public IEnumerator BossDying ()
	{
		BossDead.Play ();
		yield return new WaitForSeconds (10f);

		//yield return new WaitForSeconds (2f);
	}

	public IEnumerator EndBoss() 
	{
		yield return new WaitForSeconds (0.9f);
		Destroy (gameObject);
	}
}
