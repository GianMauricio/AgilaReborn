using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
Spawning hunter code.
 */
public class HunterSpawning : MonoBehaviour
{

    [SerializeField] GameObject SpawnObject;
    [SerializeField] int HowManyToSpawn;

    public GameObject target;

    [SerializeField] float spawnTime;
    [SerializeField] int spawnDelay;


    private readonly List<GameObject> spawnedObjects = new List<GameObject>();


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObjects", spawnTime, spawnDelay);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void SpawnObjects()
    {
        for (int i = 0; i < HowManyToSpawn; i++)
        {
            GameObject temp = Instantiate(SpawnObject, transform.position, transform.rotation);
            temp.GetComponent<HAI>().setTarget(target);
            spawnedObjects.Add(temp);
        }

    }
}
