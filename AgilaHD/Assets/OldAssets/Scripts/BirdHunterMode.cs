using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BirdHunterMode : MonoBehaviour
{
    // [SerializeField] private Image imageReference;
    [SerializeField] private GameObject imageHolderReference;

    [SerializeField] private float maxCooldown;
    [SerializeField] private GameObject sphereColliderReference;
    private float cooldown;
    // Start is called before the first frame update
    void Start()
    {
        cooldown = maxCooldown;
        if(sphereColliderReference != null && sphereColliderReference.active)
        {
            sphereColliderReference.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (/*Input.GetMouseButtonDown(0)*/ Input.GetButton("Fire1"))
        {
            
            if (cooldown > 0)
            {
                cooldown -= Time.deltaTime;
                //allow hunt
                imageHolderReference.transform.localScale = new Vector3(cooldown / maxCooldown, 1, 1);
                if (!sphereColliderReference.active)
                {
                    sphereColliderReference.SetActive(true);
                }
            }
            else
            {
                if (sphereColliderReference.active)
                {
                    sphereColliderReference.SetActive(false);
                }
            }

        }
        else
        {
             if (cooldown < maxCooldown)
            {
                if (sphereColliderReference.active)
                {
                    sphereColliderReference.SetActive(false);
                }
                cooldown += (Time.deltaTime * 0.2f);//slower recorvery
                imageHolderReference.transform.localScale = new Vector3(cooldown / maxCooldown, 1, 1);
            }
        }


    }


}
