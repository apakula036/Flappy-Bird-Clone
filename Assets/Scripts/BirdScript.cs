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
    private Label highScoreText;
    private float elapsedTime = 0f;
    public int score = 0;
    public float scoreMultiplier = 100f;
    public static int highscore;
    AudioSource audioSource;
    public AudioClip collectedClip;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //audioSource = GetComponent<Assets/AudioTracks/lowblip.wav>();
        highscore = PlayerPrefs.GetInt ("highscore", highscore);

        scoreText = uiDocument.rootVisualElement.Q<Label>("ScoreLabel");
        highScoreText = uiDocument.rootVisualElement.Q<Label>("HighScoreLabel");
        gameObject.name = "bob_bird";
        restartButton = uiDocument.rootVisualElement.Q<Button>("RestartButton");
        highScoreText.style.display = DisplayStyle.None;
        restartButton.style.display = DisplayStyle.None;
        restartButton.clicked += ReloadScene;
        
    }
    

    // Update is called once per frame
    void Update()
    {
        if (score > highscore){
        highscore = score;
        PlayerPrefs.SetInt ("highscore", highscore);
        highScoreText.text = "Highscore: " + highscore;
        }
        UpdateScore();
        if (Keyboard.current.leftArrowKey.isPressed)
        {
            myRigidbody.linearVelocity = Vector2.left * 5;
        }
        else if (Keyboard.current.rightArrowKey.isPressed)
        {
            myRigidbody.linearVelocity = Vector2.right * 5;
        }


        else if (Keyboard.current.upArrowKey.isPressed)
        {
            myRigidbody.linearVelocity = Vector2.up * 7;
            //PlaySound();
        }
    }
    void UpdateScore()
    {
        elapsedTime += Time.deltaTime;
        score = Mathf.FloorToInt(elapsedTime * scoreMultiplier);
        scoreText.text = "Score: " + score;
    }
    public void PlaySound(AudioClip clip)
    {
    audioSource.PlayOneShot(clip);
    }
    void OnCollisionEnter2D(Collision2D collision) 
    {
        //check if the collision is a wall 
        if (collision.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
            Instantiate(Death_Explosion, transform.position, transform.rotation);
            restartButton.style.display = DisplayStyle.Flex;
            highScoreText.style.display = DisplayStyle.Flex;
            highScoreText.text = "Highscore: " + highscore;
        }
        /* Future location for powerups? 
        if (collision.gameObject.CompareTag("Powerup"))
        {
            Destroy(gameObject);
            Instantiate(newCharacterProperties?, transform.position, transform.rotation);
            restartButton.style.display = DisplayStyle.Flex;
        }*/
    }
    void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }




}

/*

Powerup to unlock the ability to fly left and right 



*/
