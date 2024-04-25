using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed;

    public Animator animator;
    private Vector2 movement;
    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

       
    }
    private void FixedUpdate()
    {
        movement = Vector2.ClampMagnitude(movement, 1);
        rb.MovePosition(rb.position + moveSpeed * Time.fixedDeltaTime * movement);
        animator.SetFloat("horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("speed", movement.sqrMagnitude);
    }
}
