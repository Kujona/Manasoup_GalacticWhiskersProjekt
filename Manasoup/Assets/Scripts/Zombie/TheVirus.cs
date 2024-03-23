using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheVirus : MonoBehaviour
{
    public GameObject Human;
    public GameObject Zombie;
    public GameObject Exit;

    void Start()
    {
        Human.SetActive(true);
        Zombie.SetActive(false);
        Exit = GameObject.FindWithTag("Exit");
    }

    void FixedUpdate()
    {
        if (Exit.GetComponent<ExitScript>().vergangenheit == false)
        {
            Turn();
        }
    }

    public void Turn()
    {
        Human.SetActive(false);
        Zombie.SetActive(true);
    }

}
