using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This is horrible implementation...too bad!
/// This script will compile ALL objects that CAN be pinged by hunter vision.
/// If the eagle calls the script, it will either start or stop the ping being sent out by the huntable.
/// </summary>
public class InteractibleManager 
{
    public static List<GameObject> interactible = new List<GameObject>();
    public static List<GameObject> spawners = new List<GameObject>();

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
                ping.EngagePing(radarCenter);
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

    public static void freezeAll()
    {
        foreach (GameObject target in interactible)
        {
            //Because of course, the only script that has connections to all is the UI
            //Because why not
            target.GetComponent<HunterVisionUI>().Pause();
        }

        foreach (GameObject spawner in spawners)
        {
            spawner.GetComponent<RepeatedSpawning>().Pause();
        }
    }

    public static void unfreezeAll()
    {
        foreach (GameObject target in interactible)
        {
            //Because of course, the only script that has connections to all is the UI
            //Because why not(2)
            target.GetComponent<HunterVisionUI>().Unpause();
        }

        foreach (GameObject spawner in spawners)
        {
            spawner.GetComponent<RepeatedSpawning>().Unpause();
        }
    }

    public static void addInteractible(GameObject possibleinteractible)
    {
        interactible.Add(possibleinteractible);
    }

    public static void removeInteractible(GameObject destroyThis)
    {
        interactible.Remove(destroyThis);
    }

    public static void addSpawner(GameObject newSpawner)
    {
        spawners.Add(newSpawner);
    }
}
