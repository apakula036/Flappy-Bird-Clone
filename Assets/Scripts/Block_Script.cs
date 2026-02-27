using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class Block_Script : MonoBehaviour
{
    public GameObject Death_Explosion; 
    public Rigidbody2D myRigidbody;
    public Vector3 localScale;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameObject.name = "block";
        //moveBlocks();
    }

    // Update is called once per frame
    void Update()
    {
        spawnBlocks();
    }

    void spawnBlocks(){
        Vector2 position = transform.position;
        if (position.x < -25){
        int sizeRangeForBlock = Random.Range(1,15);
        position.x = 21;
        transform.localScale = new Vector3(sizeRangeForBlock, sizeRangeForBlock, sizeRangeForBlock);
        transform.position = position;
        }
        myRigidbody.linearVelocity = Vector2.left * 9;

        
    }

    void moveBlocks(){
        myRigidbody.linearVelocity = Vector2.left * 10;
    }

    void OnCollisionEnter2D(Collision2D collision) 
    {
        Destroy(gameObject);
        Instantiate(Death_Explosion, transform.position, transform.rotation);
    }
}
/** -----------NOTES SECTION -------------------------------

public void spawnBlocks(){
    spawn block 
}
public void moveblocks(){
    move
}



//block.linearVelocity = Vector2.up * 10;
        //float horizontal = 0.0f;
        if (Keyboard.current.leftArrowKey.isPressed)
        {
            //horizontal = -1.0f;
            block.linearVelocity = Vector2.left * 10;
        }
        else if (Keyboard.current.rightArrowKey.isPressed)
        {
            block.linearVelocity = Vector2.right * 10;
        }


        //float vertical = 0.0f;
        if (Keyboard.current.upArrowKey.isPressed)
        {
            //vertical = 1.0f;
            block.linearVelocity = Vector2.up * 10;
        }
        else if (Keyboard.current.downArrowKey.isPressed)
        {
            //vertical = -1.0f;
            block.linearVelocity = Vector2.down * 10;
        }


        //Vector2 position = transform.position;
        //position.x = position.x + 0.1f * horizontal;
        //position.y = position.y + 0.1f * vertical;
        //transform.position = position;




**/