using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CageBreak : MonoBehaviour
{
    public GameObject BrokenCage;
    public GameObject Freeagle;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("HunterSphere"))
        {
            Break();
        }
    }

    public void Break()
    {
        //Set new cage to be where the old cage was
        Vector3 newPos = gameObject.transform.position;
        Quaternion newRot = gameObject.transform.rotation;

        //Unset self as a UIelement
        gameObject.GetComponent<HunterVisionUI>().declareDeath();

        //Make broken cage
        Instantiate(BrokenCage, newPos, newRot);

        //Make freeagle
        Instantiate(Freeagle);

        Freeagle.transform.position = newPos;
        Freeagle.transform.rotation = newRot;
        Freeagle.transform.Rotate(-35, 0, 0);

        //Delete old cage
        Destroy(gameObject);
    }
}
