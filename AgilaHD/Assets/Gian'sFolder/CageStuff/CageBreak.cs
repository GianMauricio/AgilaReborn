using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CageBreak : MonoBehaviour
{
    public GameObject BrokenCage;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bird"))
        {
            Break();
        }
    }

    void Break()
    {
        //Make broken cage
        Instantiate(BrokenCage);

        //Set new cage to be where the old cage was
        Vector3 newPos = gameObject.transform.position;
        Quaternion newRot = gameObject.transform.rotation;
        BrokenCage.transform.SetPositionAndRotation(newPos, newRot);

        //Delete old cage
        Destroy(gameObject);
    }
}
