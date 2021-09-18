using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class AiAgentConfig : ScriptableObject
{
    //add some ints floats here or somn idk
    public float maxWalkTime = 180.0f;
    public float minWalkTIme = 30.0f;
    public float minAngle = 30.0f;
    public float maxAngle = 120.0f;
    public float turnSpeed = 0.0f;
}
