using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveDebris : MonoBehaviour
{
    public float timer = 5;
    

    void Update()
    {
        //After a certain amount of time, delete this object
        timer -= Time.deltaTime;

        if(timer <= 0)
        {
            Destroy(gameObject);
        }
    }
}
