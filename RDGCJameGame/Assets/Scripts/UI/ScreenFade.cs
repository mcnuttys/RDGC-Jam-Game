using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenFade : MonoBehaviour
{
    public float fadeSpeed = 0.5f;
    public SpriteRenderer fade;
    public Color finalColor;

    private bool fading;
    private int sceneToLoad;

    // Update is called once per frame
    void Update()
    {
        if(fading)
        {
            fade.color = Color.Lerp(fade.color, finalColor, Time.deltaTime * fadeSpeed);

            if (fade.color == finalColor)
                CompleteFade(sceneToLoad);
        }
    }

    void Fade(int sceneToLoad)
    {
        fading = true;
        this.sceneToLoad = sceneToLoad;
    }

    void CompleteFade(int sceneToLoad)
    {

        Debug.Log($"Loading Scene: {SceneManager.GetSceneAt(sceneToLoad).name}");
        SceneManager.LoadScene(sceneToLoad);
    }
}
