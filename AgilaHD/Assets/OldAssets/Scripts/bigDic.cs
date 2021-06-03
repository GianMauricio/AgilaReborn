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

    Vector3 lastVelocity;
    private float initialDrag;
    private float initialAngularDrag;
    Vector3 lastPosition;

    // Start is called before the first frame update
    void Start()
    {
        //cameraT = Camera.main.transform;
        initialDrag = gameObject.GetComponent<Rigidbody>().drag;
        initialAngularDrag = gameObject.GetComponent<Rigidbody>().angularDrag;
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

            gameObject.GetComponent<Rigidbody>().drag = initialDrag;
            gameObject.GetComponent<Rigidbody>().angularDrag = 0.3f;
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


            transform.rotation = Quaternion.Slerp(transform.rotation, cameraT.rotation * too, Time.deltaTime / rotationSmoothTime) ;
            
            
            rb.AddForce(ForwardForce * transform.forward);
            

        }
        else
        {
            Vector3 velocity = gameObject.GetComponent<Rigidbody>().velocity;
            if (gameObject.transform.position.y <= lastPosition.y)//means we're going down
            {
                Debug.Log("going down");
                rb.AddForce(7.0f * (transform.forward + Vector3.up)); //glide
            }
            else
            {
                Debug.Log("going up");
                rb.AddForce(2.0f * (transform.forward + Vector3.up)); //glide
            }
            

            gameObject.GetComponent<Rigidbody>().angularDrag = initialAngularDrag;
            float nice = gameObject.GetComponent<Rigidbody>().drag;
            if(nice > 0.15f)
            {
                gameObject.GetComponent<Rigidbody>().drag = nice - Time.deltaTime;
            }
            
            //transform.position += transform.forward * (IdleForce) * Time.deltaTime;

            //look forward based on velocity
            //Vector3 velocity= gameObject.GetComponent<Rigidbody>().velocity;
            float magnitude = velocity.magnitude;
            

            Vector3 orignialDirection = this.lastVelocity;
            Vector3 nowDirection = gameObject.GetComponent<Rigidbody>().velocity;
            Vector3 rotationAxis = (Vector3.Cross(orignialDirection, nowDirection));
            float angle = (Vector3.Angle(orignialDirection, gameObject.GetComponent<Rigidbody>().velocity)) * Mathf.Deg2Rad / 2;
            Quaternion q = Quaternion.FromToRotation(orignialDirection, nowDirection);


            //Quaternion quat = Quaternion.Euler(interpTo);
            //Debug.Log(magnitude);
            transform.rotation = Quaternion.RotateTowards(gameObject.transform.rotation, q * transform.rotation, magnitude / 10) ;

            //Quaternion newFace = Quaternion.LookRotation(velocity);
        }

        this.lastPosition = gameObject.transform.position;
        this.lastVelocity = gameObject.GetComponent<Rigidbody>().velocity;
    }

    private void OnCollisionEnter(Collision collision)
    {
        /*
        if (collision.gameObject.name == "Ground") 
                gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * 100, ForceMode.Impulse);
        */
    }
}
