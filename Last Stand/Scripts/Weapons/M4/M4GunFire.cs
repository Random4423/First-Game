using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M4GunFire : MonoBehaviour 
{
    // Variables
    public GameObject M4;                                     // M4 GameObject
    public AudioSource M4Sound;                                // M4 Audio
    public GameObject MuzzleFlash;                              // M4 MuzzleFlash
    public int AmmoCount;                                       // Current Magazine Ammo Count
    public int Firing;                                          // Firing Flag

    public GameObject UpCurs;                                   // Up Recticle
    public GameObject DownCurs;                                 // Down Recticle
    public GameObject LeftCurs;                                 // Left Recticle
    public GameObject RightCurs;                                // Right Recticle

    public GameObject M4Mechanics;

    // UPDATE SCRIPT
    void Update()
    {
        AmmoCount = GlobalAmmo.LoadedAmmo;                      // Get Current Magazine Ammo Count

        // If Fire Button Pressed
        if (Input.GetButton("Fire1"))
        {
            // If Ammo Count is Greater than or Equal to 1
            if (AmmoCount >= 1)
            {
                // If not Firing
                if (Firing == 0)
                {
                    StartCoroutine(M4Fire());             // Run M4Fire Script
                }
            }
        }
    }

    // SMG FIRING SCRIPT
    IEnumerator M4Fire()
    {
        Firing = 1;                                             // Weapon is Firing

        // Enable Recticle Animations
        UpCurs.GetComponent<Animator>().enabled = true;
        DownCurs.GetComponent<Animator>().enabled = true;
        LeftCurs.GetComponent<Animator>().enabled = true;
        RightCurs.GetComponent<Animator>().enabled = true;

        GlobalAmmo.LoadedAmmo -= 1;                             // Subtract 1 Round from Magazine


        M4Sound.Play();                                        // Play M4 Sound

        MuzzleFlash.SetActive(true);                            // Activate Muzzle Flash

        M4.GetComponent<Animation>().Play("M4Shot");        // Enable M4 Animations

        // CAUSE ENEMY DAMAGE SHOULD GO HERE
        //M4.GetComponent<M4Damage>().CauseDamage();
        M4Mechanics.GetComponent<M4Damage>().FullAuto = 1;
        //M4Mechanics.GetComponent<M4Damage>().FullAutoDamage();

        yield return new WaitForSeconds(0.1f);                  // Wait

        MuzzleFlash.SetActive(false);                           // Disable Muzzle Flash

        M4.GetComponent<Animation>().Stop("M4Shot");        // Disable SMG Animations

        // Disable Recticle Animations
        UpCurs.GetComponent<Animator>().enabled = false;
        DownCurs.GetComponent<Animator>().enabled = false;
        LeftCurs.GetComponent<Animator>().enabled = false;
        RightCurs.GetComponent<Animator>().enabled = false;

        Firing = 0;                                             // Weapon is not Firing
        M4Mechanics.GetComponent<M4Damage>().FullAuto = 0;
    }
}
