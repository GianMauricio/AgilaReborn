using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * this is only to try if the bird works
 * 
 * */
public class bigDic : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    //[SerializeField] private Transform transform;
    [SerializeField] private float ForwardForce;
    [SerializeField] private float IdleForce;

//    [SerializeField] private float turnSmoothTime = 0.2f;
//    [SerializeField] private float turnSmoothVelocity;

    [SerializeField] private Transform cameraT;
    public ThirdPersonCamera tpsReference;

    //Smoothing
    public float rotationSmoothTime = 0.02f;
    Vector3 rotationSmoothVelocity;
    Vector3 currentRotation;

    private float yawRotation;
    private float currRot = 0;
    private float smoothVel;

    // Start is called before the first frame update
    void Start()
    {
        //cameraT = Camera.main.transform;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (Input.GetKey(KeyCode.LeftShift))
        {
            ForwardForce = 100;
        }
        else
        {
            ForwardForce = 50;
        }

       

        if (Input.GetKey(KeyCode.W))
        {
            

            
            yawRotation = tpsReference.GetComponent<ThirdPersonCamera>().yawRotation;

            if (tpsReference.GetComponent<ThirdPersonCamera>().moveleft)
            {
                yawRotation = -15* 10;
            }
            else if (tpsReference.GetComponent<ThirdPersonCamera>().moveright)
            {
                yawRotation = 15 * 10;
            }
            else
            {
                yawRotation = 0;
            }

            currRot = Mathf.SmoothDamp(currRot, yawRotation, ref smoothVel, 1);

            Quaternion too;
            too = Quaternion.Euler(1, 1, -currRot);
            

            transform.rotation = Quaternion.Slerp(transform.rotation, cameraT.rotation * too, Time.deltaTime / rotationSmoothTime);
            
            
            rb.AddForce(ForwardForce * transform.forward);
            

        }
        else
        {
            
            transform.position += transform.forward * (IdleForce) * Time.deltaTime;
        }



    }
}
