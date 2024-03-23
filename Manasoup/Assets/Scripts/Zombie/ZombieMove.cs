using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMove : MonoBehaviour
{
    public GameObject Player;
    public GameObject UIController;
    public float speed;
    private float distance;

 
    void Awake()
    {
        Player = GameObject.FindWithTag("Player");
        UIController = GameObject.FindWithTag("UIController");
    }

    void FixedUpdate()
    {
        distance = Vector3.Distance(transform.position, Player.transform.position);
        Vector3 direction = Player.transform.position - transform.position;
        transform.position = Vector3.MoveTowards(this.transform.position, Player.transform.position, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            UIController.GetComponent<UIController>().GameOver();
        }
    }
}
