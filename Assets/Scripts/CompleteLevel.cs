using UnityEngine;
using UnityEngine.SceneManagement;

public class CompleteLevel : MonoBehaviour
{
    public SceneFader sceneFader;
    public AudioManager audioManager;

    public string menuSceneName = "MainMenu";

    public string nextLevel;
    public int levelToUnlock;

    public void OnEnable()
    {
        if (levelToUnlock > PlayerPrefs.GetInt("levelReached", 1))
        {
            PlayerPrefs.SetInt("levelReached", levelToUnlock);
        }

        audioManager.PlaySong(audioManager.winMusic);
    }

    public void Continue()
    {
        sceneFader.FadeTo(nextLevel);
    }

    public void Menu()
    {
        sceneFader.FadeTo(menuSceneName);
    }
}
