using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 Rudimentary Spawning Algorithm used by a spawner to spawn the Bunnies and other objects in the future.

 */
public class RepeatedSpawning : MonoBehaviour
{

    [SerializeField] GameObject SpawnObject;
    [SerializeField] int HowManyToSpawn = 35;

    //To be used in random position spawning
    //-----------------------------------------
    //[SerializeField] float offsetX = 20.0f;
    //[SerializeField] float offsetZ = 20.0f;
    //------------------------------------------
    [SerializeField] float spawnTime = 0.0f;
    [SerializeField] int spawnDelay = 3; //Spawn object every 3 seconds


    private readonly List<GameObject> spawnedObjects = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        //Clear any lasting objects from the spawn list
        spawnedObjects.Clear();
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnTime > spawnDelay)
        {
            spawnTime = 0; /*reset spawn timer*/

            if (spawnedObjects.Count < HowManyToSpawn)
            {
                float randomX = Random.Range(-100.0f, 100.0f);
                float randomZ = Random.Range(-100.0f, 100.0f);

                //Spawn some units away from the spawner, y is 50 just to make sure that rabbits don't fall through the world
                Vector3 spawnPos = new Vector3(transform.position.x + randomX, 50, transform.position.z + randomZ);

                spawnedObjects.Add(Instantiate(SpawnObject, spawnPos, transform.rotation));
            }
        }

        else
        {
            spawnTime += Time.deltaTime;
        }
    }
}
