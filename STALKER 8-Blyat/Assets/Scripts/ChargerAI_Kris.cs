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
    public Transform enemyPos;
    public static bool wanderGened;
    public GameObject waypoint;
    private Vector2 movement;
    private float distance;
    public static bool seen;
    public static bool seenWander;
    public Transform fovRotation;
    private GameObject wayObject;
    void Start()
    {
        wanderGened = false;
    }
    void FixedUpdate()
    {
        if(seen)
        {
            wanderGened = false;
            Destroy(wayObject);
            movement = transform.position - playerPos.position;
            movement = Vector2.ClampMagnitude(movement, 1);
            rb.MovePosition(rb.position - movespeed * Time.fixedDeltaTime * movement);
            fovRotation.right = playerPos.position - transform.position;
        }
        else
        {
            if(!wanderGened || !wayObject.activeInHierarchy)
            {
                movegen = WanderGen();
                wayObject = Instantiate(waypoint, movegen, Quaternion.identity);
                wanderGened = true;
            }
            else if(wayObject.activeInHierarchy)
            {
                movement = enemyPos.position - wayObject.transform.position;
                movement = Vector2.ClampMagnitude(movement,1);
                rb.MovePosition(rb.position - 1 * Time.fixedDeltaTime * movement);
                fovRotation.right = wayObject.transform.position - transform.position;
            }
            if(Vector2.Distance(enemyPos.position, wayObject.transform.position) < 0.5)
            {
                //Destroy(wayObject);
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
}