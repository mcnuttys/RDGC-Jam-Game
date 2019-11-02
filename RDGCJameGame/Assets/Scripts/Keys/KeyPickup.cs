using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    public bool pickup;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        pickup = false;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject == player)
        {
            player.GetComponent<KeyManager>().keyCount++;
            Destroy(gameObject);
        }
    }
}
