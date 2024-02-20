using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Animations;
public class Enemy : MonoBehaviour
{
    private StateMachines stateMachine;
    private NavMeshAgent agent;
     private GameObject player;
     private Vector3 lastpos;
    public NavMeshAgent Agent{get=>agent;}
    public GameObject Player{get=>player;}
    public Vector3 Lastpos{get=>lastpos;set=>lastpos=value;}
    [SerializeField]
    private string currentState;
    public Path path;
    [Header("Sight Values")]
    public float sightDistance=10f;
    public float fieldOfView=90f;
     public float eyeHeight;
    [Header("Weapon Values")]
    public Transform gunBarrel;
    [Range(0.1f,10)]
    public float fireRate;
     public float sphereCastRadius = 1f;

    void Start()
    {
        stateMachine=GetComponent<StateMachines>();
        agent=GetComponent<NavMeshAgent>();
        stateMachine.Initialise();
        player = GameObject.FindGameObjectWithTag("Player");

    }

    void Update()
    {
        CanSeePlayer();
        currentState=stateMachine.activeState.ToString();
    }
  public bool CanSeePlayer()
    {
        if(player!=null)
        {
            if(Vector3.Distance(transform.position,player.transform.position)<sightDistance)
            {
                Vector3 targetDirection=player.transform.position-transform.position-(Vector3.up*eyeHeight);
                float angleToPlayer=Vector3.Angle(targetDirection,transform.forward);
                if(angleToPlayer>=-fieldOfView && angleToPlayer<=fieldOfView)
                {
                    Ray ray=new Ray(transform.position+(Vector3.up*eyeHeight),targetDirection);
                    Debug.DrawRay(ray.origin,ray.direction*sightDistance);
                }
            }
        }
        return true;
    }

}
