using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShippingContainer : MonoBehaviour
{
    public GameObject Player;
    public GameObject TextUi;
    


    private void OnTriggerEnter(Collider other)
    {
        TextUi.SetActive(true);
    }
    
    private void OnTriggerExit(Collider other)
    {
        TextUi.SetActive(false);
    }
}
