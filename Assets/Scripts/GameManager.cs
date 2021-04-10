using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool gameIsOver;

    public GameObject gameOverUI;

    public string levelSelectName = "LevelSelect";
    public int levelToUnlock;

    public SceneFader sceneFader;

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
        Debug.Log("TERMINE! BRAVO!");
        if(levelToUnlock > PlayerPrefs.GetInt("levelReached", 1))
        {
            PlayerPrefs.SetInt("levelReached", levelToUnlock);
        }
        sceneFader.FadeTo(levelSelectName);
    }
}