using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiIdleState : AiState
{
    private float idleMaxTime = 10;
    private float idleMinTime = 4;
    private float waitTime;
    public void Enter(AiAgent agent)
    {
        Debug.Log("Entered idle state");
        agent.animator.SetInteger(agent.AnimationName, (int)AiAgent.ANIMATIONSTATE.idle);
        waitTime = Random.Range(idleMinTime, idleMaxTime);
    }

    public void Exit(AiAgent agent)
    {
        
    }

    public AiStateId GetId()
    {
        Debug.Log("Exited idle state");
        return AiStateId.Idle;
    }

    public void Update(AiAgent agent)
    {
       if(waitTime > 0)
        {
            //do something idling
        }
        waitTime -= Time.deltaTime;
       if(waitTime <= 0)
        {
            agent.stateMachine.ChangeState(AiStateId.Walk);
            Debug.Log("Done Idleing");
        }

    }

    
}
