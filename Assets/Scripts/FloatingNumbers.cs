using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingNumbers : MonoBehaviour
{

    public float moveSpeed;
    public int damageNumber;
    public Text displayNumber;
    private Rigidbody2D floatingTextBody;
    
    // Start is called before the first frame update
    void Start()
    {
        floatingTextBody = GetComponent<Rigidbody2D>();
        transform.position = new Vector3(transform.position.x +0.5f, transform.position.y + 0.5f, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        displayNumber.text = damageNumber.ToString();
        floatingTextBody.velocity = new Vector3((moveSpeed * Time.deltaTime / 2), moveSpeed * Time.deltaTime, transform.position.z);
        

    }
}
