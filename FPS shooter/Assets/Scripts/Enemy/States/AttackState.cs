using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : BaseState
{
    private float moveTimer;
    private float losePlayerTimer;
    public float waitBeforeSearchTime = 7f;
    public float bulletSpeed=40f;
    private float shotTimer;

    public override void Enter()
    {
        losePlayerTimer = 0;
    }
    public override void Exit()
    {
        moveTimer = 0;
        losePlayerTimer = 0;
    }
    public override void Perform()
    {
        if (enemy.CanSeePlayer())
        {
            losePlayerTimer = 0;
            moveTimer += Time.deltaTime;
            shotTimer+=Time.deltaTime;
            enemy.transform.LookAt(enemy.Player.transform);
            if(shotTimer>enemy.fireRate)
            {
                Shoot();
            }
            if (moveTimer > Random.Range(4, 10))
            {
                enemy.Agent.SetDestination(enemy.transform.position + Random.insideUnitSphere * 6);
                moveTimer = 0;
            }
            enemy.Lastpos=enemy.Player.transform.position;
        }
        else
        {
            losePlayerTimer += Time.deltaTime;
            if (losePlayerTimer > waitBeforeSearchTime)
            {
                stateMachine.ChangeState(new SearchState());
            }
        }
    }
public void Shoot()
{
    Transform gunbarrel=enemy.gunBarrel;
    GameObject bullet=GameObject.Instantiate(Resources.Load("Prefabs/Bullet")as GameObject,gunbarrel.position,enemy.transform.rotation);
    Vector3 shootDirection=(enemy.Player.transform.position-gunbarrel.transform.position).normalized;
    bullet.GetComponent<Rigidbody>().velocity=Quaternion.AngleAxis(Random.Range(-2f,2f),Vector3.up)*shootDirection*bulletSpeed;
    //Debug.Log("Shoot");
    shotTimer=0;
}
}
