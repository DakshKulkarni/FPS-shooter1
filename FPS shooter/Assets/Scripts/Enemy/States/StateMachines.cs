using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StateMachines : MonoBehaviour
{
    public BaseState activeState;
    public void Initialise()
    {
        ChangeState(new PatrolState());
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(activeState!=null)
        {
            activeState.Perform();
        }
    }
    public void ChangeState(BaseState newState)
    {
        if(activeState!=null)
        {
            activeState.Exit();
        }
        activeState=newState;
        if(activeState!=null)
        {
            activeState.stateMachine=this;
            activeState.enemy=GetComponent<Enemy>();
            activeState.Enter();
        }
    }
}
