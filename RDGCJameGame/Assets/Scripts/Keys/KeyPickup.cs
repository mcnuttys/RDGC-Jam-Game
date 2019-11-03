using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    public bool pickup;
    public GameObject player;

    [SerializeField]
    private AudioClip keyCollectNoise;
    private AudioSource keyCollectAudioSource;

    // Start is called before the first frame update
    void Start()
    {
        pickup = false;
        player = GameObject.FindGameObjectWithTag("Player");

        keyCollectAudioSource = player.transform.Find("KeyCollectAudioSource").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject == player)
        {
            keyCollectAudioSource.Play();


            player.GetComponent<KeyManager>().keyCount++;
            Destroy(gameObject);
        }
    }
}
