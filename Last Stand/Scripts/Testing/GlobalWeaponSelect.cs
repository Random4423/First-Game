using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*	SCRIPT PURPOSE:
 * 		The Purpose of this script is to keep tabs on which weapon is being used.
*/
public class GlobalWeaponSelect : MonoBehaviour 
{
	// Variables
	//public GameObject M9;
	//public GameObject MP5K;

	//public GameObject M9Display;
	//public GameObject MP5KDisplay;

	public static int WeaponSelected;

	//	Weapon Selection:
	// Nothing = 0
	// M9 = 1
	// MP5K = 2
	// AR15 = 3


//	void Update()
//	{
//		if(WeaponSelected == 1)
//		{
//			
//		}
//		if(WeaponSelected == 2)
//		{
//
//		}
//	}











//	void Update () 
//	{
//		if (M9.activeSelf) 
//		{
//			WeaponSelected = 1;
//
//			// disable other weapons
//			MP5K.SetActive(false);
//			// place displays back
//			M9Display.SetActive(true);
//
//		}
//		if (MP5K.activeSelf) 
//		{
//			WeaponSelected = 2;
//
//			// disable other weapons
//			M9.SetActive(false);
//			// place displays back
//			MP5KDisplay.SetActive(true);
//
//		} //else 
//		{
//			WeaponSelected = 0;

//		}

//		DisableFirearms ();
//
//		PutBackFirearms ();

//		if(WeaponSelected == 1)
//		{
//			Debug.Log ("Weapon Selected: M9");
//			Debug.Log ("Selected Value:  " + WeaponSelected);
//		}
//
//		if(WeaponSelected == 2)
//		{
//			Debug.Log ("Weapon Selected: MP5K");
//			Debug.Log ("Selected Value:  " + WeaponSelected);
//		}
			
//	}
		
//	public void DisableFirearms()
//	{
//		if (WeaponSelected == 1) 
//		{
//			MP5K.SetActive (false);
//		}
//		if (WeaponSelected == 2) 
//		{
//			M9.SetActive (false);
//		}
//	}
//	public void PutBackFirearms()
//	{
//		if (WeaponSelected == 1) 
//		{
//			MP5KDisplay.SetActive (true);
//		}
//		if (WeaponSelected == 2) 
//		{
//			M9Display.SetActive (true);
//		}
//	}
}
