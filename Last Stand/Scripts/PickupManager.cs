using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupManager : MonoBehaviour 
{

    // Variables
    public float spawnTime = 10f;

    // Health
    public GameObject HealthPickup;
    public Transform HealthDrop;
    public static int HealthIsActive = 0;
    public int InternalHealthIsActive;


    // Ammo
    //public GameObject AmmoPickup;
    //public Transform AmmoDrop;
    //public static int AmmoIsActive = 0;
    //public int InternalAmmoIsActive;

 
    // Grenades
    public GameObject GrenadePickup;
    public Transform GrenadeDrop;
    public static int GrenadeIsActive = 0;
    public int InternalGrenIsActive;



	void Start () 
    {
        InvokeRepeating("Spawn", spawnTime, spawnTime);
	}

	void Update()
	{
        InternalHealthIsActive = HealthIsActive;
        //InternalAmmoIsActive = AmmoIsActive;
        InternalGrenIsActive = GrenadeIsActive;
	}

    void Spawn()
    {
        // Player Dead
        if (GlobalHealth.PlayerHealth <= 0)
        {
            return;
        }

        // Drop Health
        if (HealthIsActive == 0)
        {
            Instantiate(HealthPickup, HealthDrop.position, HealthDrop.rotation);
            HealthIsActive = 1;
        }

        // Drop Ammo
        //if (AmmoIsActive == 0)
        //{
        //    Instantiate(AmmoPickup, AmmoDrop.position, AmmoDrop.rotation);
        //    AmmoIsActive = 1; 
        //}

        // Drop Grenades
        if(GrenadeIsActive == 0)
        {
            Instantiate(GrenadePickup, GrenadeDrop.position, GrenadeDrop.rotation);
            GrenadeIsActive = 1;
        }
    }
}
