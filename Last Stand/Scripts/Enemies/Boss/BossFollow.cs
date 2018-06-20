using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*	SCRIPT PURPOSE:
 * 		For Boss
 *		Make Zombie follow the player
 * 		Allow Zombie to Attack the Player
 * 		Cause Damage to the Player
*/

public class BossFollow : MonoBehaviour {

	// Variables
	public GameObject ThePlayer;	// Player Variable
	public float TargetDistance;	// Distance
	public float AllowedRange = 20;	// Allowed Range
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

    public AudioSource Roar;        // Spawn Roar
    public int isSpawning = 1;      // Flag for when boss is spawned

	void Start()
	{
        StartCoroutine(BossSpawn());
	}

	void Update () 
    {
        if (isSpawning == 0)
        {
            // Look at the Player
            transform.LookAt(ThePlayer.transform);

            // If 
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out Shot))
            {
                // Assign Shot Distance to Target Distance
                TargetDistance = Shot.distance;

                if (TargetDistance < AllowedRange)
                {
                    EnemySpeed = 0.7f;

                    // walking
                    if (AttackTrigger == 0)
                    {
                        TheEnemy.GetComponent<Animation>().Play("creature1walkforward");
                        transform.position = Vector3.MoveTowards(transform.position, ThePlayer.transform.position, EnemySpeed * Time.deltaTime);
                    }
                    // idle
                }
                else
                {
                    EnemySpeed = 0;
                    TheEnemy.GetComponent<Animation> ().Play ("creature1Idle");
                }
            }
            // attack
            if (AttackTrigger == 1)
            {
                if (IsAttacking == 0)
                {
                    StartCoroutine(EnemyDamage());
                }

                EnemySpeed = 0;
                TheEnemy.GetComponent<Animation>().Play("creature1Attack1");
            }
        }
	}

	void OnTriggerEnter() {
		AttackTrigger = 1;
	}

	void OnTriggerExit(){
		AttackTrigger = 0;
	}

	// Enemy Damages Player
	IEnumerator EnemyDamage() 
	{
		IsAttacking = 1;
		PainSound = Random.Range (1, 4);
		yield return new WaitForSeconds (0.1f);
		ScreenFlash.SetActive (true);
		GlobalHealth.PlayerHealth -= 15;
		//Hurt01.Play();
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

   public IEnumerator BossSpawn()
    {
        yield return new WaitForSeconds(1f);
        TheEnemy.GetComponent<Animation>().Play("creature1roar");
        Roar.Play();
        yield return new WaitForSeconds(3f);
        isSpawning = 0;
    }
}
