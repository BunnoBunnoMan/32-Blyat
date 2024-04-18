using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using System.Threading.Tasks;

public class ChargerAi : MonoBehaviour
{
    public Transform playerPos;
    public float movespeed;
    public Rigidbody2D rb;
    private static System.Random rng = new System.Random();
    private Vector3 movegen;
    private bool seen;
    private bool seenWander;
    public Transform enemyPos;
    private bool wanderGened;
    public GameObject waypoint;
    private Vector2 movement;
    private float distance;
    void FixedUpdate()
    {
        distance = 20;
        seen = Detection.Detect(playerPos.position, enemyPos, distance);
        if(seen)
        {
            wanderGened = false;
            movement = transform.position - playerPos.position;
            movement = Vector2.ClampMagnitude(movement, 1);
            rb.MovePosition(rb.position - movespeed * Time.fixedDeltaTime * movement);
        }
        else
        {
            if(wanderGened == false || !seenWander)
            {
                movegen = WanderGen();
                //Debug.Log($"{movegen.x}.{movegen.y}");
                Instantiate(waypoint, movegen, Quaternion.identity);
                wanderGened = true;
            }
            distance = 0.25F;
            seenWander = Detection.Detect(movegen, enemyPos, distance);
            if(Vector2.Distance(enemyPos.position, movegen) > 0.5 && seenWander)
            {
                //Debug.Log(Vector2.Distance(enemyPos.position, movegen));
                movement = enemyPos.position - movegen;
                movement = Vector2.ClampMagnitude(movement, 1);
                rb.MovePosition(rb.position - 1 * movement * Time.fixedDeltaTime);
            }
            else if(Vector2.Distance(enemyPos.position, movegen) < 0.5) wanderGened = false;
        }
    }
    private Vector3 WanderGen()
    {
        int xMax = rng.Next(-1, 1);
        int yMax = rng.Next(-1, 1);
        movegen.x = transform.position.x + xMax;
        movegen.y = transform.position.y + yMax;
        return movegen;
    }
}