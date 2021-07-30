using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// LEGACY CODE, this can be deleted once the SampleScene in Old Assets has also been deleted. All this script does is spawn trees, which will
/// now be dodne statitcally
/// </summary>

public class TreeSpawner : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    [SerializeField] int HowManyFuckinTree;
    [SerializeField] float offset = 100.0f;
    private readonly List<GameObject> spawnedObjects = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        SpawnObjects();
    }

    private void SpawnObjects()
    {
        
        for (int i = 0; i < HowManyFuckinTree; i++)
        {
            float x = UnityEngine.Random.Range(-offset, offset);
            float z = UnityEngine.Random.Range(-offset, offset);
            spawnedObjects.Add(Instantiate(prefab, new Vector3(x, 0, z), Quaternion.identity));
        }
    }
}
