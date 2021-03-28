using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Huntable : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    [SerializeField] int HowManyRabbit;
    [SerializeField] float offset = 100.0f;
    private readonly List<GameObject> spawnedObjects = new List<GameObject>();


    [SerializeField] Material normalMode;
    [SerializeField] Material huntMode;
    public bool isnormalMode = true;

    // Start is called before the first frame update
    void Start()
    {
        SpawnObjects();
    }

    private void SpawnObjects()
    {

        for (int i = 0; i < HowManyRabbit; i++)
        {
            float x = UnityEngine.Random.Range(-offset, offset);
            float z = UnityEngine.Random.Range(-offset, offset);
            spawnedObjects.Add(Instantiate(prefab, new Vector3(x, 0, z), Quaternion.identity));

        }

    }

    public void modeSwitch()
    {

        if (isnormalMode)
        {
            changeMat(normalMode);
        }
        else
        {
            changeMat(huntMode);
        }
        Debug.LogWarning("Changed matssss");

    }

    private void changeMat(Material mat)
    {
        foreach(GameObject objects in spawnedObjects)
        {
            objects.GetComponent<MeshRenderer>().material = mat;
        }
    }

    public void Update()
    {
        
    }
}