using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class RandomSoundPlayer : MonoBehaviour
{
    public AudioMixerGroup audioMixerGroup;
    public List<AudioClip> sounds;

    public bool randomPitch = false;
    public float minPitch = 0.5f;
    public float maxPitch = 1.5f;
    
    public bool repeatRandomly = true;
    public float minPause = 15f;
    public float maxPause = 20f;
    
    private float shoutTime;
    private float currentTime;

    private AudioSource player;
    
    
    void Start()
    {
        player = gameObject.AddComponent<AudioSource>();
        player.outputAudioMixerGroup = audioMixerGroup;
        
        if (!repeatRandomly)
        {
            return;
        }
        
        // Set random interval for when the zombie moans
        shoutTime = Random.Range(minPause, maxPause);
        currentTime = Random.Range(0f, maxPause);
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
        //GameObject temp = new GameObject();
        //temp.transform.position = gameObject.transform.position;
        
        //AudioSource player = gameObject.AddComponent<AudioSource>();
        //player.outputAudioMixerGroup = audioMixerGroup;
        
        if (randomPitch)
        {
            player.pitch = Random.Range(minPitch, maxPitch);
        }
        
        //player.clip = sounds[Random.Range(0, sounds.Count)];
        AudioClip randomClip = sounds[Random.Range(0, sounds.Count)];
        
        player.PlayOneShot(randomClip);
        //_ = DetroyOnEnd(temp, player);

    }
    
    //IEnumerator DetroyOnEnd(GameObject temp, AudioSource player)
    //{
    //    yield return new WaitUntil(() => !player.isPlaying);
    //    Destroy(temp);
    //}
}
