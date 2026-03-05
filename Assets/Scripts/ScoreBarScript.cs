using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
public class ScoreBarScript : MonoBehaviour
{
    public UIDocument uiDocument;
    public Rigidbody2D myRigidbodyScoreBar;
    private Label scoreText;
    public int score = 0;
    public float scoreMultiplier = 1.1f;
    public float rightSpawnPosition = 30f;
    public Rigidbody2D ScoreBlockOne;
    public Rigidbody2D ScoreBlockTwo;
    public Rigidbody2D ScoreBlockThree;
    public Rigidbody2D ScoreBlockFour;
    public float pointToRespawnBlocks = -21f;
    void Start()
    {
        scoreText = uiDocument.rootVisualElement.Q<Label>("ScoreLabel");
        MoveScoreBlocks();
    }

    // Update is called once per frame
    void Update()
    {
        CheckForScoreBlock();
    }
    void OnCollisionEnter2D(Collision2D collision) 
    {
        //score++;
        //scoreText.text = "Score: " + score;
        //Debug.Log("hit the score bar " + score);
        if (collision.gameObject.CompareTag("Player"))
        {
            score++;
            scoreText.text = "Score: " + score;
            Debug.Log("hit the score bar " + score);
        }
    }
    void CheckForScoreBlock(){
        Vector2 position = transform.position;
        //float sizeYRangeForBlock = Random.Range(8.3f,13.5f);
        //float sizeXRangeForBlock = Random.Range(1.1f,3f);
        if (position.x < pointToRespawnBlocks)
        {
            position.x = rightSpawnPosition;
            //transform.localScale = new Vector3(sizeXRangeForBlock, sizeYRangeForBlock, 1);
            transform.position = position;
            MoveScoreBlocks();
        } 
    }
    void MoveScoreBlocks(){
        //move the blocks to the left
        myRigidbodyScoreBar.linearVelocity = Vector2.left * 9;
    }
}
