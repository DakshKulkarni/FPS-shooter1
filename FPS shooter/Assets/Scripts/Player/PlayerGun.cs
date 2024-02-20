using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : MonoBehaviour
{
    public float range=100f;
    public float damage=50f;
    public float impactForce=100f;
    public float fireRate=15f;
    public float fireTimer=0f;
    public int maxAmmo=20;
    private int currentAmmo;
    public float reloadTime=2f;
    public Camera fps;
    private bool isReloading=false ;
    void Start()
    {
            currentAmmo=maxAmmo;   
    }
    
    void Update()
    {
        if(isReloading)
        return;
        if(currentAmmo<=0)
        {
            StartCoroutine(Reload());
            return;
        }
       if(Input.GetButton("Fire1")&&Time.time>=fireTimer)
       {
        fireTimer=Time.time +(1/fireRate);
            GunShoot();

       }
    }
    IEnumerator Reload()
    {
        isReloading=true;
        Debug.Log("Reloading");
        yield return new WaitForSeconds(reloadTime);
        currentAmmo=maxAmmo;
        isReloading=false; 

    }
     void GunShoot()
    {
        currentAmmo--;
        RaycastHit hitInfo;
       if( Physics.Raycast(fps.transform.position,fps.transform.forward,out hitInfo,range))
       {
           // Debug.Log("NEW"+hitInfo.transform.name);
            BulletDamage bulletDamage=hitInfo.transform.GetComponent<BulletDamage>();
            if(bulletDamage!=null)
            {
                bulletDamage.enemyDamage(damage);
            }
            if(hitInfo.rigidbody!=null)
            {
                hitInfo.rigidbody.AddForce(-hitInfo.normal*impactForce);
            }
       }
    }
}
