using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using System.Threading.Tasks;

public class BullAI : MonoBehaviour
{
    public Transform playerPos;
    public float movespeed;
    public Rigidbody2D rb;
    private static System.Random rng = new System.Random();
    private Vector3 movegen;
    public Transform enemyPos;
    public static bool wanderGened;
    public GameObject waypoint;
    private Vector2 movement;
    private float distance;
    private bool seen;
    private bool seenWander;
    public Transform fovRotation;
    private GameObject wayObject;
    private float time;
    void Start()
    {
        wanderGened = false;
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void FixedUpdate()
    {
        if(seen)
        {
            wanderGened = false;
            Destroy(wayObject);
            fovRotation.right = playerPos.position - transform.position;
            time += Time.deltaTime;
            if(time > 2)
            {
                movement = playerPos.position - transform.position;
                movement = Vector2.ClampMagnitude(movement, 1);
                movement.x *= 8F;
                movement.y *= 8F;
                rb.AddForce(movement, ForceMode2D.Impulse);
                time = 0;
            }
            if(Vector2.Distance(enemyPos.position, playerPos.position) > 6.5)
            {
                rb.velocity = Vector2.zero;
            }
        }
        else
        {
            if(!wanderGened)
            {
                movegen = WanderGen();
                wayObject = Instantiate(waypoint, movegen, Quaternion.identity);
                wanderGened = true;
            }
            if(wanderGened)
            {
                movement = enemyPos.position - movegen;
                movement = Vector2.ClampMagnitude(movement,1);
                rb.MovePosition(rb.position - 1 * Time.fixedDeltaTime * movement);
                fovRotation.right = movegen - transform.position;
            }
            if(Vector2.Distance(enemyPos.position, movegen) < 0.5)
            {
                wanderGened = false;
            }
        }
        seen = false;
    }
    private Vector3 WanderGen()
    {
        int xMax = rng.Next(-2, 2);
        int yMax = rng.Next(-2, 2);
        movegen.x = transform.position.x + xMax;
        movegen.y = transform.position.y + yMax;
        return movegen;
    }
    public void SeenDetection(bool ToF)
    {
        if(ToF) seen = true;
        else seenWander = true;
    }
    public void WanderDetection()
    {
        wanderGened = false;
    }
}