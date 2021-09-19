using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// TL;DR this script changes the scene depending on what scene called the script
/// </summary>

public class SceneChange : MonoBehaviour
{
    MenuScript sceneLinker;

    public void Start()
    {
        sceneLinker = gameObject.GetComponent<MenuScript>();
    }

    private void OnTriggerEnter(Collider other)
    {
        //If the player hits this volume, then check all objectives
        if (other.CompareTag("Player"))
        {
            if(other.GetComponent<BirdMainScript>().)
        }
    }
}
