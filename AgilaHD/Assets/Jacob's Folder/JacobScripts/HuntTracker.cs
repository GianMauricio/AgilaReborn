using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script does one thing, it tracks whether or not the object it is attached to 
/// hit a huntable object or a breakable object
/// </summary>
public class HuntTracker : MonoBehaviour
{
    public ProgressionSystem levelObjectives;

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("Impact confirmed");
        levelObjectives.updateObjectives(other.gameObject.tag);
    }
}
