using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/*	SCRIPT PURPOSE:
 * 		Keep Track of Player Health
*/


public class GlobalHealth : MonoBehaviour 
{
	// Variables
	public static int PlayerHealth = 100;
	public int InternalHealth;
	public GameObject HealthDisplay;
	public Slider HealthSlider;

    public AudioSource DieSound;
    public AudioSource BGSound;

	void Update () 
	{
		InternalHealth = PlayerHealth;

		HealthDisplay.GetComponent<Text>().text = PlayerHealth + " %";

		HealthSlider.value = PlayerHealth;


		// if player dies game over
		if (PlayerHealth <= 0) 
		{
            //Debug.Log("I Am Here");
            HealthDisplay.GetComponent<Text>().text = "0 %";
            BGSound.Stop();
            //StartCoroutine(PlayerDie());
            DieSound.Play();
           
			SceneManager.LoadScene (2);
		}
	}

    // IEnumerator PlayerDie()
    //{
    //    Debug.Log("Start Dying");
    //    yield return new WaitForSeconds(2f);
    //    Debug.Log("Exiting Death Mode");
    //}
}
