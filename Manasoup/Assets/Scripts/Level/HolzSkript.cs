using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HolzSkript : MonoBehaviour
{

    public new BoxCollider2D collider;
    public GameObject Player;

    public RandomSoundPlayer soundPlayer;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        collider = GetComponent<BoxCollider2D>();
    }


    void FixedUpdate()
    {
        if(Player.GetComponent<PlayerActions>().vergangenheit == false)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Player.GetComponent<PlayerActions>().IncreaseHolz();
            soundPlayer.PlayRandomSound();
            Destroy(gameObject, 0.2f); // Dumme Lösungen sind die besten Lösungen..
            Debug.Log("collected wood");
        }
    }

}
