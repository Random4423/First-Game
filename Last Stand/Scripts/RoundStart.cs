using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundStart : MonoBehaviour 
{
	// Variables
	public AudioSource RoundSound;      // Round Start Sound
	public GameObject RoundText;        // Round Text
	public AudioSource BGSound;         // Background Music
	public GameObject ScreenFlash2;     // Screen Flash
	public int RoundNum = 1;            // Round Number

    // Enemy Stuff
    //public int enemySelect;             // Random Number to select enemy
    //public GameObject Zombie01;         // Zombie 01
    //public GameObject Zombie02;         // Zombie 02
    //public GameObject Boss;             // Boss
    //public GameObject enemy;             // The enemy prefab to be spawned.
    //public float spawnTime = 3f;        // How long between each spawn.
    //public Transform[] spawnPoints;     // An array of the spawn points this enemy can spawn from.

	//public int spawnedEnemies;         // holds the amount of spawned that have been spawned
	//public int roundTime;              // time per round


	//void Start()
	//{
 //       InvokeRepeating("Spawn", spawnTime, spawnTime);
	//}

	//void Update()
	//{
 //       enemySelect = Random.Range(1, 2);

 //       if(enemySelect == 1)
 //       {
 //           enemy = Zombie01;
 //       }
 //       if(enemySelect == 2)
 //       {
 //           enemy = Zombie02;
 //       }

 //       Spawn();
	//}

	public void StartRound()
	{
		ScreenFlash2.SetActive (true);

		RoundSound.Play ();

		RoundText.GetComponent<Text> ().text = "Round: " + RoundNum;

		ScreenFlash2.GetComponent<Animation> ().Play ();

		StartCoroutine (BGMusic ());

		//ScreenFlash.SetActive (false);

		RoundNum++;
	}

	public IEnumerator BGMusic()
	{
		yield return new WaitForSeconds (5f);
		BGSound.Play ();
	}

    // Spawning Enemies
    //void AddEnemy()
    //{
        
    //}

    //void Spawn ()
    //{
    //    int spawnPointIndex = Random.Range(0, spawnPoints.Length);
    //    Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
    //}
}
