using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footstep : MonoBehaviour
{
    // The place where the footstep noises come from.
    private AudioSource footStepSource;

    // The four footstep noises
    [SerializeField]
    private AudioClip[] footsteps;
    private int footstepsLength;

    // Whether the player is walkin'
    [HideInInspector]
    public bool walking;

    // Start is called before the first frame update
    void Start()
    {
        footStepSource = this.GetComponent<AudioSource>();

        if (footsteps == null)
            footsteps = new AudioClip[0];
        footstepsLength = footsteps.Length;
    }

    // Update is called once per frame
    void Update()
    {
        if (walking)
        {
            footStepSource.clip = footsteps[Random.Range(0, footstepsLength)];
            footStepSource.Play();
            walking = false;
        }
    }
}
