using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carSpawner : MonoBehaviour
{
    public GameObject [] cars;
    public float maxPos = 2.2f;
    public float delayTimer = 1.0f;
    float timer;
    int carNo;

    // Start is called before the first frame update
    void Start()
    {
        timer = delayTimer;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Vector3 carPos = new Vector3(Random.Range(-2.2f, 2.2f), transform.position.y, transform.position.z);
            carNo = Random.Range(0, 4);
            Instantiate(cars[carNo], carPos, transform.rotation);
            timer = delayTimer;
        }
       
    }
}
