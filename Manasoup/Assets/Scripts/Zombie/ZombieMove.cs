using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMove : MonoBehaviour
{
    public GameObject Player;
    public GameObject UIController;
    public float speed;
    private float distance;
    public bool following;

 
    void Awake()
    {
        following = false;
        Player = GameObject.FindWithTag("Player");
        UIController = GameObject.FindWithTag("UIController");
    }

    void FixedUpdate()
    {
        if (following == true)
        {
            distance = Vector3.Distance(transform.position, Player.transform.position);
            Vector3 direction = Player.transform.position - transform.position;
            transform.position = Vector3.MoveTowards(this.transform.position, Player.transform.position, speed * Time.deltaTime);
        }
    }

    public void Kill()
    {
            UIController.GetComponent<UIController>().GameOver();
    }

    public void StartFollowing()
    {
        following = true;
    }
}
