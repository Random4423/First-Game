using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M4Damage : MonoBehaviour 
{
    // Variables
    public int DamageAmount;        // Damage Caused By M4
    public float TargetDistance;    // The Target Distance
    public float AllowedRange = 20; // The Allowed Distance for Causing Damage

    RaycastHit Hit;

    public GameObject TheBullet;
    public GameObject TheBlood;

    public int FullAuto = 0;

    void Start()
    {
        DamageAmount = 5;
    }// End Start

    void Update()
    {
        if (FullAuto == 0)
        {
            CauseDamage();
        }
        if (FullAuto == 1)
        {
            FullAutoDamage();
        }
    }// End Update

    public void CauseDamage()
    {
        // if magazine ammo is >= 1, Check for Player Shooting, Grab Raycast Data, Check if in range, cause damage to enemy
        if (GlobalAmmo.LoadedAmmo >= 1)
        {
            // When Shot fired, use raycast..., calculate distance from enemy, if distance is allowed, inflict damage
            if (Input.GetButtonDown("Fire1"))
            {
                RaycastHit Shot;

                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out Shot))
                {
                    TargetDistance = Shot.distance;

                    if (TargetDistance < AllowedRange)
                    {
                        //Shot.transform.SendMessage ("DeductPoints", DamageAmount); // (Moved Down)

                        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out Hit))
                        {
                            // Make Zombie Bleed
                            if (Hit.transform.tag == "Zombie" || Hit.transform.tag == "Boss")
                            {
                                Instantiate(TheBlood, Hit.point, Quaternion.FromToRotation(Vector3.up, Hit.normal));
                                Debug.Log("Body Hit" + " | " + "M4 Damage: " + DamageAmount);
                            }
                            // Headshot Zombie01
                            //if (Hit.collider.tag == "Zombie01Head" || Hit.collider.tag == "BossHead")
                            //{
                            //    DamageAmount = 10;
                            //    Instantiate(TheBlood, Hit.point, Quaternion.FromToRotation(Vector3.up, Hit.normal));
                            //    Debug.Log("Head Hit" + " | " + "Damage: " + DamageAmount);
                            //}

                            // Make Bullet Hole
                            if (Hit.transform.tag == "untagged")
                            {
                                Instantiate(TheBullet, Hit.point, Quaternion.FromToRotation(Vector3.up, Hit.normal));
                            }
                        }
                        Shot.transform.SendMessage("DeductPoints", DamageAmount);
                        DamageAmount = 5;
                    }
                }
            }
        }
    }// End Cause Damage

    public void FullAutoDamage()
    {
        RaycastHit Shot;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out Shot))
        {
            TargetDistance = Shot.distance;

            if (TargetDistance < AllowedRange)
            {
                //Shot.transform.SendMessage ("DeductPoints", DamageAmount); // (Moved Down)

                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out Hit))
                {
                    // Make Zombie Bleed
                    if (Hit.transform.tag == "Zombie" || Hit.transform.tag == "Boss")
                    {
                        Instantiate(TheBlood, Hit.point, Quaternion.FromToRotation(Vector3.up, Hit.normal));
                        Debug.Log("Body Hit" + " | " + "M4 Damage: " + DamageAmount);
                    }
                    // Headshot Zombie01
                    //if (Hit.collider.tag == "Zombie01Head" || Hit.collider.tag == "BossHead")
                    //{
                    //    DamageAmount = 10;
                    //    Instantiate(TheBlood, Hit.point, Quaternion.FromToRotation(Vector3.up, Hit.normal));
                    //    Debug.Log("Head Hit" + " | " + "Damage: " + DamageAmount);
                    //}

                    // Make Bullet Hole
                    if (Hit.transform.tag == "untagged")
                    {
                        Instantiate(TheBullet, Hit.point, Quaternion.FromToRotation(Vector3.up, Hit.normal));
                    }
                }
                Shot.transform.SendMessage("DeductPoints", DamageAmount);
                DamageAmount = 5;
                FullAuto = 0;
            }
        }
    }// End FullAutoDamage
}
