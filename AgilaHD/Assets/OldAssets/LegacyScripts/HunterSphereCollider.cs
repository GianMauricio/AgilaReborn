using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HunterSphereCollider : MonoBehaviour
{
    [SerializeField] private bigDic mainBirdComponent;
    void Start()
    {
        //Keep self intact at all times
        if(mainBirdComponent == null)
        {
            mainBirdComponent = this.gameObject.GetComponentInParent<bigDic>();
        }

    }


    //Redundant, the huntable kills itself aswell, might lead to errors
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Huntable")
        {
            Debug.LogError("Deleted huntable");
            GameObject.Destroy(other);
        }
    }
}
