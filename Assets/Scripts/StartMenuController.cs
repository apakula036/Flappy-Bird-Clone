using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuController : MonoBehaviour
{
    public Rigidbody2D myRigidbodyTreeMainMenu;
    public Vector3 localScale;
    public float rightSpawnPosition = 33f;
    public float pointToRespawnTrees = -29f;
    public float speedToMoveTrees = 3; 
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
        myRigidbodyTreeMainMenu.linearVelocity = Vector2.left * speedToMoveTrees;
    }
    public void OnStartClick()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void OnExitClick()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
            Application.Quit();
    }
}
