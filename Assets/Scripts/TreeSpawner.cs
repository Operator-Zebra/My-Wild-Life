using System.Collections;
using System.Collections.Generic;
//using UnityEngine.AI;
using UnityEngine;


public class TreeSpawner : MonoBehaviour
{

    public static TreeSpawner instance;
    //public NavMeshSurface suface;
    int currentIndex = 0;
    public int poolSize = 50;

    public GameObject[] treePool;
    public GameObject treePrefab;

    public float negativePos = -20f;
    public float positivePos = 20f;
    public float timeToSpawn;
    private float currentTimeToSpawn;

    void Awake()
    {
        if (instance == null) instance = this;
    }

    void Start()
    {
        //suface.BuildNavMesh();

        treePool = new GameObject[poolSize];
        for (int i = 0; i < poolSize; i++)
        {
            GameObject tree = Instantiate(treePrefab);
            tree.SetActive(false);
            treePool[i] = tree;
        }
    }

    private void Update()
    {
        if (currentTimeToSpawn > 0)
        {
            currentTimeToSpawn -= Time.deltaTime;
        }
        else
        {
            Spawn(new Vector3(Random.Range(negativePos, positivePos), 0.5f, Random.Range(negativePos, positivePos)));
            currentTimeToSpawn = timeToSpawn;
        }
    }

    public void Spawn(Vector3 pos)
    {
        GameObject tree = treePool[currentIndex];
        tree.transform.position = pos;
        tree.SetActive(true);
        currentIndex++;
        currentIndex %= poolSize;
    }


}