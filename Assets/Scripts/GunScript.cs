using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    public GameObject Proj;
    public GameObject Muzzel;
    public float BulletLifeTime = 500;
    public float BulletSpeed = 500;
    public ParticleSystem MuzzelFlash;



    public Rigidbody projectile;
    public float speed = 20;
 
    // Update is called once per frame
    void Update ()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Rigidbody instantiatedProjectile = Instantiate(projectile,Muzzel.transform.position,transform.rotation)as Rigidbody;
            instantiatedProjectile.velocity = transform.TransformDirection(new Vector3(0, 0,speed));
            MuzzelFlash.Play();
        }
    }
}
