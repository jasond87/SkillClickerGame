using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsStop : MonoBehaviour
{

    public float physicsDuration;
    private float physicsCountDown;


    private void Start()
    {
        physicsCountDown = Random.Range(0.25f, physicsDuration);

    }
    private void Update()
    {
        physicsCountDown -= Time.deltaTime;

        if (physicsCountDown <= 0) {
            gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }






}
