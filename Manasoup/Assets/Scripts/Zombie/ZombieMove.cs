using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMove : MonoBehaviour
{
    public GameObject Player;
    public float speed;
    private float distance;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        distance = Vector3.Distance(transform.position, Player.transform.position);
        Vector3 direction = Player.transform.position - transform.position;
        transform.position = Vector3.MoveTowards(this.transform.position, Player.transform.position, speed * Time.deltaTime);
        
    }
}
