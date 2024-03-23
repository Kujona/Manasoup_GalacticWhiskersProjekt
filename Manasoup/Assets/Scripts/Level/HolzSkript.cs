using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HolzSkript : MonoBehaviour
{

    public new BoxCollider2D collider;
    public GameObject Player;

    public AudioClip collectSound;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        collider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Player.GetComponent<PlayerActions>().IncreaseHolz();
            AudioSource.PlayClipAtPoint(collectSound, gameObject.transform.position);
            Destroy(gameObject);
            Debug.Log("collected wood");
        }
    }
}
