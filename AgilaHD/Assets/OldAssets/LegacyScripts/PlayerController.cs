using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float walkSpeed = 1;
    public float runSpeed = 3;

    //to get reference from the animation thingy
    public Animator animator;
    //Animator animator;

    //for target rotation smoothing
    public float turnSmoothTime = 0.2f;
    float turnSmoothVelocity;
    //running smoothing
    public float speedSmoothTime = 0.1f;
    float speedSmoothVelocity;
    float currentSpeed;

    //Transform camera to move with the player pwede rin public camera
    Transform cameraT;

    // Start is called before the first frame update
    void Start(){
        animator = GetComponent<Animator>();
        cameraT = Camera.main.transform;
    }

    // Update is called once per frame
    void Update() {
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        //to get direction
        Vector2 inputDir = input.normalized;

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //this is to rotate the player when we press wasd
        if(inputDir != Vector2.zero) //use this para di niya ccalculate pag naka forward face
        {
            //time to set rotation
            //Problem here is that if our y is zero, it will error
            //transform.eulerAngles = Vector3.up * Mathf.Atan(inputDir.x / inputDir.y);
            //use this instead. atan2 will use it as 2 separate floats and siya na bahala dun sa zero na yun HAHAHAHA hacks yan
            //this line makes super duper fast rotation, we're gonna have to use smoothing ont the target -> Mathf.Atan2(inputDir.x, inputDir.y) * Mathf.Rad2Deg;

            //transform.eulerAngles = Vector3.up * Mathf.Atan2(inputDir.x, inputDir.y) * Mathf.Rad2Deg; //hacks din yan yung * rad2deg

            //use this instead      //use this without camera follow
            //float targetRotation = Mathf.Atan2(inputDir.x, inputDir.y) * Mathf.Rad2Deg;
            //use this with camera follow, you get rotation of camera para w you face forward
            float targetRotation = Mathf.Atan2(inputDir.x, inputDir.y) * Mathf.Rad2Deg + cameraT.eulerAngles.y;


            //the ref allows smoothvelocity to be modified by the smoothdamp function

            //use this without camera movement
            //vector3.up is short for [0,1,0] which means it will rotate at the y axis          
            //transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation, ref turnSmoothVelocity, turnSmoothTime);

            //use this for with camera movement with player
            transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation, ref turnSmoothVelocity, turnSmoothTime);


        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //this is to move the player
        bool running = Input.GetKey(KeyCode.LeftShift);
        //next level if else
        //if we are running then speed is run. else, walkspeed
        // float speed = ((running) ? runSpeed : walkSpeed) ; 
        //kaya may magnitude kasi pag wala ginagawa, magnitude will be zero so no speed. pag gumagalaw, edi 1. this is so smart.
        //this is for no damping
        //float speed = ((running) ? runSpeed : walkSpeed) * inputDir.magnitude;
        //this is for damping
        float targetSpeed = ((running) ? runSpeed : walkSpeed) * inputDir.magnitude;
        currentSpeed = Mathf.SmoothDamp(currentSpeed, targetSpeed, ref speedSmoothVelocity, speedSmoothTime);


        //time to move the player
        transform.Translate(transform.forward * currentSpeed * Time.deltaTime, Space.World);

        //for the animation
        float animationSpeedPercent = ((running) ? 1 : .5f) * inputDir.magnitude;
        //get this from animator window -> parameters
        //use this for no animation damping
        //animator.SetFloat("speedPercent",animationSpeedPercent);
        //use this for with animation damping
        //dapat same sila ng smoothtime ng movement
        //this also fixes jittering nung nag sspam ng a and d keys
        animator.SetFloat("speedPercent", animationSpeedPercent, speedSmoothTime, Time.deltaTime);
    }
}
