using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class rendercorrectly : MonoBehaviour
{
    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(transform.position.y < Player.transform.position.y)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -7);
        } else
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -5);
        }
    }
}
