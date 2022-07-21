using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    
    public static InventorySystem instance;
    public GameObject itemPlacement;
    GameObject newItem;

    public GameObject[] toolbarItems;

    public enum Toolbar
    {
        EmptyHand = 0,
        Primary = 1,
        Secondary = 2,
        Tertiary = 3
    }

    public Toolbar currentItemHeld = Toolbar.EmptyHand;

    void Awake()
    {
        if (instance == null) instance = this;
    }


    void Start()
    {
        GameObject newItem = Instantiate(toolbarItems[0], itemPlacement.transform.position, itemPlacement.transform.rotation, itemPlacement.transform.parent);
    }

    void Update()
    {
        if (Input.GetKeyDown("`")) ShowItemInHand(0);
        else if (Input.GetKeyDown("1")) ShowItemInHand(1);
        else if (Input.GetKeyDown("2")) ShowItemInHand(2);
        else if (Input.GetKeyDown("3")) ShowItemInHand(3);
        else if (Input.GetKeyDown("4")) ShowItemInHand(4);
        else if (Input.GetKeyDown("5")) ShowItemInHand(5);
        else if (Input.GetKeyDown("6")) ShowItemInHand(6);
        else if (Input.GetKeyDown("7")) ShowItemInHand(7);
        else if (Input.GetKeyDown("8")) ShowItemInHand(8);
        else if (Input.GetKeyDown("9")) ShowItemInHand(9);
        else if (Input.GetKeyDown("0")) ShowItemInHand(10);
    }

    public void ShowItemInHand(int numOfItem)
    {
        Destroy(newItem);
        newItem = Instantiate(toolbarItems[numOfItem], itemPlacement.transform.position, itemPlacement.transform.rotation, itemPlacement.transform.parent);
    }
}