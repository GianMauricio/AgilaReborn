using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Script has relinquished all UI control. This script will only be responsible for
/// Engaging and diengaging hunting and hunt mode. Secondly it will also handle grab anims 
/// </summary>
public class BirdHunterMode : MonoBehaviour
{

    public BirdAnimationHandler animator;
    [SerializeField] private GameObject sphereColliderReference;

    void Start()
    {
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
           
            //allow hunt

            // (Legacy)Adjusts the position of the image based on stamine to keep centered
            // imageHolderReference.transform.localScale = new Vector3(cooldown / maxCooldown, 1, 1);
            if (!sphereColliderReference.active) //Uses legacy Unity functions but who cares?
            {
                sphereColliderReference.SetActive(true);
            }
        }

        //Otherwise
        else
        {
            animator.stopGrab();
            sphereColliderReference.SetActive(false);
        }
    }
}
