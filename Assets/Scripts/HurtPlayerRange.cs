using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayerRange : MonoBehaviour
{

    private PlayerStats thePlayerStats;
    private AttackPlayer attackPlayer;    
    // Start is called before the first frame update
    void Start()
    {
        thePlayerStats = GameObject.Find("GameManager").GetComponent<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy" || collision.tag == "EnemyMiniBoss")
        {
            attackPlayer = collision.GetComponent<AttackPlayer>();
            attackPlayer.attackPlayer = true;
            attackPlayer.playerStats = thePlayerStats;
        }

    }
}
