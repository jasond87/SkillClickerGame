using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSpace : MonoBehaviour
{
    private EnemyMovement enemyMovementScript;
    // Start is called before the first frame update
    void Start()
    {
        enemyMovementScript = GetComponentInParent<EnemyMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.tag);
        if (collision.tag == "Player" || collision.tag == "Enemy" || collision.tag == "EnemyMiniBoss")
        {
            enemyMovementScript.stopMoving = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player" || collision.tag == "Enemy" || collision.tag == "EnemyMiniBoss")
        {
            enemyMovementScript.stopMoving = false;
        }
    }
}
