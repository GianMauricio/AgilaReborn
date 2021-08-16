using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script spawns things instantly upon start
/// </summary>

//Single --> Spawns objects on top of self once
//Cluster --> Spawns a cluster of objects around self until X objects
//Random --> Spawns objects within a random range
public enum SpawnType {Single, Cluster, Random}

public class CageSpawning : MonoBehaviour
{
    public GameObject Template;
    public SpawnType type = SpawnType.Single;

    [Header("For Cluster and Random Spawning")]
    public int objectsToSpawn;
    public float spawnRadius;

    [Header("For Random spawn limits")]
    public float xMax;
    public float xMin;
    public float zMax;
    public float zMin;

    // Start is called before the first frame update
    void Start()
    {
        //if this spawner is singluar
        if (type == SpawnType.Single)
        {
            //Spawn object once
            Instantiate(Template, transform.position, transform.rotation);
        }

        //If the spawner is a cluster
        else if(type == SpawnType.Cluster)
        {
            for (int i = 0; i < objectsToSpawn; i++)
            {
                float randomX = Random.Range(-spawnRadius, -spawnRadius);
                float randomZ = Random.Range(-spawnRadius, -spawnRadius);

                //Spawn some units away from the spawner, y is 50 just to make sure that objects don't fall through the world
                Vector3 spawnPos = new Vector3(transform.position.x + randomX, 50, transform.position.z + randomZ);

                Instantiate(Template, spawnPos, transform.rotation);
            }
        }

        else if(type == SpawnType.Random)
        {
            for (int i = 0; i < objectsToSpawn; i++)
            {
                float randomX = Random.Range(xMin, xMax);
                float randomZ = Random.Range(zMin, zMax);

                //Spawn some units within allowed range, y is 50 just to make sure that objects don't fall through the world
                Vector3 spawnPos = new Vector3(randomX, 50, randomZ);

                Instantiate(Template, spawnPos, transform.rotation);
            }
        }
    }
}
