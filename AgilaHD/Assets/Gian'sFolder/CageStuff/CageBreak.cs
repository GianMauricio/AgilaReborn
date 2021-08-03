﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CageBreak : MonoBehaviour
{
    public GameObject BrokenCage;
    public float timer = 5;

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            //Make broken cage
            Instantiate(BrokenCage);

            //Set new cage to be where the old cage was
            Vector3 newPos = gameObject.transform.position;
            Quaternion newRot = gameObject.transform.rotation;
            BrokenCage.transform.SetPositionAndRotation(newPos, newRot);

            //Delete old cage
            Destroy(gameObject);
        }
    }
}
