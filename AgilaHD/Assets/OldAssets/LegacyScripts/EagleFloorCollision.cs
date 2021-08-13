using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EagleFloorCollision : MonoBehaviour
{
    //LEGACY CODE, this is now the responsibility of the Eagle
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Flour")
        {
            this.gameObject.GetComponent<BirdMainScript>().ifFloorHit();
        }
    }
}
