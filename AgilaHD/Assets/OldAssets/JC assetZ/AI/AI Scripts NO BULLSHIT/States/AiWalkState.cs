using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiWalkState : AiState
{
    private float walkTime = 0.0f;
    private float force = 2.0f;
    private float maxRotateTime = 5;
    private Quaternion finalRotation;
    private float randomAngle;
    
    private enum SUBSTATE
    {
        rotating,
        walking,
    }
    SUBSTATE substate;

    public void Enter(AiAgent agent)
    {
        Debug.Log("Entered walk state");
        agent.animator.SetInteger(agent.AnimationName, (int)AiAgent.ANIMATIONSTATE.run);
        walkTime = Random.Range(agent.config.minWalkTIme, agent.config.maxWalkTime);
        randomAngle = Random.Range(agent.config.minAngle, agent.config.maxAngle);
        finalRotation = Quaternion.Euler(0, randomAngle, 0);
        maxRotateTime = 5;
        substate = SUBSTATE.rotating;
    }

    public void Exit(AiAgent agent)
    {
        Debug.Log("Exited walk state");
        //agent.stateMachine.ChangeState(AiStateId.Idle);
    }

    public AiStateId GetId()
    {
        return AiStateId.Walk;
    }

    public void Update(AiAgent agent)
    {
        if (!agent.enabled)
        {
            return;
        }

       if(substate == SUBSTATE.rotating)
        {
            Quaternion currentRotation = agent.transform.rotation;
            //floating point comparison bug idgaf 
            float currY = Mathf.Abs(currentRotation.y);
            float finalY = Mathf.Abs(finalRotation.y);

            if (currY != finalY || maxRotateTime < 0)
            { 
                agent.transform.rotation = Quaternion.Slerp(currentRotation, finalRotation, agent.config.turnSpeed * Time.deltaTime);
            }
            //rotateTime -= Time.deltaTime;

            else
            {
                //Debug.Log("Done Rotating");
                substate = SUBSTATE.walking;
            }
            /*if(rotateTime <= 0)
            {
                Debug.Log("Done Rotating");
                substate = SUBSTATE.walking;
            }*/
            maxRotateTime -= Time.deltaTime;
        }
       
        if(substate == SUBSTATE.walking)
        {
            if (walkTime > 0)
            {
                Vector3 agentVec = agent.transform.position;
                Transform agentTransform = agent.transform;
                if (agent.isMovable)
                {
                    agent.rb.velocity = agentTransform.forward * force;
                }
            
                //Debug.Log(walkTime);
            }
            walkTime -= Time.deltaTime;
            if (walkTime <= 0)
            {
                //Debug.Log("Done Walking");
                //walkTime = Random.Range(agent.config.minWalkTIme, agent.config.maxWalkTime);
                agent.stateMachine.ChangeState(AiStateId.Idle);
            }
        }
        
        
        
    }
}
