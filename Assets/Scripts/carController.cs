using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carController : MonoBehaviour
{
    public float carSpeed;
    public float maxPos = 2.2f;

    public uiManager ui;
    public audioManager audio;
    bool currentPlatformAndroid = false;

    Vector3 position;
    Rigidbody2D rigidbody2D;

    void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();

        #if UNITY_ANDROID

                currentPlatformAndroid = true;
        #else

                currentPLatformAndroid = false;
        #endif

        audio.carSound.Play();
    }



    // Start is called before the first frame update
    void Start()
    {
        
        position = transform.position;

        if (currentPlatformAndroid == true)
        {
            Debug.Log("Android");
        }

        else
        {
            Debug.Log("Not Android");
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentPlatformAndroid == true)
        {
            AcceleromemterMove();
        }
        else
        {
            position.x += Input.GetAxis("Horizontal") * carSpeed * Time.deltaTime;
            position.x = Mathf.Clamp(position.x, -2.2f, 2.2f);
            transform.position = position;
        }
        position = transform.position; 
        position.x = Mathf.Clamp(position.x, -2.2f, 2.2f);
        transform.position = position;

    }


    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy Car")
        {
            //Destroy(gameObject);
            gameObject.SetActive(false);
            ui.GameOverActivated();
            audio.carSound.Stop();
        }
    }

    public void MoveRight()
    {
        rigidbody2D.velocity = new Vector2(carSpeed, 0);
    }

    public void MoveLeft()
    {
        rigidbody2D.velocity = new Vector2(-carSpeed, 0);
    }

    public void SetVelocityToZero()
    {
        rigidbody2D.velocity = Vector2.zero;
    }
    void AcceleromemterMove()
    {
        float x = Input.acceleration.x;
        Debug.Log("X =" + x);
        if (x < -0.1f)
        {
            MoveLeft();
        }
        else if (x > 0.1f)
        {
            MoveRight();
        }
        else
        {
            SetVelocityToZero();
        }
    }
}
