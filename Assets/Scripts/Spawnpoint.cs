using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnpoint : MonoBehaviour
{

    public float timeBetweenSpawn;
    public float startTimeBetweenSpawn;
    public float decreaseTime;
    public float minTime;

    public int maximumEnemiesAtOnce;
    public int currentNumberOfEnemies;


    public int remainingEnemies;
    public int totalEnemiesInStage;
    private int totalSpawnedEnemies;
    private bool enemySpawned;


    public Transform[] allSpawnPoints;    
    private int spawnPointIterator;

    public GameObject[] enemyToSpawn;

    private void Start()
    {
        timeBetweenSpawn = startTimeBetweenSpawn;
        allSpawnPoints = GetAllChildSpawnPoints<Transform>();
        remainingEnemies = totalEnemiesInStage;

    }



    // Update is called once per frame
    private void Update()
    {
        if (currentNumberOfEnemies < maximumEnemiesAtOnce)
        {

            if (timeBetweenSpawn <= 0)
            {
                currentNumberOfEnemies++;
                totalSpawnedEnemies++;
                foreach (var enemy in enemyToSpawn)
                {
                    if (!enemySpawned)
                    {

                        if (totalSpawnedEnemies % 10 == 0 && enemy.tag == "EnemyMiniBoss")                            
                        {
                            SpawnEnemiesAcrossPoints(enemy);

                        }
                        else if (enemy.tag == "Enemy" && totalSpawnedEnemies % 10 != 0)
                        {
                            SpawnEnemiesAcrossPoints(enemy);
                        }
                    }

                }

                enemySpawned = false;



            }
            else
            {

                timeBetweenSpawn -= Time.deltaTime;
            }
        }

    }

    public void SpawnEnemiesAcrossPoints(GameObject enemy)
    {

        spawnPointIterator = Random.Range(0, allSpawnPoints.Length);
        foreach (Transform spawnPoint in allSpawnPoints)
        {

            if (allSpawnPoints[spawnPointIterator] == spawnPoint)
            {

                if (timeBetweenSpawn <= 0)
                {
                    var enemyClone = (GameObject)Instantiate(enemy, spawnPoint.position, Quaternion.identity);
                    Debug.Log("Drop loot layer = " + enemyClone.gameObject.layer);
                    enemyClone.GetComponent<EnemyStats>().spawnLayer = spawnPoint.gameObject;
                    enemyClone.layer = spawnPoint.gameObject.layer;
                    SetLayerRecursively(enemyClone, spawnPoint.gameObject.layer);
                    SetSortingLAyer(enemyClone, spawnPointIterator);

                }
                timeBetweenSpawn = startTimeBetweenSpawn;

                if (startTimeBetweenSpawn > minTime)
                {
                    startTimeBetweenSpawn -= decreaseTime;
                }
            }

            enemySpawned = true;
        }

    }

    public void ReduceCurrentEnemies()
    {
        currentNumberOfEnemies -= 1;
        remainingEnemies -= 1;
    }


    // Only return the child spawn points - not the inherited parent location.
    private T[] GetAllChildSpawnPoints<T>()
    {
        allSpawnPoints = gameObject.GetComponentsInChildren<Transform>();

        T[] path = new T[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            path[i] = transform.GetChild(i).GetComponent<T>();
        }

        return path;      
    }


    void SetLayerRecursively(GameObject obj, int newLayer)
    {
        if (null == obj)
        {
            return;
        }

        obj.layer = newLayer;

        foreach (Transform child in obj.transform)
        {
            if (null == child)
            {
                continue;
            }
            SetLayerRecursively(child.gameObject, newLayer);
        }
    }

    void SetSortingLAyer(GameObject obj, int sortingLayer)
    {
        if (null == obj)
        {
            return;
        }

        SpriteRenderer[] sprites = obj.GetComponentsInChildren<SpriteRenderer>();

        foreach (SpriteRenderer sprite in sprites) {

            sprite.sortingOrder = sortingLayer + 1;
        
        }

       
    }

}
