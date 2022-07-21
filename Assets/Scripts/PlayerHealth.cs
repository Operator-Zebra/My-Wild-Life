using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public int PlayerHp = 100;
    public int PlayerEP = 100;

    public Slider HealthBar;

    void Start()
    {
        PlayerHp = 100;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerHp <= 0)
        {
            KillPlayer();
        }


    }

    void KillPlayer()
    {
        Debug.Log("You Are Dead!");
    }

    public void SetMaxHealth(int health)
    {
        Debug.Log("You have been fully healed!");
        HealthBar.maxValue = health;
        HealthBar.value = health;
    }

    //Gives you 10 to 75 health depending on which
    void HealPlayer(int health)
    {
        Debug.Log("You have been healed!");
    }

    //Takes 10 to 50 health
    void InjerPlayer(int health)
    {
        Debug.Log("You have been injered!");
    }

    //Takes 50 to 80 health
    void SeverlyInjerPlayer(int health)
    {
        Debug.Log("You have been severly injered!");
    }

}
