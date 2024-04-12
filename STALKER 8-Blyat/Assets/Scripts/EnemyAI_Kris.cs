using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using System.Threading.Tasks;

public class EnemyAi : MonoBehaviour
{
    public Transform playerPos;
    public int movespeed;
    public Rigidbody2D rb;
    private static System.Random rng = new System.Random();
    private Vector3 movegen;
    private bool seen;
    public Transform enemyPos;
    private bool wanderGened;
    public GameObject waypoint;
    private Vector2 movement;
    void Update()
    {
        seen = Detection.Detect(playerPos, enemyPos);
    }
    void FixedUpdate()
    {
        if(seen)
        {
            wanderGened = false;
            movespeed = 3;
            movement = transform.position - playerPos.position;
            movement = Vector2.ClampMagnitude(movement, 1);
            rb.MovePosition(rb.position - movespeed * Time.fixedDeltaTime * movement);
        }
        else
        {
            if(wanderGened == false)
            {
                movegen = WanderGen();
                Debug.Log($"{movegen.x}.{movegen.y}");
                Instantiate(waypoint, movegen, Quaternion.identity);
                movespeed = 1;
                wanderGened = true;
            }
            if(Vector2.Distance(enemyPos.position, movegen) > 0.5)
            {
                Debug.Log(Vector2.Distance(enemyPos.position, movegen));
                movement = enemyPos.position - movegen;
                movement = Vector2.ClampMagnitude(movement, 1);
                rb.MovePosition(rb.position - movespeed * movement * Time.fixedDeltaTime);
            }
            else if(Vector2.Distance(enemyPos.position, movegen) < 0.5) wanderGened = false;

        }
    }
    private Vector3 WanderGen()
    {
        int xMax = rng.Next(-5, 5);
        int yMax = rng.Next(-5, 5);
        movegen.x = transform.position.x + xMax;
        movegen.y = transform.position.y + yMax;
        return movegen;
    }
}