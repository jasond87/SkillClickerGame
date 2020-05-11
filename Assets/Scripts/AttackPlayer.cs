using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPlayer : MonoBehaviour
{    
    public float nextAttack;
    public float timeUntilNextAttack;
    public PlayerStats playerStats;
    public  EnemyStats enemyStats;
    private GameObject thePlayer;
    public GameObject damageNumber;
    public EnemyMovement enemyMovement;
    public Vector3 recordedStopPosition;
    public Vector3 moveToPlayer;
    public Vector3 currentDirection;
    private float movementSpeed = 5f;
    private bool firstAttack;
   

    public bool attackPlayer;
    // Start is called before the first frame update


    void Start()
    {
        enemyMovement = GetComponent<EnemyMovement>();
        enemyStats = GetComponent<EnemyStats>();
        nextAttack = 0.1f;
        thePlayer = GameObject.Find("2dHero");
        firstAttack = true;
    }   


    // Update is called once per frame
    void Update()
    {
       

        if (gameObject != null)
        {
            Debug.Log("Game object name is " + gameObject.name);
            if (attackPlayer)
            {
                if (recordedStopPosition == Vector3.zero && enemyMovement.stopMoving == true)
                {
                    Debug.Log("setting current position as " + gameObject.transform.position);
                    recordedStopPosition = new Vector3(Random.Range(gameObject.transform.position.x, gameObject.transform.position.x +1f), Random.Range(gameObject.transform.position.y, gameObject.transform.position.y + 1f),0f);

                    Debug.Log("setting player position as " + thePlayer.transform.position);
                    moveToPlayer = thePlayer.transform.Find("PlayerTarget").transform.position;
                }              

            }
        }

        if (attackPlayer && recordedStopPosition != Vector3.zero) 
        {

            MoveTowardsPlayer();

        }



    }

    public void MoveTowardsPlayer() {
      
            if (gameObject.transform.position == recordedStopPosition)
            {
                timeUntilNextAttack -= Time.deltaTime;
            }

            if (timeUntilNextAttack <= 0)
            {
                //nextAttack -= Time.deltaTime;
                if (moveToPlayer != null)
                {
                    // Debug.Log(gameObject.transform.position == currentPosition);                   

                    if (gameObject.transform.position == recordedStopPosition || firstAttack)
                    {
                        Debug.Log("Moving towards player");
                        currentDirection = moveToPlayer;
                    firstAttack = false;
                        //  transform.Translate(moveToPlayer.position * movementSpeed * Time.smoothDeltaTime);
                    }
             
                    transform.position = Vector2.MoveTowards(transform.position, currentDirection, movementSpeed * Time.deltaTime);
              
                }

            }

            if (timeUntilNextAttack > 0)
            {
                //nextAttack -= Time.deltaTime;             
                {

                    if (gameObject.transform.position == moveToPlayer)
                    {
                        Debug.Log("Returning to original position");
                        currentDirection = recordedStopPosition;
                    }
                   
                        transform.position = Vector2.MoveTowards(transform.position, currentDirection, movementSpeed * Time.deltaTime);
                   
                }
            }        

    }


    


    public  void EnemyAttackPlayer(int totalDamage, string damageType)
    {
        var clone = (GameObject)Instantiate(damageNumber, thePlayer.transform.position, Quaternion.Euler(Vector3.zero));

    

        if (damageType == "Player")
        {
            clone.GetComponent<FloatingNumbers>().displayNumber.color = Color.red;

            clone.GetComponent<FloatingNumbers>().damageNumber = totalDamage;
        }

     //   Debug.Log("player strenght is acknowledged as :" + totalDamage);
        playerStats.playerCurrentHealth -= totalDamage;
     //   Debug.Log("Total life: " + playerStats.playerCurrentHealth);
    }
 
}
