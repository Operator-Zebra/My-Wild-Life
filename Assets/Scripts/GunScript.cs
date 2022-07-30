using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    public GameObject Proj;
    public GameObject Muzzel;
    public int MagazineCap = 5;
    public int BulletNum = 5;
    public ParticleSystem MuzzelFlash;
    public Rigidbody projectile;
    public float speed = 20;

    public Transform IdlePos;
    public Transform AdsPos;
    public Transform ReloadPos;
    public float lerpTime = 0.5f;

    public float fireRate = 0.5F;
    private float nextFire = 0.0F;

    public bool IsAds = false;
    public bool IsReloading = false;
    public bool IsIdle = true;

    

    // Update is called once per frame
    void Update ()
    {
        //Fire Gun on left mouse press if gun has ammo
        if (Input.GetButtonDown("Fire1") && IsAds == true && (BulletNum > 0) && Time.time > nextFire)
        {
            Rigidbody instantiatedProjectile = Instantiate(projectile,Muzzel.transform.position,transform.rotation)as Rigidbody;
            instantiatedProjectile.velocity = transform.TransformDirection(new Vector3(0, 0,speed));
            MuzzelFlash.Play();
            nextFire = Time.time + fireRate;
            BulletNum = BulletNum - 1;
        }
    
        if (IsAds == true)
        {
            //ADS to Idle
            if (Input.GetButtonDown("Fire2") && (IsAds == true && IsIdle == false))
            {
                IsIdle = true;
                IsAds = false;
                IsReloading = false;

            }
            //ADS to Reload
            if (Input.GetKey(KeyCode.R) && IsReloading == false)
            {
                IsReloading = true;
                IsAds = false;
                IsIdle = false;
            }
        }
        else if (IsAds == false)
        {
            //Idle to ADS
            if (Input.GetButtonDown("Fire2") && (IsAds == false && IsIdle == true))
            {
                IsAds = true;
                IsReloading = false;
                IsIdle = false;
            }
            ///Reloading to Idle
            if (Input.GetButtonDown("Fire2") && (IsIdle == false && IsReloading == true))
            {
                IsAds = false;
                IsReloading = false;
                IsIdle = true;
            }

            //Idle to Reload
            if (Input.GetKey(KeyCode.R) && IsReloading == false)
            {
                IsReloading = true;
                IsAds = false;
                IsIdle = false;
            }

        }


    }

    void LateUpdate()
    {

        //Idle to Ads
        if (IsAds == true)
        {
            transform.position = Vector3.Lerp(transform.position, AdsPos.position, lerpTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, AdsPos.rotation, lerpTime);
            
        }
        //To Realoding Position
        if  (IsReloading == true)
        {
            transform.position = Vector3.Lerp(transform.position, ReloadPos.position, lerpTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, ReloadPos.rotation, lerpTime);
            BulletNum = MagazineCap;
        }
        if  (IsIdle == true)
        {
            transform.position = Vector3.Lerp(transform.position, IdlePos.position, lerpTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, IdlePos.rotation, lerpTime);
            
        }

    }
}
