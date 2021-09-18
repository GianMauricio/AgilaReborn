using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiAgent : MonoBehaviour
{
    public AiStateMachine stateMachine;
    public AiStateId initialState;
    public AiAgentConfig config;

    //animator component
    public Animator animator;
    public enum ANIMATIONSTATE
    {
        idle = (int)0,
        run = (int)1,
        aim = (int)2,
    };

    public string AnimationName = "AIState";

    //Rigidbody component
    public Rigidbody rb;

    //Sphere Trigger component
    public SphereCollider sphereCollider;

    //Eagle reference
    public GameObject eagleReference;

    //WeaponIK script
    public WeaponIk weaponikReference;

    //moving agent?
    public bool isMovable = false;

    //check for the state
    public AiStateId currentStateRead;

    // Start is called before the first frame update
    void Start()
    {
        stateMachine = new AiStateMachine(this);
        stateMachine.ChangeState(initialState);

        //Register states
        stateMachine.RegisterState(new AiIdleState());
        stateMachine.RegisterState(new AiWalkState());
        stateMachine.RegisterState(new AiShootState());

        //components
        animator.GetComponent<Animator>();
        rb.GetComponent<Rigidbody>();
        sphereCollider.GetComponent<SphereCollider>();
        weaponikReference.GetComponent<WeaponIk>();

        //Eagle reference for the location and damage calls
        eagleReference = GameObject.FindGameObjectWithTag("Player");

        currentStateRead = stateMachine.currentState;
    }

    // Update is called once per frame
    void Update()
    {
        stateMachine.Update();
        
        
        /*if (Input.GetKeyDown(KeyCode.W))
        {
            stateMachine.ChangeState(AiStateId.Idle);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            stateMachine.ChangeState(AiStateId.Walk);
        }*/
        /*if (Input.GetKeyDown(KeyCode.E))
        {
            agent.animator.SetInteger(agent.AnimationName, (int)AiAgent.ANIMATIONSTATE.aim);
        }*/
    }


    private void OnTriggerEnter(Collider other)
    {
       if(other.tag == "Player")
            //if(this.stateMachine.currentState != AiStateId.Walk && this.stateMachine.currentState != AiStateId.Shoot && this.stateMachine.currentState == AiStateId.Idle)
           // {
                {
                    //Debug.Log("nice");
                    this.stateMachine.ChangeState(AiStateId.Shoot);
                }
           // }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" && this.stateMachine.currentState == AiStateId.Shoot)
        {
            //Debug.Log("idlestate now");
            this.stateMachine.ChangeState(AiStateId.Idle);
        }
    }
}
