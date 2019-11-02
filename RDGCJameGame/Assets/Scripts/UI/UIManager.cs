using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    //Variables
    public GameObject[] collectImage;
    public bool[] collectTest;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateCollect();
    }

    public void Play()
    {
        SceneManager.LoadScene(2);
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
