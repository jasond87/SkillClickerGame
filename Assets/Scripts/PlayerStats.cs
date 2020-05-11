using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    public int playerMaxHealth;
    public int[] increaseLifeOnLevel;
    public int playerCurrentHealth;

    public int playerStrength;
    public int[] increaseStrengthOnLevel;

    public int playerDefense;
    public int[] increaseDefenseOnLevel;

    public int[] playerExperienceToLevel;
    public int currentExperience;
    public int playerCurrentLevel;

    // Start is called before the first frame update
    void Start()
    {
        playerCurrentHealth = playerMaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        LevelUpCharacter();

        if (playerCurrentHealth <= 0) {
            Debug.Log("Player died");
            Destroy(gameObject);
            
        }

      
    }
    

    void LevelUpCharacter()
    {

        if (playerCurrentLevel <= playerExperienceToLevel.Length)
        {

            if (currentExperience >= playerExperienceToLevel[playerCurrentLevel])
            {
                playerCurrentLevel++;
                playerMaxHealth += increaseLifeOnLevel[playerCurrentLevel - 1];
                playerCurrentHealth = playerMaxHealth; // TODO determined by additional things like other stats                    
                playerStrength += increaseStrengthOnLevel[playerCurrentLevel - 1];// TODO determined by additional things like other stats                    
                                                                                  //playerDefense = increaseDefenseOnLevel[playerCurrentLevel - 1];// TODO determined by additional things like other stats                    
            }
        }


    }

    public void AddExperience(int experienceToAdd)
    {

        currentExperience += experienceToAdd;

    }



}
