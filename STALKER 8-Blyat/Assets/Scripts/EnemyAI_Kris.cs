using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAi : MonoBehaviour
{
    public Transform enemyPos;
    public Transform playerPos;
    private Ray ray;
    private Vector2 direction;
    void Start()
    {

    }
    void Update()
    {
        direction = (playerPos.position - enemyPos.position).normalized;
        
        Detection();
    }

    void Detection()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(enemyPos.position, direction);
        Debug.DrawRay(enemyPos.position, direction * 50);
        if (hitInfo.collider.gameObject.name == "Player Temp")
        {
            Debug.Log("You got pingased");
        }
    }
}
