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
    public Rigidbody2D MovingBlockOne;
    public Rigidbody2D MovingBlockTwo;
    public Rigidbody2D MovingBlockThree;
    public Rigidbody2D MovingBlockFour;
    public Vector3 localScale;
    public float xScaleValue = 1.475f;
    public float minValue = 7.9f;
    public float maxValue = 0f;
    public float medianValue = 10f; 
    public float rightSpawnPosition = 30f;
    public float bottomSpawnYValue = -7f;
    public float topSpawnYValue = 7.71f;
    public float pointToRespawnBlocks = -21f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //MovingBlockOne.name = "blockOne";
        MoveBlocks();
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckForBlockOne();
    }

    void CheckForBlockOne(){
        Vector2 position = transform.position;
        float sizeYRangeForBlock = Random.Range(8.3f,13.5f);
        float sizeXRangeForBlock = Random.Range(1.1f,3f);
        if (position.x < pointToRespawnBlocks)
        {
            position.x = rightSpawnPosition;
            transform.localScale = new Vector3(sizeXRangeForBlock, sizeYRangeForBlock, 1);
            transform.position = position;
            MoveBlocks();
        } 
    }
    void MoveBlocks(){
        //move the blocks to the left
        myRigidbody.linearVelocity = Vector2.left * 9;
    }
    void OnCollisionEnter2D(Collision2D collision) 
    {
        //when it crashes into the backwall it explodes 
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            Instantiate(Death_Explosion, transform.position, transform.rotation);
        }
    }

    
}
/** -----------NOTES SECTION -------------------------------

void OnCollisionEnter2D(Collision2D collision) 
    {
        Destroy(gameObject);
        Instantiate(Death_Explosion, transform.position, transform.rotation);
    }

void randomWhatSideBlockSpawnsOn(){
    random number 1 or 2 to pick top or bottom 

}

    // Wait for 3 seconds (scaled time)
        //new WaitForSeconds(3);


if (position.x < -25f && position.y > 0){
            //check if theyre too short 
            if (sizeYRangeForBlock >= minValue && sizeYRangeForBlock <= medianValue) { 
                position.y = -10f;
                position.x = rightSpawnPosition;
                transform.localScale = new Vector3(xScaleValue, sizeYRangeForBlock, 1);
                Debug.Log("Y > 0: " + sizeYRangeForBlock);
                transform.position = position;
            }
            else if (sizeYRangeForBlock >= minValue && sizeYRangeForBlock >= medianValue) { 
                //position.y = bottomSpawnYValue;
                position.x = rightSpawnPosition;
                transform.localScale = new Vector3(xScaleValue, sizeYRangeForBlock, 1);
                Debug.Log("Y > 0 bottom logic " + sizeYRangeForBlock);
                transform.position = position;
            }
        }


        //top side blocks spawn in and touch the top of the screen 
        else if (position.x < -25f && position.y < 0){
            //check if theyre too short 
            if (sizeYRangeForBlock >= minValue && sizeYRangeForBlock <= medianValue) { 
                position.y = topSpawnYValue;
                position.x = rightSpawnPosition;
                transform.localScale = new Vector3(xScaleValue, sizeYRangeForBlock, 1);
                Debug.Log("Y < 0: " + sizeYRangeForBlock);
                transform.position = position;
            }
            
            else if (sizeYRangeForBlock >= minValue && sizeYRangeForBlock >= medianValue) { 
                //position.y = topSpawnYValue;
                position.x = rightSpawnPosition;
                transform.localScale = new Vector3(xScaleValue, sizeYRangeForBlock, 1);
                Debug.Log("Y < 0 bottom logic " + sizeYRangeForBlock);
                transform.position = position;
            }
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