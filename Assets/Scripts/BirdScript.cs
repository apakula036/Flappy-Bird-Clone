using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;


public class BirdScript : MonoBehaviour
{
    public UIDocument uiDocument;
    public GameObject Death_Explosion; 
    public Rigidbody2D myRigidbody;
    private Button restartButton;
    private Label scoreText;
    private float elapsedTime = 0f;
    public int score = 0;
    public float scoreMultiplier = 10f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreText = uiDocument.rootVisualElement.Q<Label>("ScoreLabel");
        gameObject.name = "bob_bird";
        restartButton = uiDocument.rootVisualElement.Q<Button>("RestartButton");
        restartButton.style.display = DisplayStyle.None;
        restartButton.clicked += ReloadScene;
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateScore();
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
    void UpdateScore()
    {
        elapsedTime += Time.deltaTime;
        score = Mathf.FloorToInt(elapsedTime * scoreMultiplier);
        scoreText.text = "Score: " + score;
    }
    void OnCollisionEnter2D(Collision2D collision) 
    {
        Destroy(gameObject);
        Instantiate(Death_Explosion, transform.position, transform.rotation);
        restartButton.style.display = DisplayStyle.Flex;
    }
    void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }






}


