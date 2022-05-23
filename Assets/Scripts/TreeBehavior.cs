using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeBehavior : MonoBehaviour
{
    public static TreeBehavior instance;

    public int currentIndex = 0;
    public int poolSize = 50;

    public GameObject[] treePool;
    public GameObject treePrefab;

    public float negativePos = -20f;
    public float positivePos = 20f;
    public float timeToSpawn = 100f;
    private float currentTimeToSpawn;
    public float spawnCollisionCheckradius;

    public enum TreeStage
    {
        Seedling = 0,
        Sappling = 1,
        YoungTree = 2,
        SmallTree = 3,
        AdultTree = 4,
        SnagTree = 5,
        Stump = 6
    }

   
    // Update is called once per frame
    void Update()
    {
        
    }

}
