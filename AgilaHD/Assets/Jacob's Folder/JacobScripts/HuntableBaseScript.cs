using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
/*
 Concerned with Movement and Health of the Huntables will probably also have other behaviour in the future
 
 
 */
public class HuntableBaseScript : MonoBehaviour
{
    [SerializeField] int Health = 1;
    public float jumpTime = 0;
    public int bounceInterval = 5;

    public bool moving = false;
    public float speed;

    public Vector3 Target;
    private Vector3 lastForce;

    public float thrust = 1.0f;

    private float myX;
    private float myZ;

    bool isEaten;
    public bool isPaused = false;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        //Ascertain starting position
        myX = gameObject.transform.position.x;
        myZ = gameObject.transform.position.z;
        isEaten = false;

        rb = gameObject.GetComponent<Rigidbody>();
        //Give self to ~god~ the interactible manager
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //This is terrible implementation...Too Bad!
        //Do only if not paused
        if (isPaused)
        {
            rb.Sleep();
            return;
        }

        //Once the bunny has stopped moving
        if (rb.velocity.magnitude <= 0.1f)
        {
            //Allow counter to start again
            moving = false;
        }

        //Calculate time till next move, if not moving
        if (!moving)
        {
            //timer += Time.deltaTime;
            jumpTime += Time.deltaTime;
        }

        if (jumpTime >= bounceInterval)
        {
            //Reset jump timer
            jumpTime = 0;

            //Ask for new target
            newTarget();

            //Apply upwards force first
            rb.AddForce(Vector3.up * 10, ForceMode.Impulse);

            //Apply x-ward and z-ward force next
            rb.AddForce(Target, ForceMode.Impulse);
        }
    }

    void newTarget()
    {
        //Calculate direction vector for where to jump to
        float xPos = Random.Range(-10, 10);
        float zPos = Random.Range(-10, 10);

        if(xPos < 0 && xPos > -5.0f)
        {
            xPos = -5.0f;
        }

        else if(xPos > 0 && xPos < 5.0f)
        {
            xPos = 5.0f;
        }

        if (zPos < 0 && zPos > -5.0f)
        {
            zPos = -5.0f;
        }

        else if (zPos > 0 && zPos < 5.0f)
        {
            zPos = 5.0f;
        }

        //Look at new destination position
        Vector3 offset = new Vector3(transform.position.x + xPos, transform.position.y, transform.position.z + zPos);
        transform.LookAt(offset);

        //Give new target, with 0'd Y 
        Target = new Vector3(xPos, 0, zPos);

        moving = true;
    }

    void gotEaten() //for when it gets eaten by player
    {
       
        gameObject.SetActive(false);
    }

    public int giveHealth()
    {
        int addHealth = 20;

        return addHealth;
    }

    public void Pause()
    {
        //Destroy(rb);
        lastForce = rb.velocity;
        isPaused = true;
    }

    public void Unpause()
    {
        //rb = gameObject.AddComponent<Rigidbody>();
        //rb.constraints = lastState;
        isPaused = false;
        rb.velocity = lastForce;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "HuntCollider")
        {
            gotEaten();
        }
    }
}
