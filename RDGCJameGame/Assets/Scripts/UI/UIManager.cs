using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
#pragma warning disable

    //Variables
    private KeyManager keyManager;
    public Image[] collectImage;
    public GameObject player;

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
        //Sets the initial state of the keys
        keyManager = player.GetComponent<KeyManager>();

        for(int i = 0; i < collectImage.Length; i++)
        {
            collectImage[i].color = Color.red;
        }

        //Set initial screens
        playText.SetActive(false);
        howText.SetActive(false);
        exitText.SetActive(false);
        howPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(player != null)
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
        SceneManager.LoadScene(1);
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
        //No keys collected
        if(keyManager.keyCount == 0)
        {
            for (int i = 0; i < collectImage.Length; i++)
            {
                collectImage[i].color = Color.red;
            }
        }
        //One key collected
        else if(keyManager.keyCount == 1)
        {
            collectImage[0].color = Color.white;

            for (int i = 1; i < collectImage.Length; i++)
            {
                collectImage[i].color = Color.red;
            }
        }
        //Two keys collected
        else if(keyManager.keyCount == 2)
        {
            for(int i = 0; i < 2; i++)
            {
                collectImage[i].color = Color.white;
            }
            for (int i = 2; i < collectImage.Length; i++)
            {
                collectImage[i].color = Color.red;
            }
        }
        //Three keys collected
        else if(keyManager.keyCount == 3)
        {
            for (int i = 0; i < 3; i++)
            {
                collectImage[i].color = Color.white;
            }
            for (int i = 3; i < collectImage.Length; i++)
            {
                collectImage[i].color = Color.red;
            }
        }
        //Four keys collected
        else if(keyManager.keyCount == 4)
        {
            for (int i = 0; i < collectImage.Length; i++)
            {
                collectImage[i].color = Color.white;
            }
        }
    }
}
