using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorShift : MonoBehaviour
{
    public GameObject GroundPrime;
    Transform GroundPoint;
    Renderer GroundRend;
    
    // Start is called before the first frame update
    void Start(){
        //Set markers to other colors
        GroundPoint = GroundPrime.GetComponent<Transform>();
        foreach(Transform Child in GroundPoint){
            Child.GetComponent<Renderer>().material.color = Color.blue;
        }

        //Set ground to subdued color
        GroundPrime.GetComponent<Renderer>().material.color = new Color(0.3f, 0.8f, 0.3f, 1);
    }
}
