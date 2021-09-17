using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIScript : MonoBehaviour
{
    public Animator animator;
    public bool targetFound;
    private enum ANIMATIONSTATE { 
    idle = (int)0,
    run = (int)1,
    aim = (int)2,
    };

    private string AnimationName = "AIState";

    // Start is called before the first frame update
    void Start()
    {
        if(animator == null)
        animator = gameObject.GetComponent<Animator>();
        targetFound = false;



    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (targetFound)
        {
            //shoot birb
            return;
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            animator.SetInteger(AnimationName, (int)ANIMATIONSTATE.idle);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            animator.SetInteger(AnimationName, (int)ANIMATIONSTATE.run);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            animator.SetInteger(AnimationName, (int)ANIMATIONSTATE.aim);
        }

        


    }
}
