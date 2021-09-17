using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiShootState : AiState
{
    private float maxTimeToShoot = 2.0f;
    private float timeToShoot = 0;
    public void Enter(AiAgent agent)
    {
        Debug.Log("Entered shoot mode");
        agent.animator.SetInteger(agent.AnimationName, (int)AiAgent.ANIMATIONSTATE.aim);
        timeToShoot = maxTimeToShoot;

        agent.weaponikReference.setShootMode(true);
    }

    public void Exit(AiAgent agent)
    {
        agent.weaponikReference.setShootMode(false);
        Debug.Log("Exited shoot mode");
    }

    public AiStateId GetId()
    {
        return AiStateId.Shoot;
    }

    public void Update(AiAgent agent)
    {
        timeToShoot -= Time.deltaTime;
        if(timeToShoot < 0)
        {
            agent.weaponikReference.playMuzzleFlash();
            timeToShoot = maxTimeToShoot;
        }
    }
}
