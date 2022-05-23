using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public Transform prefabToSpawn;
    public int objectCount = 50;
    public float spawnRadius = 5;
    public float spawnCollisionCheckradius =1.5f;
    

 void Start(){

        for (int loop = 0; loop < objectCount; loop++)
        {
            Vector3 spawnPoint = transform.position + Random.insideUnitSphere * spawnRadius;
            if (!Physics.CheckSphere(spawnPoint, spawnCollisionCheckradius))
            {
                Instantiate(prefabToSpawn, spawnPoint, transform.rotation);
            }
        }

    }

}
