using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 Rudimentary Spawning Algorithm used by a spawner to spawn the Bunnies and other objects in the future.

 */
public class BunnySpawning : MonoBehaviour
{

    [SerializeField] GameObject SpawnObject;
    [SerializeField] int HowManyToSpawn;

    //To be used in random position spawning
    //-----------------------------------------
    //[SerializeField] float offsetX = 20.0f;
    //[SerializeField] float offsetZ = 20.0f;
    //------------------------------------------
    [SerializeField] float spawnTime;
    [SerializeField] int spawnDelay;


    private readonly List<GameObject> spawnedObjects = new List<GameObject>();
    
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObjects", spawnTime,spawnDelay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnObjects()
    {
        
        for (int i = 0; i < HowManyToSpawn; i++)
        {
            //May use in future for random position spawning
            //float x = UnityEngine.Random.Range(-offsetX, offsetX);
            //float z = UnityEngine.Random.Range(-offsetZ, offsetZ);
            //spawnedObjects.Add(Instantiate(SpawnObject, new Vector3(x, 0, z), Quaternion.identity));
            spawnedObjects.Add(Instantiate(SpawnObject, transform.position, transform.rotation));
        }
    }
}
