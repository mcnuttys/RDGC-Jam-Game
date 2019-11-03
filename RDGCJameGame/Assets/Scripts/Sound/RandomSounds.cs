// THIS SCRIPT GOES ON THE OBJECT WITH THE AUDIO SOURCE
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class RandomSounds : MonoBehaviour
{
    // The sounds that can be randomly played,
    // set in inspector ples
    [SerializeField]
    private List<AudioClip> sounds;

    // Length of the sounds list
    private int soundsLength;

    // The audio source on this gameobject
    private AudioSource source;

    // The place where the footstep noises come from.
    [SerializeField]
    private AudioSource footStepSource;

    // The four footstep noises
    [SerializeField]
    private AudioClip[] footsteps;
    private int footstepsLength;

    // Whether the player is walkin'
    private bool walking;

    // Start is called before the first frame update
    void Start()
    {
        if (sounds == null)
            sounds = new List<AudioClip>();
        soundsLength = sounds.Count;

        // The source is the one attached to this object
        source = this.GetComponent<AudioSource>();

        // Start playing sounds
        StartCoroutine(PlaySoundAtInterval(Random.Range(2.5f, 6.75f)));

        if (footsteps == null)
            footsteps = new AudioClip[0];
        footstepsLength = footsteps.Length;
    }

    // Update is called once per frame
    void Update()
    {
        if (walking && !Input.GetKey(KeyCode.W))
        {
            walking = false;
            footStepSource.Stop();
        }
        if (!walking && Input.GetKeyDown(KeyCode.W))
        {
            walking = true;
            footStepSource.clip = footsteps[Random.Range(0, footstepsLength)];
            footStepSource.Play();
        }
    }

    IEnumerator PlaySoundAtInterval(float secondsBetween)
    {
        yield return new WaitForSeconds(secondsBetween);

        // After secondsBetween seconds, change the source's
        // sound to a random one and play it
        source.clip = sounds[Random.Range(0, soundsLength)];
        source.Play();

        // The start the coroutine again
        StartCoroutine(PlaySoundAtInterval(Random.Range(4f, 8.75f)));
    }

}
