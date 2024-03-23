using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieFuckingEatsYou : MonoBehaviour
{
    public GameObject Zombie;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Zombie.GetComponent<ZombieMove>().Kill();
        }
    }
}
