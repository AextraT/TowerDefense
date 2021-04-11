using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool gameIsOver;

    public GameObject gameOverUI;

    public SceneFader sceneFader;

    public GameObject completeLevelUI;

    private void Awake()
    {
        gameIsOver = false;
    }
    
    void Update()
    {
        /*if (Input.GetKeyDown("l"))
        {
            EndGame();
        }*/

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

    public void WinLevel()
    {
        gameIsOver = true;
        completeLevelUI.SetActive(true);
    }
}