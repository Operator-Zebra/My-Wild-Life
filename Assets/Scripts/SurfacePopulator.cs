 using UnityEngine;
 using System.Collections;
 
 public class SurfacePopulator {

    public GameObject cubePrefab;
    public int MaxSpawns = 30;
    public int LoopNum = 0;

    void Update() 
    {
        while(LoopNum <= MaxSpawns)
        {
            Vector3 randomSpawnPosition = new Vector3(Random.Range(-10, 11), 5, Random.Range(-10, 11));
            //Instantiate GameObject(cubePrefab, randomSpawnPosition, Quaternion.identity);
        }
    } 
 }