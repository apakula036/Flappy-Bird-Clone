using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
public class Background_Movement : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public Vector3 localScale;
    public float rightSpawnPosition = 33f;
    public float pointToRespawnTrees = -29f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MoveTrees();
    }

    // Update is called once per frame
    void Update()
    {
        CheckForTrees();
    }

    void CheckForTrees(){
        Vector2 position = transform.position;
        float sizeYRangeForBlock = Random.Range(.9f,1.3f);
        float sizeXRangeForBlock = Random.Range(.9f,1.3f);
        if (position.x < pointToRespawnTrees)
        {
            position.x = rightSpawnPosition;
            transform.localScale = new Vector3(sizeXRangeForBlock, sizeYRangeForBlock, 1);
            transform.position = position;
            MoveTrees();
        } 
    }
    void MoveTrees(){
        //move the blocks to the left
        myRigidbody.linearVelocity = Vector2.left * 9;
    }
}
