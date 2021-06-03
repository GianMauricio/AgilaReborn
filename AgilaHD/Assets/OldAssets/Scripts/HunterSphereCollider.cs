using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HunterSphereCollider : MonoBehaviour
{
    [SerializeField] private bigDic mainBirdComponent;
    // Start is called before the first frame update
    void Start()
    {
        if(mainBirdComponent == null)
        {
            mainBirdComponent = this.gameObject.GetComponentInParent<bigDic>();
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Huntable")
        {
            Debug.LogError("Deleted huntable");
            GameObject.Destroy(other);
        }
    }






}
