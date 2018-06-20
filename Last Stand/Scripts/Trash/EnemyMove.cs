using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*	SCRIPT PURPOSE:  * 		(Might Be trash) for Tutorial Testing */

public class EnemyMove : MonoBehaviour {

	// Variables
	public GameObject ThePlayer;	// Player Variable
	public GameObject TheEnemy;		// Enemy Variable
	public float EnemySpeed;		// Enemy Speed
	public int MoveTrigger;			// Activates move toward player

	void Update () 
	{
		if (MoveTrigger == 1) 
		{
			// Set enemy move speed
			EnemySpeed = 0.02f;

			// Move toward the player
			//transform.position = Vector3.MoveTowards (transform.position, ThePlayer.transform.position, EnemySpeed);
		}
	}
}
