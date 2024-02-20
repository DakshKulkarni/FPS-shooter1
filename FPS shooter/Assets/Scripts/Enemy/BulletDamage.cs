using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletDamage : MonoBehaviour
{
    public float health=500f;
    public void enemyDamage(float amount)
    {
        health-=amount;
        if(health<=0)
        {
            Dead();
        }
    }
    void Dead()
    {
        Destroy(gameObject);
    }
}
