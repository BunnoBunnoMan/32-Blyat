using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using System.Linq;

public class EnemyAi : MonoBehaviour
{
    public Transform playerPos;
    private Ray ray;
    private Vector2 direction;
    public int movespeed = 1;
    public bool seen;
    public Rigidbody2D rb;
    private static System.Random rng = new System.Random();
    private Vector3 movegen;
    void Start()
    {

    }
    void FixedUpdate()
    {
        direction = (playerPos.position - transform.position).normalized;
        seen = Detection();
        StartCoroutine(Updater());
    }
    IEnumerator Updater()
    {
        if(seen)
        {
            Chase();
        }
        else
        {
            Wander();
            yield return new WaitForSecondsRealtime(1);
        }
        yield return null;
    }

    private bool Detection()
    {
        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, direction);
        Debug.DrawRay(transform.position, direction * 50);
        string[] hitList = new string[hits.Length];
        for (int i = 0; i < hits.Length; i++)
        {
            hitList[i] = hits[i].collider.name;
        }
        if (hitList.Contains("Player Temp") && !hitList.Contains("Test Wall")) return true;
        else return false;
    }
    void Wander()
    {
        movegen.x = rng.Next(-10, 10);
        movegen.y = rng.Next(-10, 10);
        Vector2 movement = transform.position - movegen;
        movement = Vector2.ClampMagnitude(movement, 1);
        rb.MovePosition(rb.position + movement * movespeed * Time.fixedDeltaTime);
    }
    void Chase()
    {
        movespeed = 3;
        Vector2 movement = transform.position - playerPos.position;
        movement = Vector2.ClampMagnitude(movement, 1);
        rb.MovePosition(rb.position - movement * movespeed * Time.fixedDeltaTime);
    }
}
