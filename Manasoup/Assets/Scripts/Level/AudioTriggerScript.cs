using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTriggerScript : MonoBehaviour
{
    public GameObject Player;
    public bool Ist_das_in_der_Vergangenheit;

    // Start is called before the first frame update
    void Awake()
    {
        Player = GameObject.FindWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && Ist_das_in_der_Vergangenheit == true && Player.GetComponent<PlayerActions>().vergangenheit == true)
        { 
            GetComponent<AudioSource>().Play();
        }
        if (collision.tag == "Player" && Ist_das_in_der_Vergangenheit == false && Player.GetComponent<PlayerActions>().vergangenheit == false)
        {
            GetComponent<AudioSource>().Play();
        }
    }
}
