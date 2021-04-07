using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneFader : MonoBehaviour
{
    public Image img;

    public AnimationCurve curve;

    private void Start()
    {
        StartCoroutine(FadeIn());
    }

    public void FadeTo(string scene)
    {
        StartCoroutine(FadeOut(scene));
    }

    //FadeIn = Ecran noir vers scene
    IEnumerator FadeIn()
    {
        float t = 1;

        while(t > 0f)
        {
            t -= Time.deltaTime;
            float a = curve.Evaluate(t);
            img.color = new Color(img.color.r, img.color.g, img.color.b, a);
            yield return 0;
        }
    }

    //FadeOut = Scene vers ecran noir
    IEnumerator FadeOut(string scene)
    {
        float t = 0;

        while(t < 1f)
        {
            t += Time.deltaTime;
            float a = curve.Evaluate(t);
            img.color = new Color(img.color.r, img.color.g, img.color.b, a);
            yield return 0;
        }

        SceneManager.LoadScene(scene);
    }
}
