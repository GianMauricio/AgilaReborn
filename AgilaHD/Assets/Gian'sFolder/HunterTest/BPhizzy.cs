using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BPhizzy : MonoBehaviour
{
    private float lifeTime = 10.0f;

    private void Update()
    {
        lifeTime -= Time.deltaTime;
        if(lifeTime <= 0)
        {
            //Kill self after a certain time
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Confirm hit
        Debug.Log("Hit " + collision.gameObject.name);

        //And then vanish
        Destroy(gameObject);
    }
}
