using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class Detection : MonoBehaviour
{
    public bool seen;
    private Ray ray;
    private Vector2 direction;
    public Transform playerPos;
    public static bool Detect(Vector3 playerPos, Transform enemyPos)
    {
        Vector2 direction = (playerPos - enemyPos.position).normalized;
        RaycastHit2D[] hits = Physics2D.RaycastAll(enemyPos.position, direction, 5);
        Debug.DrawRay(enemyPos.position, direction * 50);
        string[] hitList = new string[hits.Length];
        for (int i = 0; i < hits.Length; i++)
        {
            hitList[i] = hits[i].collider.tag;
        }
        if (!hitList.Contains("Walls")) return true;
        else return false;
    }
}
