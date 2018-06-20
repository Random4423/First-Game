using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class M4Pickup : MonoBehaviour 
{
    public float TheDistance = PlayerCasting.DistanceFromTarget;    // Gets distance from target
    public GameObject TextDisplay;                                  // Displays Text 

    public GameObject M4Display;                                  // Gun in Scene
    public GameObject M4;                                         // Gun in Hand
    public AudioSource PickUpAudio;                                 // Pickup Audio

    public GameObject M4Mechanics;                                // M4 Mechanics

    // Other Guns
    public GameObject M9;
    public GameObject M9Display;
    public GameObject M9Mechanics;

    public GameObject MP5K;
    public GameObject MP5KDisplay;
    public GameObject MP5KMechanics;

    public GameObject TypeDisplay;                                  // Display Type Label
    public GameObject Recticle;                                     // Recticle Object


    // [ON MOUSE OVER]
    void OnMouseOver()
    {
        // if the distance is less than or equal to 2
        if (TheDistance <= 2)
        {
            TextDisplay.GetComponent<Text>().text = "Take M4";            // Display Take M4
        }

        // if action button is pressed
        if (Input.GetButtonDown("Action"))
        {
            // if distance is less than or equal to 2
            if (TheDistance <= 2)
            {
                StartCoroutine(TakeM4());                             // Run TakeM4 Function

                Recticle.SetActive(true);

                // Disable other mechanics
                M9Mechanics.SetActive(false);
                MP5KMechanics.SetActive(false);

                M4Mechanics.SetActive(true);                              // Enable M4 Mechanics
                Debug.Log("AR15 Mechanics: " + M4Mechanics.activeSelf);
            }
        }
    }

    // [ON MOUSE EXIT]
    void OnMouseExit()
    {
        TextDisplay.GetComponent<Text>().text = "";                     // Clears the TextDisplay variable
    }

    // [TAKE AR15] - Function for taking AR15
    IEnumerator TakeM4()
    {
        // Put Gun 01 Away
        M9.SetActive(false);
        M9Display.SetActive(true);
        // Put Gun 02 Away
        MP5K.SetActive(false);
        MP5KDisplay.SetActive(true);

        PickUpAudio.Play();                                         // Play Audio

        //transform.position = new Vector3(0, -1000, 0);                    // Move Trigger Offscreen
        M4Display.SetActive(false);                                   // Disable Display Gun
        TextDisplay.GetComponent<Text>().text = "";                     // Clear Text
        M4.SetActive(true);                                           // Enable Real Gun      
        GlobalWeaponSelect.WeaponSelected = 3;
        GlobalAmmo.CurrentAmmo = 60;                                    // Reserve Ammo
        GlobalAmmo.LoadedAmmo = 30;                                     // Mag Ammo
        TypeDisplay.GetComponent<Text>().text = "M4";                 // Display M4 Label
        yield return new WaitForSeconds(0.1f);                          // Wait
    }


}
