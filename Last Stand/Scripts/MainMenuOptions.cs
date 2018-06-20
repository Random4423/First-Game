using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*	SCRIPT PURPOSE:
 * 		Manage Main Menu Options
*/

public class MainMenuOptions : MonoBehaviour 
{

	// Variables
	public AudioSource ZombieIntro;		// Zombie Sounds

	void Start()
	{
		StartCoroutine (AudioPlay ());
	}



	// Start Game Code
	public void StartGame () 
	{
		SceneManager.LoadScene (1);
	}

	// Leaderboard Code
	public void LoadLeaderboard ()
	{
		SceneManager.LoadScene (3);
	}

	// Quit Code
	public void QuitGame() 
	{
		Application.Quit ();
	}

	// [AudioPlay] - This Function Creates a pause before the zombie sounds start
	IEnumerator AudioPlay()
	{
		yield return new WaitForSeconds (3f);
		ZombieIntro.Play ();
	}

}
