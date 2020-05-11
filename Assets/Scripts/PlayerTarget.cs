using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTarget : MonoBehaviour
{

    private AttackPlayer attackPlayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Attack Range collision with " + collision.tag);
        if (collision.tag == "Enemy" || collision.tag == "EnemyMiniBoss") {
            attackPlayer = collision.GetComponent<AttackPlayer>();
            attackPlayer.EnemyAttackPlayer(attackPlayer.enemyStats.strength, "Player");
            attackPlayer.timeUntilNextAttack = attackPlayer.enemyStats.attackSpeed;
        }
    }


}
