using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
#pragma warning disable

    //Variables
    public GameObject[] collectImage;
    public bool[] collectTest;

    //Text related gameObjects
    [SerializeField]
    private GameObject playText;
    [SerializeField]
    private GameObject howText;
    [SerializeField]
    private GameObject exitText;

    //Panels
    [SerializeField]
    private GameObject howPanel;

#pragma warning enable

    // Start is called before the first frame update
    void Start()
    {
        playText.SetActive(false);
        howText.SetActive(false);
        exitText.SetActive(false);
        howPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateCollect();
    }

    //Play button related methods

    //Hover Events
    public void OnHoverPlay()
    {
        playText.SetActive(true);
    }

    public void OffHoverPlay()
    {
        playText.SetActive(false);
    }

    //Click Events
    public void Play()
    {
        SceneManager.LoadScene(2);
    }

    //How to button related methods

        //Hover Events
    public void OnHoverHow()
    {
        howText.SetActive(true);
    }

    public void OffHoverHow()
    {
        howText.SetActive(false);
    }

    //Click Events
    public void HowClick()
    {
        howPanel.SetActive(true);
    }

    //Exit button related methods

    //Hover Events
    public void OnHoverExit()
    {
        exitText.SetActive(true);
    }

    public void OffHoverExit()
    {
        exitText.SetActive(false);
    }

    //Click Events
    public void ExitClick()
    {
        Application.Quit();
    }

    //In-game Navigation
    public void ToHow()
    {
        howPanel.SetActive(true);
    }

    public void BackToMain()
    {
        howPanel.SetActive(false);
    }

    public void ToMain()
   {
        SceneManager.LoadScene(0);
    }

    void UpdateCollect()
    {
        //Activates the first collectible
        if (collectTest != null && collectTest[0])
        {
            collectImage[0].SetActive(true);
        }

        //Activates the second collectible
        if (collectTest != null && collectTest[1])
        {
            collectImage[1].SetActive(true);
        }

        //Activates the third collectible
        if (collectTest != null && collectTest[2])
        {
            collectImage[2].SetActive(true);
        }

        //Activates the fourth collectible
        if (collectTest != null && collectTest[3])
        {
            collectImage[3].SetActive(true);
        }
    }
}
