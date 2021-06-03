using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BPhizzy : MonoBehaviour
{
    private float speedMult = 300.0f;
    private float lifeTime = 10.0f;
    Vector3 targetPos;
    // Update is called once per frame
    void Start()
    {
        
    }

    private void Update()
    {
        lifeTime -= Time.deltaTime;

        if(lifeTime <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Hit " + collision.gameObject.name);
    }
}
