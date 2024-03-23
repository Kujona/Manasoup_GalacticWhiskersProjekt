using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    public AudioSource audioSource;
    
    private float shoutTime;
    private float currentTime;
    
    // Start is called before the first frame update
    void Start()
    {
        // Set random interval for when the zombie moans
        shoutTime = Random.Range(10f, 20f);
        currentTime = shoutTime;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= Time.deltaTime;
        if (currentTime <= 0)
        {
            currentTime = shoutTime;
            audioSource.Play();
        }
    }
}
