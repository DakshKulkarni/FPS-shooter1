using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : BaseState
{
    public int wpIndex;
    public float waitTimer;
    public override void Enter()
    {
        
    }
     public override void Perform()
    {
        PatrolCycle();
        if(enemy.CanSeePlayer())
        {
            stateMachine.ChangeState(new AttackState());
            
        }
    }
     public override void Exit()
    {
        
    }
    public void PatrolCycle()
    {
        if(enemy.Agent.remainingDistance<0.2f)
        {
            waitTimer+=Time.deltaTime;
            if(waitTimer>2)
            {
            if(wpIndex<enemy.path.waypoints.Count-1)
              wpIndex++;
              else 
              wpIndex=0;
              enemy.Agent.SetDestination(enemy.path.waypoints[wpIndex].position);
                waitTimer=0;
            }
        }
    }
}
