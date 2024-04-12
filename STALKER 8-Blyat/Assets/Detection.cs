using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Detection : MonoBehaviour
{
    public bool seen;
    private Ray ray;
    private Vector2 direction;
    public Transform playerPos;
    void Update()
    {
        direction = (playerPos.position - transform.position).normalized;
        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, direction);
        Debug.DrawRay(transform.position, direction * 50);
        string[] hitList = new string[hits.Length];
        for (int i = 0; i < hits.Length; i++)
        {
            hitList[i] = hits[i].collider.name;
        }
        if (hitList.Contains("Player Temp") && !hitList.Contains("Test Wall")) seen = true;
        else seen = false;
    }
}
