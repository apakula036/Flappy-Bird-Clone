using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;


public class BirdScript : MonoBehaviour
{
    public GameObject Death_Explosion; 
    public Rigidbody2D myRigidbody;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameObject.name = "bob_bird";
        
    }

    // Update is called once per frame
    void Update()
    {
        //myRigidbody.linearVelocity = Vector2.up * 10;
        //float horizontal = 0.0f;
        if (Keyboard.current.leftArrowKey.isPressed)
        {
            //horizontal = -1.0f;
            myRigidbody.linearVelocity = Vector2.left * 5;
        }
        else if (Keyboard.current.rightArrowKey.isPressed)
        {
            myRigidbody.linearVelocity = Vector2.right * 5;
        }


        //float vertical = 0.0f;
        else if (Keyboard.current.upArrowKey.isPressed)
        {
            //vertical = 1.0f;
            myRigidbody.linearVelocity = Vector2.up * 7;
        }
        /* else if (Keyboard.current.downArrowKey.isPressed)
        {
            //vertical = -1.0f;
            myRigidbody.linearVelocity = Vector2.down * 10;
        } */ 


        //Vector2 position = transform.position;
        //position.x = position.x + 0.1f * horizontal;
        //position.y = position.y + 0.1f * vertical;
        //transform.position = position;
    }
    void OnCollisionEnter2D(Collision2D collision) 
    {
        Destroy(gameObject);
        Instantiate(Death_Explosion, transform.position, transform.rotation);
    }
}

