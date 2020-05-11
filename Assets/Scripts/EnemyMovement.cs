using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public float movementSpeed;
    public bool stopMoving;

    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (!stopMoving)
        {
            EnemyMoving();
        }          

    }
   

    public void EnemyMoving() {

        
        transform.Translate(Vector2.left * movementSpeed * Time.deltaTime);

    }

    


}
