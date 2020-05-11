using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeakness : MonoBehaviour
{
    public int weaknessLife;    
    public EnemyStats enemyStats;  

    void OnMouseDown()
    {
        Debug.Log("Child click");
        weaknessLife = enemyStats.OnChildClick(weaknessLife);
    }

    // Update is called once per frame
    void Update()
    {

        if (weaknessLife <= 0)
        {

            Destroy(gameObject);
            Debug.Log("Weakness destroyed");
            enemyStats.weaknessExists = false;

        }
       

    }
}
