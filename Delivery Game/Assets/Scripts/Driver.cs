using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField]
    float steerspeed=0.1f;
    [SerializeField]
    float movespeed = 0.01f;
    [SerializeField]
    float boostspeed = 20f;
    [SerializeField]
    float slowspeed = 5f;
    float counter=0.1f;
    AudioSource audio;
    


    // Update is called once per frame
    void Update()
    {

        float steerAmount = Input.GetAxis("Horizontal") *steerspeed *Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * movespeed * Time.deltaTime;

        transform.Translate(0,moveAmount,0);
        transform.Rotate(0,0,-steerAmount);
    }


    void LateUpdate()
    {
        if (counter >= 80)
        {
            movespeed = 30f;
            counter = 0.1f;

        }

        else
        {
            counter = counter + 10 * Time.deltaTime;

        }


    }

    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Speed up")
        {
            counter = 0.1f;
            movespeed = boostspeed;
            audio = GetComponent<AudioSource>();
            audio.Play();

        }
    }

        void OnCollisionEnter2D(Collision2D collision)
        {
        counter = 0.1f;
        movespeed = slowspeed; 

        }

    }
