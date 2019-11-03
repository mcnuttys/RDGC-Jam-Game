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
    public ScreenFade fadeScript;

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
        fadeScript = GameObject.FindObjectOfType<ScreenFade>();

        //Sets the initial state of the keys
        if(player != null)
            keyManager = player.GetComponent<KeyManager>();

        for(int i = 0; i < collectImage.Length; i++)
        {
            collectImage[i].color = Color.red;
        }

        //Set initial screens

        if(playText != null && howText != null && exitText != null && howPanel != null)
        {
            playText.SetActive(false);
            howText.SetActive(false);
            exitText.SetActive(false);
            howPanel.SetActive(false);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if(player != null)
            UpdateCollect();

        if (playText != null && howText != null && exitText != null && howPanel != null)
        {
            //Creates the raycast
            Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
            
            RaycastHit hit;

            if (Physics.Raycast(r, out hit))
            {
                Debug.DrawLine(r.origin, hit.point, Color.red);
                //Tests if the latern is being interacted with
                if (hit.collider.gameObject.name == "Lantern Trigger")
                {
                    //Plays the game
                    if (Input.GetMouseButtonDown(0))
                    {
                        Play();
                    }

                    OnHoverPlay();
                }
                else
                {
                    OffHoverPlay();
                }

                //Tests if the key is being interacted with
                if (hit.collider.gameObject.name == "Key Trigger")
                {
                    //Exits the game
                    if (Input.GetMouseButtonDown(0))
                    {
                        ExitClick();
                    }

                    OnHoverExit();
                }
                else
                {
                    OffHoverExit();
                }

                //Tests if the mirror is being interacted with
                if (hit.collider.gameObject.name == "Mirror Trigger")
                {
                    //Switches to the how to menu
                    if (Input.GetMouseButtonDown(0))
                    {
                        HowClick();
                    }

                    OnHoverHow();
                }
                else
                {
                    OffHoverHow();
                }
            }
        }
    }

    //Play button related methods

    //Hover Events
    public void OnHoverPlay()
    {
        playText.SetActive(true);
    }

    public void OffHoverPlay()
    {
        if(playText != null)
        playText.SetActive(false);
    }

    //Click Events
    public void Play()
    {
        Cursor.lockState = CursorLockMode.Locked;
        fadeScript.FadeToScene(1);
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
        fadeScript.FadeToScene(0);
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
