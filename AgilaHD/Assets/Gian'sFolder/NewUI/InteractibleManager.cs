using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This is horrible implementation...too bad!
/// This script will compile ALL objects that CAN be pinged by hunter vision.
/// If the eagle calls the script, it will either start or stop the ping being sent out by the huntable.
/// </summary>
public static class InteractibleManager 
{
    public static List<GameObject> interactible;

    //Ping all interactibles
    public static void pingAll(Vector3 radarCenter)
    {
        foreach (GameObject hit in interactible)
        {
            //Get the UI element of the object
            HunterVisionUI ping = hit.GetComponent<HunterVisionUI>();

            //Contemplate adding a security check here

            if(ping != null)
            {
                ping.EngagePing(hit.transform.position);
            }

            else
            {
                Debug.LogError("UI Element Missing");
            }
        }
    }

    //Unping all interactibles
    public static void unpingAll()
    {
        foreach (GameObject hit in interactible)
        {
            //Get the UI element of the object
            HunterVisionUI ping = hit.GetComponent<HunterVisionUI>();

            //Contemplate adding a security check here
            if (ping != null)
            {
                ping.DisablePing();
            }

            else
            {
                Debug.Log("UI Element Missing");
            }
        }
    }

    public static void addInteractible(GameObject possibleinteractible)
    {
        interactible.Add(possibleinteractible);
    }
}
