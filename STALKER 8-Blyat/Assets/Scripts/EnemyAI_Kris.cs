using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using System.Threading.Tasks;

public class EnemyAi : MonoBehaviour
{
    public Transform playerPos;
    public int movespeed = 1;
    public Rigidbody2D rb;
    private static System.Random rng = new System.Random();
    private Vector3 movegen;
    private bool seen;
    private void FixedUpdate()
    {
        seen = Detection
        if()
        {
            Chase();
        }
        else
        {
        movegen.x = rng.Next(-10, 10);
        movegen.y = rng.Next(-10, 10);
        Debug.Log($"{movegen.x}.{movegen.y}");
        
        }
        
    }
    private void Wander(Vector3 enemyPos)
    {
        while (Vector2.Distance(enemyPos, movegen) != 0)
        {
            Vector3 movement = enemyPos - movegen;
            movement = Vector2.ClampMagnitude(movement, 1);
            rb.MovePosition(enemyPos + movespeed * Time.fixedDeltaTime * movement);
        }
    }
    void Chase()
    {
        movespeed = 3;
        Vector2 movement = transform.position - playerPos.position;
        movement = Vector2.ClampMagnitude(movement, 1);
        rb.MovePosition(rb.position - movespeed * Time.fixedDeltaTime * movement);
    }
}
