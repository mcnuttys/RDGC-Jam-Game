using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    //Variables
    [SerializeField]
    private GameObject[] collectImage;
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
        SceneManager.LoadScene(1);
    }

    void UpdateCollect()
    {
        //Activates the first collectible
        if (collectTest[0])
        {
            collectImage[0].SetActive(true);
        }

        //Activates the second collectible
        if (collectTest[1])
        {
            collectImage[1].SetActive(true);
        }

        //Activates the third collectible
        if (collectTest[2])
        {
            collectImage[2].SetActive(true);
        }

        //Activates the fourth collectible
        if (collectTest[3])
        {
            collectImage[3].SetActive(true);
        }
    }
}
