using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carSpawner : MonoBehaviour
{
    public GameObject car;
    public float maxPos = 2.2f;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 carPos = new Vector3(Random.Range(-2.2f, 2.2f), transform.position.y, transform.position.z);
        Instantiate(car, carPos, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
