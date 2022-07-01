using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassGrowth : MonoBehaviour
{
    public float targetTime = 60.0f;
    public float resetTime = 60.0f;
    public GameObject itemPlacement;
    public GameObject SpawnedItem;
    public GameObject[] GrassPrefab;
    public int loopnumber = 0;
    public GameObject Mower;

    void Start()
    {
        SpawnedItem = Instantiate(GrassPrefab[0], itemPlacement.transform.position, itemPlacement.transform.rotation, itemPlacement.transform.parent);
    }

    void Update()
    {
        targetTime -= Time.deltaTime;

        if (targetTime <= 0.0f)
        {
            loopnumber++;
            timerEnded();
        }
    }

    void timerEnded()
    {
        Debug.Log("Timer ended happened");
        if (loopnumber == 0) ShowNextStage(0);
        else if (loopnumber == 1) ShowNextStage(1);
        else if (loopnumber == 2) ShowNextStage(2);
        else if (loopnumber == 3) ShowNextStage(3);

        targetTime = targetTime + resetTime;
    }

    public void ShowNextStage(int numOfItem)
    {
        Debug.Log("ShowNextStage happened");
        Destroy(SpawnedItem);
        SpawnedItem = Instantiate(GrassPrefab[numOfItem], itemPlacement.transform.position, itemPlacement.transform.rotation, itemPlacement.transform.parent);
    }

    private void OnTriggerEnter(Collider other)
    {   
        if (other.gameObject.CompareTag("Mower"))
        {
            loopnumber = 0;
            ShowNextStage(0);
        }
        
    }
}