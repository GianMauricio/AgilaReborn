using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// TL;DR this script changes the scene depending on what scene called the script
/// </summary>

public class SceneChange : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Smack!");
        if(!(collision.gameObject.name == "EagleBody"))
        {
            Debug.Log("LoL Nope");
            return;
        }

        if (SceneManager.GetActiveScene().name == "TUTORIAL TERRAIN")
        {
            Debug.Log("Active scene is: " + SceneManager.GetActiveScene().name);
            SceneManager.LoadScene("MAINTERRAIN");
        }

        if(SceneManager.GetActiveScene().name == "MAINTERRAIN")
        {
            Debug.Log("Active scene is: " + SceneManager.GetActiveScene().name);
            SceneManager.LoadScene("GameOver"); //CHANGE DA WORLD, MY FINAL MESSAGE
        }
    }
}
