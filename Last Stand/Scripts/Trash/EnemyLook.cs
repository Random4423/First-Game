using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLook : MonoBehaviour 
{

	// Might Be trash for tutorial testing

	// Variables
	public GameObject ThePlayer;	// Player Variable


	void Update () 
	{
		transform.LookAt (ThePlayer.transform);
	}
}
