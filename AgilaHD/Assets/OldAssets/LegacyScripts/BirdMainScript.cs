using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class BirdMainScript : MonoBehaviour
{
    //All to make birb fly
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float ForwardForce;
    [SerializeField] private float IdleForce;

    //To make birb seen
    [SerializeField] private Transform cameraT;
    public ThirdPersonCamera tpsReference;

    //Smoothing
    //For time
    public float rotationSmoothTime = 0.02f;
    private float yawRotation;
    private float currRot = 0;
    private float smoothVel;

    //From time to movement
    Vector3 lastVelocity;
    private float initialDrag;
    private float initialAngularDrag;
    Vector3 lastPosition;

    //Health Values
    float maxhealth = 100.0f;
    float currhealth = 100.0f;

    //UI stuff
    public Image healthBar;

    //Animator Ref
    public BirdAnimationHandler animator;

    private bool shiftPressed = false;
    public float current_speed = 0;
    private float flapspeed = 0;
    private float lerpVal = 0;

    void Start()
    {
        //Set initials for use in succeeding calculations due to being suspended in air already
        initialDrag = gameObject.GetComponent<Rigidbody>().drag;
        initialAngularDrag = gameObject.GetComponent<Rigidbody>().angularDrag;

        animator.doFlap();
    }

    //Movement
    void FixedUpdate()
    {
        //initial velocity compute at first update
       current_speed = rb.velocity.magnitude;/*Can be utilized for anim transitions*/
        
        //Sprint implementation
        if (Input.GetKey(KeyCode.LeftShift))
        {
            ForwardForce = 100;
        }

        else
        {
            ForwardForce = 50;
        }

        //Moving forward
        if (Input.GetKey(KeyCode.W))
        {
            float rate = current_speed / 20;//topspeed
            flapspeed *= rate;
            //Debug.Log(flapspeed);

            if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift))
            {
                flapspeed = Mathf.Clamp(flapspeed, 2, 10);//10
                // Debug.LogError("EHEHHE");
            }
            else
            {
                flapspeed = Mathf.Clamp(flapspeed, 2, 5);
            }

            animator.SetFlapSpeed(flapspeed);

            //Calculate where the eagle is facing
            gameObject.GetComponent<Rigidbody>().drag = initialDrag;
            gameObject.GetComponent<Rigidbody>().angularDrag = 0.3f;
            yawRotation = tpsReference.GetComponent<ThirdPersonCamera>().yawRotation;

            //Set according to camera
            if (tpsReference.GetComponent<ThirdPersonCamera>().moveleft)
            {
                yawRotation = -15 * 10;
            }
            else if (tpsReference.GetComponent<ThirdPersonCamera>().moveright)
            {
                yawRotation = 15 * 10;
            }
            else
            {
                yawRotation = 0;
            }

            //Do the corrections smoothly
            currRot = Mathf.SmoothDamp(currRot, yawRotation, ref smoothVel, 1);

            //Ascertain the relative position of the TPS camera
            float relativePosition;

            Debug.Log("Current speed: " + current_speed);

            relativePosition = tpsReference.gameObject.transform.position.y - gameObject.transform.position.y;

            Debug.Log("Camera relative pos: " + relativePosition);

            //If camera is above eagle and eagle is "plummetting"
            if(relativePosition > 0 && current_speed > 27.0f)
            {
                //Start dive
                animator.startDive();
            }

            //Once the eagle bleeds og enoug speed, release the dive
            else if(current_speed < 27.0f)
            {
                //Leave dive
                animator.leaveDive();
            }

            //Calculate direction
            Quaternion too;
            too = Quaternion.Euler(1, 1, -currRot);

            //Apply direction over time
            transform.rotation = Quaternion.Slerp(transform.rotation, cameraT.rotation * too, Time.deltaTime / rotationSmoothTime);

            //Add force according to current direction (Even if the current direction does not match intended destination)
            rb.AddForce(ForwardForce * transform.forward);

            ///This is where the wierd floaty feeling comes from, this is what makes the eagle feel natural
        }

        //Not moving
       if (Input.GetKeyUp(KeyCode.W)) 
       {

            //Debug.Log("Released W");
            //normalizeWingFlap();
            //Ensure dive is left once speed normalizes
            if(current_speed < 22.5f)
            {
                animator.leaveDive();
            }

            //Get current velocity
            Vector3 velocity = gameObject.GetComponent<Rigidbody>().velocity;

            //if the eagle is moving downwards
            if (gameObject.transform.position.y <= lastPosition.y)
            {
                //Slow fall force and add more forward force
                rb.AddForce(7.0f * (transform.forward + Vector3.up)); //glide
            }

            //if the eagle is moving up
            else
            {
                //Slow forward force (by virtue of physics this also applies a downward force)
                rb.AddForce(2.0f * (transform.forward + Vector3.up)); //glide
            }
            
            //The fucking magic begins here

            //This whole thing makes the eagle not spinout bu countering the spin force by a certain deltaTime after it breaches 0.15 units of "drag"
            gameObject.GetComponent<Rigidbody>().angularDrag = initialAngularDrag;
            float nice = gameObject.GetComponent<Rigidbody>().drag;
            if(nice > 0.15f)
            {
                gameObject.GetComponent<Rigidbody>().drag = nice - Time.deltaTime;
            }
           
            //This ensures that the rotation calcultations above are actually applied prior to the next physics calculations
            //...at least partially
            float magnitude = velocity.magnitude;
            Vector3 orignialDirection = this.lastVelocity;
            Vector3 nowDirection = gameObject.GetComponent<Rigidbody>().velocity;
            Quaternion q = Quaternion.FromToRotation(orignialDirection, nowDirection);

            transform.rotation = Quaternion.RotateTowards(gameObject.transform.rotation, q * transform.rotation, magnitude / 10) ;

        }

       if (Input.GetKey(KeyCode.S))//brakes
       {
            //Ensure dive leaves the moment S is pressed
            animator.leaveDive();

            //set animator
            if (current_speed > 0.01)
            {
                float rate = current_speed / 20;//topspeed
                flapspeed *= rate;
                flapspeed = Mathf.Clamp(flapspeed, 11, 25);
                animator.SetFlapSpeed(flapspeed);
            }
            else
            {
                float rate = current_speed / 20;//topspeed
                flapspeed *= rate;
                flapspeed = Mathf.Clamp(flapspeed, 5, 20);
                animator.SetFlapSpeed(flapspeed);
            }


            //Force eagle to slow
            gameObject.GetComponent<Rigidbody>().drag = 10;


            //Get counter forward vector
            Vector3 crossVector = Vector3.Cross(Vector3.up, transform.right);

            //Calcutalte "backwards" vector in context of eagle with normalization to avoid gimballing
            Vector3 direction = ((transform.forward + (-crossVector + Vector3.up)) + transform.forward).normalized;

            //Denote as direction quaternion
            Quaternion kwat = Quaternion.LookRotation(direction);

            //As the eagle brakes, the eagle also turns towards the "counter forwards"
            transform.rotation = Quaternion.RotateTowards(gameObject.transform.rotation, kwat, 1.0f);
        }

       else
        {
            Debug.Log("Released S");
            //Set drag to normal as held prior to the pressing of S
            gameObject.GetComponent<Rigidbody>().drag = initialDrag;
            normalizeWingFlap();
        }

        /*
        //Upon release of "S"
        else
        {
            //Set drag to normal as held prior to the pressing of S
           // gameObject.GetComponent<Rigidbody>().drag = initialDrag;
            //normalizeWingFlap();
           
        }*/

        //reset calclation initials to preserve accuracy for the next frame
        this.lastPosition = gameObject.transform.position;
        this.lastVelocity = gameObject.GetComponent<Rigidbody>().velocity;
    }

    private void normalizeWingFlap()
    {
        //check if velocity is still moving
        //Calculate new bird flap speed
        float rate = current_speed / 20;//topspeed
        flapspeed *= rate;

        //lerpVal = Mathf.Lerp(flapspeed, 1, Time.deltaTime);
        flapspeed = Mathf.Clamp(flapspeed, 3, 9);
        animator.SetFlapSpeed(flapspeed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //REPEL THE GODDAMN FLOOR
        //using tags to preserve throughout scenes
        if (collision.gameObject.CompareTag("Flour"))
        {
            //gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * 30, ForceMode.Impulse);
            ifFloorHit();
        }
                
        //Get hurt
        if (collision.gameObject.name.Contains("Bullet"))
            Hurt(10);
    }

    public void Hurt(int pain)
    {
        currhealth -= pain;

        //Update UI
        setHealthPercent();
    }

    void setHealthPercent()
    {
        float healthPercent = (currhealth / maxhealth);
        healthBar.fillAmount = healthPercent;

        if(healthPercent <= 0)
        {
            //If he died then demo ends U wU
            SceneManager.LoadScene("GameOver");
        }
    }

    public void ifFloorHit()
    {
        //Apply pain
        Hurt(2);

        //Get speed at which the eagle smacked the ground
        float speed = Vector3.Distance(lastPosition, transform.position);
        Rigidbody rb = gameObject.GetComponent<Rigidbody>();

        //Forcefully face eagle a bit more skyward
        Vector3 rotateVec = transform.rotation.eulerAngles;

        //Using Quaternions just in case so we don't gimball the eagle into the ground
        Quaternion target = Quaternion.Euler(-rotateVec.x, rotateVec.y, 0);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, target, speed * Time.deltaTime); //fuckin slerp me20.0f
        transform.rotation = target;


        //Remove active velocity for both linear and angular so that the eagle doesn't freeze or super boost
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;


        //Literally teleport upwards a bit
        Vector3 someposition = transform.position;
        someposition.y = someposition.y + 0.5f;
        transform.position = someposition;

        //Set new force using the new forward direction to give the player time to course correct themselves
        rb.AddForce(0.015f * (target.eulerAngles - this.transform.forward), ForceMode.Impulse);
    }
}
