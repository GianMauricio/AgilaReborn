using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunnySpawning : MonoBehaviour
{

    [SerializeField] GameObject SpawnObject;
    [SerializeField] int HowManyToSpawn;
    [SerializeField] float offset = 100.0f;
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
            //relic code though may use in future
            //float x = UnityEngine.Random.Range(-offset, offset);
            //float z = UnityEngine.Random.Range(-offset, offset);
            //spawnedObjects.Add(Instantiate(SpawnObject, new Vector3(0, 0, 0), Quaternion.identity)); 
            spawnedObjects.Add(Instantiate(SpawnObject, transform.position, transform.rotation));
        }

        //float x = UnityEngine.Random.Range(-offset, offset);
        //float z = UnityEngine.Random.Range(-offset, offset);
        //spawnedObjects.Add(Instantiate(SpawnObject, new Vector3(x, 0, z), Quaternion.identity));


    }

}
