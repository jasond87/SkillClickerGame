using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public Slider healthBar;
    private PlayerStats playerStats;
    // Start is called before the first frame update
    void Start()
    {
        playerStats = GameObject.Find("GameManager").GetComponent<PlayerStats>();      
    }

    // Update is called once per frame
    void Update()
    {       

        healthBar.maxValue = playerStats.playerMaxHealth;
        healthBar.value = playerStats.playerCurrentHealth;


    }
}
