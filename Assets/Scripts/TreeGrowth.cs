using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeGrowth : MonoBehaviour
{
    public float targetTime = 60.0f;
    public float resetTime = 60.0f;
    public GameObject itemPlacement;
    public GameObject SpawnedItem;
    public GameObject[] TreePrefab;
    public int loopnumber = 0;
    public int StumpNumber = 6;

    void Start()
    {
        SpawnedItem = Instantiate(TreePrefab[0], itemPlacement.transform.position, itemPlacement.transform.rotation, itemPlacement.transform.parent);
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
        else if (loopnumber == 4) ShowNextStage(4);
        else if (loopnumber == 5) ShowNextStage(5);
        else if (loopnumber == 6) ShowNextStage(6);
        else Destroy(SpawnedItem);

        targetTime = targetTime + resetTime;
    }

    public void ShowNextStage(int numOfItem)
    {
        Destroy(SpawnedItem);
        SpawnedItem = Instantiate(TreePrefab[numOfItem], itemPlacement.transform.position, itemPlacement.transform.rotation, itemPlacement.transform.parent);
    }

    private void OnTriggerEnter(Collider other)
    {   
        if (other.gameObject.CompareTag("Mower") && loopnumber == 0)
        {
             Destroy(itemPlacement);
             Destroy(SpawnedItem);
        }
        if (other.gameObject.CompareTag("Axe") && loopnumber == 0)
        {
             Destroy(itemPlacement);
             Destroy(SpawnedItem);
        }
        if (other.gameObject.CompareTag("Axe"))
        {
            loopnumber = StumpNumber;
            Debug.Log("Cut Tree to Stump");
        }
     
    }
}