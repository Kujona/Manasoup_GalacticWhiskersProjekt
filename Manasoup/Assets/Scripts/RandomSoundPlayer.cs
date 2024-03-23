using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSoundPlayer : MonoBehaviour
{
    public List<AudioClip> sounds;

    public bool repeatRandomly = true;
    public float minPause = 15f;
    public float maxPause = 20f;
    
    private float shoutTime;
    private float currentTime;
    
    
    void Start()
    {
        if (!repeatRandomly)
        {
            return;
        }
        
        // Set random interval for when the zombie moans
        shoutTime = Random.Range(minPause, maxPause);
        currentTime = Random.Range(0.5f, maxPause);
    }


    void Update()
    {
        if (!repeatRandomly)
        {
            return;
        }
        
        currentTime -= Time.deltaTime;
        if (currentTime <= 0)
        {
            currentTime = shoutTime;
            PlayRandomSound();
        }
    }


    public void PlayRandomSound()
    {
        AudioClip randomSound = sounds[Random.Range(0, sounds.Count)];
        AudioSource.PlayClipAtPoint(randomSound, gameObject.transform.position);
    }
}
