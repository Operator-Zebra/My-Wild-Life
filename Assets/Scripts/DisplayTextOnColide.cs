using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayTextOnColide : MonoBehaviour
{
    public GameObject TextUi;
    


    private void OnTriggerEnter(Collider other)
    {   
        if (other.gameObject.CompareTag("Player"))
        {
                TextUi.SetActive(true);
        }
        
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
                TextUi.SetActive(false);
        }
    }
}
