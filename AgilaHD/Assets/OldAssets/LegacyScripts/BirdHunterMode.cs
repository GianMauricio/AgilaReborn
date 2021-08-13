﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BirdHunterMode : MonoBehaviour
{
    public GameObject StaminaBar;
    public GameObject StaminaBG;
    public BirdAnimationHandler animator;
    private Image StaminaImg;


    [SerializeField] private float maxCooldown;
    [SerializeField] private GameObject sphereColliderReference;
    private float cooldown;

    void Start()
    {

        //Ensure that the cooldowans start at max so that the player can actually use the skills
        cooldown = maxCooldown;

        //Set UI components
        StaminaImg = StaminaBar.GetComponent<Image>();

        //Make sure that sphere thing starts off
        if(sphereColliderReference != null && sphereColliderReference.active)
        {
            sphereColliderReference.SetActive(false);
        }
    }

    void Update()
    {
        //If mouse button is held
        if (Input.GetButton("Fire1"))
        {
            animator.doGrab();
            //If the cooldown has not ben started yet
            if (cooldown > 0)
            {
                //Start the cool down
                cooldown -= Time.deltaTime;

                //allow hunt

                // (Legacy)Adjusts the position of the image based on stamine to keep centered
                // imageHolderReference.transform.localScale = new Vector3(cooldown / maxCooldown, 1, 1);
                if (!sphereColliderReference.active) //Uses legacy Unity functions but who cares?
                {
                    sphereColliderReference.SetActive(true);
                }

                //Activate Hunt UI
                //TODO: Fade In
                //StaminaBG.SetActive(true);

                //Set hunt stamina to current stamina
                float fillpercent = cooldown / maxCooldown;
                //StaminaImg.fillAmount = fillpercent;
                StaminaBar.transform.localScale = new Vector3( fillpercent, 1, 1);
               // Debug.Log("HAIDUAHSDIUAHSD");
            }
            else
            {
                if (sphereColliderReference.active) //Shhhhh hush you
                {
                    sphereColliderReference.SetActive(false);
                }
            }

        }

        //Otherwise
        else
        {
            animator.stopGrab();
            //Recharge hunt mode stamina if still not max
            if (cooldown < maxCooldown)
            {
                //Ensure that the hunter mode is kept inactive
                if (sphereColliderReference.active)
                {
                    sphereColliderReference.SetActive(false);
                }

                //Stamina recharges 80% slower than consumption 
                cooldown += (Time.deltaTime * 0.2f);//slower recovery

                //imageHolderReference.transform.localScale = new Vector3(cooldown / maxCooldown, 1, 1);
                float fillpercent = cooldown / maxCooldown;
                //StaminaImg.fillAmount = fillpercent;
                StaminaBar.transform.localScale = new Vector3(fillpercent, 1, 1);
            }

            //Deactivate UI
            else
            {
                //TODO: Fade out
                //StaminaBG.SetActive(false);
            }
        }


    }


}
