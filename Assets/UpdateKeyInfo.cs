using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UpdateKeyInfo : MonoBehaviour
{

    PlayerStats playerStats;
    Inventory inventory;
    Text[] keyInfoUI;
    Spawnpoint spawnerInfo;
    public string[] keyInfoArray;

    void Start()
    {
        spawnerInfo = GameObject.Find("MasterSpawner").GetComponent<Spawnpoint>();
        playerStats = GameObject.Find("GameManager").GetComponent<PlayerStats>();
        keyInfoUI = gameObject.GetComponentsInChildren<Text>();
    }


    // Update is called once per frame
    void Update()
    {
        
        foreach (Text keyInfo in keyInfoUI) {



            switch (keyInfo.name) {

                case "TotalDPS":
                    keyInfo.text = playerStats.playerStrength.ToString();
                    break;

                case "TotalCurrency":
                    keyInfo.text = "0"; // Need to code currency.
                    break;

                case "RemainingXP":
                    keyInfo.text = "LVL: " +playerStats.playerCurrentLevel + " | " + playerStats.currentExperience.ToString() + " / " + playerStats.playerExperienceToLevel[playerStats.playerCurrentLevel].ToString();
                    break;
                case "TotalPremium":
                    keyInfo.text = "0"; // Need to code currency.
                    break;
                case "TotalMonstersRemaining":
                    keyInfo.text = spawnerInfo.remainingEnemies.ToString() +" / " + spawnerInfo.totalEnemiesInStage.ToString();
                    break;




            }
            
        
        }
      


    }
}
