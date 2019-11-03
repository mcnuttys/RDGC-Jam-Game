using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalDoor : MonoBehaviour
{
    public GameObject player;
    public bool win;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        win = player.GetComponent<KeyManager>().win;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (win)
        {
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene(2); //win screen
        }
    }
}
