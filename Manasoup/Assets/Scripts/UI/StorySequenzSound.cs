using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorySequenzSound : MonoBehaviour
{
    public AudioSource aud;
    public AudioClip[] clips;
    public GameObject CutsceneSetup;

    void Awake()
    {
        CutsceneSetup = GameObject.FindWithTag("CutsceneSetup");
    }

    public void PlaySound(int i)
    {
        aud.clip = clips[i];
        aud.Play();
    }

    public void Ende()
    {
        CutsceneSetup.GetComponent<CutsceneSetup>().CutsceneBeenden();
    }

}
