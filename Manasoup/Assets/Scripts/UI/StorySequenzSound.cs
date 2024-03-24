using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorySequenzSound : MonoBehaviour
{
    public AudioSource aud;
    public AudioClip[] clips;

    void Awake()
    {
        
    }

    public void PlaySound(int i)
    {
        aud.clip = clips[i];
        aud.Play();
    }
}
