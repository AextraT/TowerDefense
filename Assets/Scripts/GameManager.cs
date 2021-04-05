using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool gameIsOver;

    private void Awake()
    {
        gameIsOver = false;
    }

    public GameObject gameOverUI;
    
    void Update()
    {
        if (Input.GetKeyDown("l"))
        {
            EndGame();
        }

        if (gameIsOver)
        {
            return;
        }

        if(PlayerStats.lives <= 0)
        {
            EndGame();
        }
    }

    void EndGame()
    {
        gameIsOver = true;
        gameOverUI.SetActive(true);
    }
}