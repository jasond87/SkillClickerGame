using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPlayer : MonoBehaviour
{    
    public float nextAttack;    
    public PlayerStats playerStats;
    private EnemyStats enemyStats;
    private GameObject thePlayer;
    public GameObject damageNumber;

    public bool attackPlayer;
    // Start is called before the first frame update
    void Start()
    {
        enemyStats = GetComponent<EnemyStats>();
        nextAttack = 0.1f;
        thePlayer = GameObject.Find("2dHero");
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject != null && nextAttack <= 0)
        {
            if (attackPlayer)
            {

                EnemyAttackPlayer(enemyStats.strength, "Player");                
                nextAttack = enemyStats.attackSpeed;

            }
        }

        if (attackPlayer)
        {
            if (nextAttack > 0)
            {

                nextAttack -= Time.deltaTime;

            }
        }
    }


    private void EnemyAttackPlayer(int totalDamage, string damageType)
    {
        var clone = (GameObject)Instantiate(damageNumber, thePlayer.transform.position, Quaternion.Euler(Vector3.zero));


        if (damageType == "Player")
        {
            clone.GetComponent<FloatingNumbers>().displayNumber.color = Color.red;

            clone.GetComponent<FloatingNumbers>().damageNumber = totalDamage;
        }

        Debug.Log("player strenght is acknowledged as :" + totalDamage);
        playerStats.playerCurrentHealth -= totalDamage;
        Debug.Log("Total life: " + playerStats.playerCurrentHealth);
    }
}
