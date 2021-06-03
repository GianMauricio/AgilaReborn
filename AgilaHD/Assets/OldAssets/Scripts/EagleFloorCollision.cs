using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EagleFloorCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Flour")
        {
            this.gameObject.GetComponent<bigDic>().ifFloorHit();
        }
    }
}
