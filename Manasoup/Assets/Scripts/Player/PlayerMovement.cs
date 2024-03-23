using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    private Rigidbody2D myRigidbody;
    public Vector3 change;
    public Vector3 newestChange;
    private Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
        UpdateAnimationAndMove();
    }

    void UpdateAnimationAndMove()
    {
        if (change != Vector3.zero)
        {
            MovePlayer();
            animator.SetFloat("moveX", change.x);
            animator.SetFloat("moveY", change.y);
            newestChange = change;
            animator.SetBool("moving", true);
        }
        else
        {
            animator.SetBool("moving", false);
        }
    }

    void MovePlayer()
    {
        myRigidbody.MovePosition(transform.position + change * speed * Time.deltaTime);
    }

    public void Respawn()
    {
        myRigidbody.transform.position = new Vector3(0, 0, -6); //Spieler Sawned wieder bei 0,0. Die Level müssen einfach so gebaut werden, dass der Spawnpunkt bei diesen Weltkoordinaten ist.
    }

    

}
