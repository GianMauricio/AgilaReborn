using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script will take the player start position and reset the player when the player goes to far
/// </summary>
public class ResetPlayer : MonoBehaviour
{
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            //What the fuck
            collision.collider.gameObject.GetComponent<BirdMainScript>().ReturnToSpawn();
        }
    }
}
