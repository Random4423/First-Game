using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M4Reloading : MonoBehaviour 
{
    // Variables
    public AudioSource ReloadSound;     // Reload Sound
    public GameObject RecticleObject;   // For Disabling Recticle
    public GameObject M4Mecanics;     // For Disabling Mechanics
    public int MagCount;                // [Internal] Magazine Count
    public int ReserveCount;            // [Internal] Reserve Ammo
    public int ReloadAvailable;         // [Internal] Available ammo to load into Magazine (Used to Fill Mag)
    M4GunFire GunComponent;           // [Internal] Controls Gunfire Component
    public GameObject M4;             //  M4 GameObject

    void Start()
    {
        GunComponent = GetComponent<M4GunFire>(); // Assign GunComponent access of M4 Gunfire Component
    }

    void Update()
    {
        MagCount = GlobalAmmo.LoadedAmmo;       // Get Magazine Count
        ReserveCount = GlobalAmmo.CurrentAmmo;  // Get Reserve Ammo Count

        // If reserve = 0, no reloads available
        if (ReserveCount == 0)
        {
            ReloadAvailable = 0;
        }
        else // ELSE ReloadAvailable = 30 minus mag count
        {
            ReloadAvailable = 30 - MagCount;
        }

        // IF Player Presses Reload
        if (Input.GetButtonDown("Reload"))
        {
            if (ReloadAvailable >= 1)
            {
                if (ReserveCount <= ReloadAvailable)
                {
                    GlobalAmmo.LoadedAmmo += ReserveCount;
                    GlobalAmmo.CurrentAmmo -= ReserveCount;
                    ActionReload();
                }
                else
                {
                    GlobalAmmo.LoadedAmmo += ReloadAvailable;
                    GlobalAmmo.CurrentAmmo -= ReloadAvailable;
                    ActionReload();
                }
            }
            StartCoroutine(EnableScripts());
        }
    }

    // scripts function
    IEnumerator EnableScripts()
    {
        yield return new WaitForSeconds(1.1f);              // Wait
        GunComponent.enabled = true;                        // Enable Gun Component
        RecticleObject.SetActive(true);                 // Enable Recticle
       M4Mecanics.SetActive(true);                   // Enable Mechanics
    }

    // reload function
    void ActionReload()
    {
        GunComponent.enabled = false;                       // Disable Gun Component
        RecticleObject.SetActive(false);                    // Disable Recticle
        M4Mecanics.SetActive(false);                      // Disable Mechanics
        ReloadSound.Play();                             // Play Reload Sound
        M4.GetComponent<Animation>().Play("M4Reload");  // Play Reload Animations
    }

}
