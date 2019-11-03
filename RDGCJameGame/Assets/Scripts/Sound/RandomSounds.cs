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
    }

    // Update is called once per frame
    void Update()
    {
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
