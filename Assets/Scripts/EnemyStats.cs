using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyStats : MonoBehaviour
{

    public int maximumLife;
    private int currentLife;
    public int weaknessMaximumLife;
    private int weaknessCurrentLife;


    public int attackSpeed;
    public int strength;
    public int defense;

    public int rewardXP;
    private AttackPlayer attackPlayerScript;
    private Spawnpoint spawnPoint;
    public GameObject spawnLayer;
    public PlayerStats playerStats;

    public GameObject damageNumber;
    public GameObject slashAnimation;
    public GameObject coin;

    private EnemyWeakness enemyWeakness;


    private GameObject childGameObject;

    public float generateWeaknessTimer;
    public float generateWeaknessDuration;    
    public GameObject generatedWeakness;

    public bool weaknessExists;



    private void Awake()
    {
        AddWeaknessToEnemy();
    }

    // Start is called before the first frame update
    void Start()
    {

        currentLife = maximumLife;

        generateWeaknessTimer = Random.Range(generateWeaknessDuration, 8);

        attackPlayerScript = GetComponentInParent<AttackPlayer>();
        spawnPoint = GameObject.Find("MasterSpawner").GetComponent<Spawnpoint>();
        playerStats = GameObject.Find("GameManager").GetComponent<PlayerStats>();
        enemyWeakness = GetComponentInChildren<EnemyWeakness>();
        AddWeaknessToEnemy();



    }

    // Update is called once per frame
    void Update()
    {
        DestroyEnemy();
        generateWeaknessTimer -= Time.deltaTime;
    }


    public void DestroyEnemy()
    {

        if (currentLife <= 0)
        {
            attackPlayerScript.attackPlayer = false;
            playerStats.AddExperience(rewardXP);
            spawnPoint.ReduceCurrentEnemies();           
            DropLoot();
            Destroy(gameObject);
        }

    }

    public int OnChildClick(int childLife)
    {


        childLife -= playerStats.playerStrength * 2;
        DamageEnemy(playerStats.playerStrength * 2, "Weakness");
        Debug.Log("Child Life: " + childLife);
        Debug.Log("Parent Life: " + currentLife);

        return childLife;

    }

    private void OnMouseDown()
    {
        Instantiate(slashAnimation, transform.position, Quaternion.Euler(Vector3.zero));
        DamageEnemy(playerStats.playerStrength, "Normal");


    }


    private void DamageEnemy(int totalDamage, string damageType) {

        var clone = (GameObject)Instantiate(damageNumber, transform.position, Quaternion.Euler(Vector3.zero));


        if (damageType == "Weakness")
        {
            clone.GetComponent<FloatingNumbers>().displayNumber.color = Color.yellow;
        }

        if (generateWeaknessTimer <= 0) {
            GenerateWeakPoint();
        }

        clone.GetComponent<FloatingNumbers>().damageNumber = totalDamage;
        Debug.Log("player strenght is acknowledged as :" + totalDamage);
        currentLife -= totalDamage;
        Debug.Log("Total life: " + currentLife);

    }


    private void AddWeaknessToEnemy() {

        if (gameObject.tag == "EnemyMiniBoss")
        {

            Debug.Log("Enemy mini boss acknowledged");
            ApplyWeaknes(false);
        }
    }

    private void DropLoot() {

        var itemClone = (GameObject)Instantiate(coin, transform.position, Quaternion.Euler(Vector3.zero));

        //  itemClone.layer = spawnLayer.layer;

    }

    private void GenerateWeakPoint() {

        if (!weaknessExists) {
            GameObject generateWeakness = Instantiate(generatedWeakness, RandomPointInBounds(gameObject.GetComponent<BoxCollider2D>().bounds), Quaternion.identity);
            
            generateWeakness.transform.SetParent(gameObject.transform);            

            ApplyWeaknes(true);

            generateWeaknessTimer = generateWeaknessDuration;
            weaknessExists = true;
        }
    }

    private void ApplyWeaknes(bool randomlyGenerated) {

        for (int i = 0; i < transform.childCount; i++)
        {
            childGameObject = transform.GetChild(i).gameObject;
            if (childGameObject.GetComponent<EnemyWeakness>() == null && childGameObject.tag == "Weakness")
            {
                Debug.Log("Adding child script to child object: " + i);
                childGameObject.name = "Weak" + i;
                childGameObject.AddComponent<EnemyWeakness>().enemyStats = this;
                if (!randomlyGenerated)
                {
                    childGameObject.GetComponent<EnemyWeakness>().weaknessLife = weaknessMaximumLife;
                }
                else {
                    childGameObject.GetComponent<EnemyWeakness>().weaknessLife = maximumLife / 4;
                }
            }
        }

    }

    public static Vector3 RandomPointInBounds(Bounds bounds)
    {

        return new Vector3(
            Random.Range(bounds.min.x, bounds.max.x),
            Random.Range(bounds.min.y, bounds.max.y),
            -0.1f
        ); 
       
    }  

}
