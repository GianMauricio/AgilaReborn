using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Does one thing. (Legacy)
/// Does two things
/// Make freebird fly, upwards at a certain rotation with a fixed speed
/// makes bird disappear at a certain time
/// </summary>
public class FreeBird : MonoBehaviour
{
    public float TimeOut;
    private float timeElapsed = 0.0f;

    public float flySpeed;

    // Update is called once per frame
    void Update()
    {
        //If there is still time, then continue to "fly" upwards
        if(timeElapsed < TimeOut)
        {
            transform.position += transform.forward * flySpeed;

            timeElapsed += Time.deltaTime;
        }

        else
        {
            Destroy(gameObject);
        }
    }
}
