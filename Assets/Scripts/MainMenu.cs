using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string levelToLoad = "MainScene";
    public SceneFader sceneFader;

    public GameObject settingsPanel;

    public void Play()
    {
        sceneFader.FadeTo(levelToLoad);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Settings()
    {
        settingsPanel.SetActive(!settingsPanel.activeSelf);
    }
}
