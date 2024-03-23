using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class NewPlayerMovement : MonoBehaviour
{
    private CustomInput input = null;
    private Vector2 moveVector = Vector2.zero;
    private Rigidbody2D rb = null;
    public float moveSpeed = 6f;
    private Animator animator;
    private int rawx;
    private int rawy;
    public Vector3 newestChange;

    private void Awake()
    {
        input = new CustomInput();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        input.Enable();
        input.Player.Movement.performed += OnMovementPerformed;
        input.Player.Movement.canceled += OnMovementCancelled;
    }

    private void OnDisable()
    {
        input.Disable();
        input.Player.Movement.performed -= OnMovementPerformed;
        input.Player.Movement.canceled -= OnMovementCancelled;
    }

    private void FixedUpdate()
    {
        rb.velocity = moveVector * moveSpeed;
        if(moveVector != Vector2.zero)
        {
            if (moveVector.x > 0) { rawx = 1; }
            if (moveVector.x == 0) { rawx = 0; }
            if (moveVector.x < 0) { rawx = -1; }

            if (moveVector.y > 0) { rawy = 1; }
            if (moveVector.y == 0) { rawy = 0; }
            if (moveVector.y < 0) { rawy = -1; }

            animator.SetFloat("moveX", rawx);
            animator.SetFloat("moveY", rawy);
            animator.SetBool("moving", true);
            newestChange = new Vector3(rawx, rawy, 0);
        } else
        {
            animator.SetBool("moving", false);
        }
    }

    private void OnMovementPerformed(InputAction.CallbackContext value)
    {
        moveVector = value.ReadValue<Vector2>();
    }

    private void OnMovementCancelled(InputAction.CallbackContext value)
    {
        moveVector = Vector2.zero;
    }
    public void Respawn()
    {
        rb.transform.position = new Vector3(0, 0, -6); //Spieler Sawned wieder bei 0,0. Die Level müssen einfach so gebaut werden, dass der Spawnpunkt bei diesen Weltkoordinaten ist.
    }
}
