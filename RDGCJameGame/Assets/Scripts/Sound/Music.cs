using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Music : MonoBehaviour
{
    public GameObject[] musicManagerList;
    public Scene currentScene;
    public bool endPlaying;
    public bool mainPlaying;
    public AudioSource mainPlayer;
    public AudioSource endPlayer;
    public float timer;
    public float maxTime = 2;
    // Start is called before the first frame update
    void Start()
    {
        endPlaying = false;
        mainPlaying = false;
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void FixedUpdate()
    {
        currentScene = SceneManager.GetActiveScene();
        int currentIndex = currentScene.buildIndex;
        if ((currentIndex == 0 || currentIndex == 2) && !mainPlaying)
        {
            endPlaying = false;
            if (endPlayer.volume > 0)
            {
                endPlayer.volume *= .9925f;
            }
            else
            {
                endPlayer.Stop();
            }
            if (timer > maxTime)
            {
                timer = 0;
                mainPlaying = true;
                mainPlayer.volume = 1;
                mainPlayer.Play();
            }
            else
            {
                timer += Time.deltaTime;
            }
        }
        else if (currentIndex == 0 || currentIndex == 2)
        {
            if (endPlayer.volume > 0)
            {
                endPlayer.volume *= .9925f;
            }
            else
            {
                endPlayer.Stop();
            }
        }
        else if (currentIndex == 3 && !endPlaying)
        {
            endPlaying = true;
            endPlayer.volume = 1;
            endPlayer.Play();
        }
        else if (currentIndex == 1)
        {
            endPlaying = false;
            mainPlaying = false;
            if (mainPlayer.volume > 0)
            {
                mainPlayer.volume *= .9925f;
            }
            else
            {
                mainPlayer.Stop();
            }
            if (endPlayer.volume > 0)
            {
                endPlayer.volume *= .9925f;
            }
            else
            {
                endPlayer.Stop();
            }
        }
    }

    private void Awake()
    {
        musicManagerList = GameObject.FindGameObjectsWithTag("music");

        if(musicManagerList.Length>1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);

    }
}
