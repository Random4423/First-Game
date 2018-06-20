using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCasting : MonoBehaviour {

	// Variables
	public static float DistanceFromTarget;	// Hold distance from target
	public float ToTarget;					// To handle target distance internally

	void Update () 
	{
		RaycastHit hit;						// 


		// if ... assign hit distance to ToTarget, assign ToTarget to DistanceFromTarget
		if (Physics.Raycast (transform.position, transform.TransformDirection (Vector3.forward), out hit)) 
		{
			ToTarget = hit.distance;
			DistanceFromTarget = ToTarget;
		}
	}
}