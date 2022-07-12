using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ui : MonoBehaviour
{

    public GameObject MenuUi;
    private bool MenuActive = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && MenuActive == false)
        {
            MenuUi.SetActive(true);
            MenuActive = true;
            Cursor.visible = true;
        }

        if (Input.GetKeyDown(KeyCode.Escape) && MenuActive == true)
        {
            MenuUi.SetActive(false);
            MenuActive = false;
            Cursor.visible = false;

        }
    }
}
