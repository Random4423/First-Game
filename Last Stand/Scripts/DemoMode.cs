using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoMode : MonoBehaviour 
{
    // Variables
    public bool StopIntro = false;
    public GameObject BGSound;
    public GameObject RoundSound;
    public GameObject FadeIn;

    public bool ShowEnemies = false;
    public GameObject Enemies;


	// Update is called once per frame
	void Update () 
    {
        if (StopIntro)
        {
            BGSound.SetActive(false);
            RoundSound.SetActive(false);
            FadeIn.SetActive(false);
        }
        if(ShowEnemies)
        {
            Enemies.SetActive(true);
        }
	}
}
