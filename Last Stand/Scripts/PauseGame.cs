using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour 
{
	// Variables
	public bool Paused = false;		// Pause Flag
	public GameObject ThePlayer;	// The Player
	public GameObject PauseMenu;	// UI Pause Menu
	public AudioSource PauseSound;	// Sound Played when paused
	public AudioSource BGAudio;		// Background Music
	public GameObject Recticle;		// Recticle

	// Disable Guns
	public GameObject M9;	
	public GameObject MP5K;
    public GameObject M4;

	public GameObject KeyInput;
	public GameObject HelperText;

    // Pause


	void Update () 
	{
		if (Input.GetButtonDown ("Cancel")) 
		{
			// Pause
			if (Paused == false) {
				Time.timeScale = 0;														// Stop TimeScale
				Paused = true;															// Paused is True
				PauseSound.Play ();														// Play Pause Sound
				PauseMenu.SetActive (true);												// Enable Pause Panel
				ThePlayer.GetComponent<FirstPersonController> ().enabled = false;		// Disable First Person Controller
				BGAudio.Pause ();														// Pause Background Music
				Recticle.SetActive (false);												// Disable Recticle
				M9.GetComponent<M9GunFire> ().enabled = false;							// Disable M9 Gunfire
				M9.GetComponent<M9Reloading> ().enabled = false;						// Disable M9 Reloads
				MP5K.GetComponent<MP5KGunFire> ().enabled = false;						// Disable MP5K Gunfire
				MP5K.GetComponent<MP5KReload> ().enabled = false;						// Disable MP5K Reloads
                M4.GetComponent<M4GunFire>().enabled = false;
                M4.GetComponent<M4Reloading>().enabled = false;
				HelperText.SetActive (false);											// Disable Helper Text
				Cursor.visible = true;													// Enable Cursor
			} else { // Unpause
				ThePlayer.GetComponent<FirstPersonController> ().enabled = true;		// Enable First Person Controller
				BGAudio.Play ();														// Enable Background Music

                if (M9.activeSelf || MP5K.activeSelf || M4.activeSelf)
                {
                    Recticle.SetActive(true);												// Enable Recticle
                }
				M9.GetComponent<M9GunFire> ().enabled = true;							// Enable M9 Gunfire
				M9.GetComponent<M9Reloading> ().enabled = true;							// Enable M9 Reloads
				MP5K.GetComponent<MP5KGunFire> ().enabled = true;						// Enable MP5K Gunfire
				MP5K.GetComponent<MP5KReload> ().enabled = true;						// Enable MP5K Reloads
                M4.GetComponent<M4GunFire>().enabled = true;
                M4.GetComponent<M4Reloading>().enabled = true;

				Paused = false;															// Pause is false
				PauseMenu.SetActive (false);											// Disable Pause Panel
				KeyInput.SetActive (false);												// Disable Key Input Panel
				HelperText.SetActive (true);											// Enable Helper Text
				Time.timeScale = 1;														// Start TimeScale
			}
		}
	}

	// [Unpause Game] - Unpauses the game using UI Menu
	public void UnpauseGame()
	{
		ThePlayer.GetComponent<FirstPersonController> ().enabled = true;				// Enable First Person Controller
		BGAudio.Play ();																// Enable Background Music

        if (M9.activeSelf || MP5K.activeSelf || M4.activeSelf)
        {
            Recticle.SetActive(true);                                               // Enable Recticle
        }

		M9.GetComponent<M9GunFire> ().enabled = true;									// Enable M9 Gunfire
		M9.GetComponent<M9Reloading> ().enabled = true;									// Enable M9 Reloads
		MP5K.GetComponent<MP5KGunFire> ().enabled = true;								// Enable MP5K Gunfire
		MP5K.GetComponent<MP5KReload> ().enabled = true;								// Enable MP5K Reloads
        M4.GetComponent<M4GunFire>().enabled = true;
        M4.GetComponent<M4Reloading>().enabled = true;
		Paused = false;																	// Pause is false
		PauseMenu.SetActive (false);													// Disable Pause Panel
		KeyInput.SetActive (false);														// Disable Key Input Panel
		HelperText.SetActive (true);													// Enable Helper Text
		Time.timeScale = 1;																// Start TimeScale
	}

	public void QuitGame()
	{
		// Empty Ammo
		// Place Weapons Back
		Time.timeScale = 1;
		GlobalAmmo.CurrentAmmo = 0;
		GlobalAmmo.LoadedAmmo = 0;
		GlobalAmmo.GrenadeCount = 0;
		SceneManager.LoadScene (0);
	}

	public void ShowKeyInput()
	{
		if (KeyInput.activeSelf) {
			KeyInput.SetActive (false);
		} else 
		{
			KeyInput.SetActive (true);
		}
	}
}
