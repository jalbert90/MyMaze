using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Maze mazePrefab;
    private Maze mazeInstance;

    // Start is called before the first frame update
    void Start()
    {
        BeginGame();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RestartGame();
        }
    }

    // Clone mazePrefab to create an instance of the maze
    private void BeginGame ()
    {
        mazeInstance = Instantiate(mazePrefab) as Maze;
        mazeInstance.Generate();
    }

    // Destroy the mazeInstance gameobject
    // call BeginGame()
    private void RestartGame ()
    {
        Destroy(mazeInstance.gameObject);
        BeginGame();
    }
}
