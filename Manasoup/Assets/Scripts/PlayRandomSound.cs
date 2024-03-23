using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayRandomSound : MonoBehaviour
{
    public GameObject position;
    public List<AudioClip> audioClips;
    public float minPause = 15f;
    public float maxPause = 20f;
    
    private float shoutTime;
    private float currentTime;
    
    
    void Start()
    {
        // Set random interval for when the zombie moans
        shoutTime = Random.Range(minPause, maxPause);
        currentTime = Random.Range(0.5f, maxPause);
    }


    void Update()
    {
        currentTime -= Time.deltaTime;
        if (currentTime <= 0)
        {
            currentTime = shoutTime;
            Moan();
        }
    }


    void Moan()
    {
        AudioClip randomMoan = audioClips[Random.Range(0, audioClips.Count)];
        AudioSource.PlayClipAtPoint(randomMoan, position.transform.position);
    }
}
