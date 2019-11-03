using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScreenFade : MonoBehaviour
{
    public float fadeSpeed = 0.5f;
    public Image fade;
    public Color finalColor;
    public Color startColor;

    private bool fading;
    private int sceneToLoad;

    // Update is called once per frame
    void Update()
    {
        if(fading)
        {
            fade.color = Color.Lerp(fade.color, finalColor, Time.deltaTime * fadeSpeed);

            if (fade.color == finalColor)
            {
                CompleteFade(sceneToLoad);
            }
        }
        else
        {
            fade.color = Color.Lerp(fade.color, startColor, Time.deltaTime * fadeSpeed);
        }
    }

    public void FadeToScene(int index)
    {
        fading = true;
        sceneToLoad = index;
    }

    void CompleteFade(int sceneToLoad)
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
