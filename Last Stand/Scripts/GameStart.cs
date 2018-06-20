using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStart : MonoBehaviour 
{
	public GameObject MiniMap;			                // Mini Map
	public GameObject M9Mechanics;                      // M9 Mechanics
	public GameObject MP5KMechanics;                    // MP5K Mechanics
    public GameObject M4Mechanics;                      // M4 Mechanics
	public GameObject Recticle;			                // Recticle Object
	public GameObject WeaponType;		                // Weapon Label
	public GameObject RStart;                           // Round Start Object
	public GameObject ScreenFlash;                      // Screen Flash

    //public GameObject Effects;

	void Start () 
	{
		RStart.GetComponent<RoundStart>().StartRound(); // Run Round Start Function
		GlobalScore.CurrentScore = 0;				    // Reset Score to 0
		GlobalHealth.PlayerHealth = 100;			    // Reset Health to 100
		GlobalAmmo.CurrentAmmo = 0;					    // Reset Reserve Ammo to 0
		GlobalAmmo.LoadedAmmo = 0;					    // Reset Magazine Ammo to 0
        GlobalAmmo.GrenadeCount = 0;                    // Reset Grenades to 0
		Recticle.SetActive (false);					    // Disable Recticle
		WeaponType.GetComponent<Text>().text = "";	    // Reset Weapon Type
		DisableMechanics ();						    // Disable Firearm Mechanics
		StartCoroutine (MapStart ());				    // Start Mini Map (Delayed)
		StartCoroutine(DisableScreen());
	}

    //void Update()
    //{
    //    Effects = GameObject.FindGameObjectWithTag("Effect");

    //    if (Effects)
    //    {
    //        StartCoroutine(DestroyEffects());
    //    }
    //}

	IEnumerator MapStart()
	{
		yield return new WaitForSeconds (1.5f);
		MiniMap.SetActive (true);

	}

	void DisableMechanics()
	{
		M9Mechanics.SetActive (false);
		MP5KMechanics.SetActive (false);
        M4Mechanics.SetActive(false);
	}
	IEnumerator DisableScreen()
	{
		yield return new WaitForSeconds (2f);
		ScreenFlash.SetActive (false);
	}

    //public IEnumerator DestroyEffects()
    //{
    //    yield return new WaitForSeconds(5f);
    //    Destroy(Effects);
    //}
}
