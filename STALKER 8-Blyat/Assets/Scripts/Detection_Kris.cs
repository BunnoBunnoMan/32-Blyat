using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using UnityEngine.Rendering;
using JetBrains.Annotations;
using Unity.VisualScripting;
using Unity.Mathematics;
using UnityEngine.UIElements;

public class Detection : MonoBehaviour
{
    public bool seen;
    public Transform position;
    public Transform fovRotation;
    public float fov;
    public int levelOfDetail;
    public float viewDistance;
    public LayerMask layerMask;
    private Mesh mesh;
    public GameObject fovPhysics;
    //public static float rayAngle;
    //public static float rayAngle;
    /*public static bool Detect(Vector3 playerPos, Transform enemyPos, float distance)
    {
        Vector2 direction = (playerPos - enemyPos.position).normalized;
        RaycastHit2D[] hits = Physics2D.RaycastAll(enemyPos.position, direction, distance);
        Debug.DrawRay(enemyPos.position, direction * distance);
        string[] hitList = new string[hits.Length];
        for (int i = 0; i < hits.Length; i++)
        {
            hitList[i] = hits[i].collider.tag;
        }
        Debug.Log(Array.IndexOf(hitList, "Cover"));
        if (!(hitList[1] == "Cover")) return true;
        else return false;
    } ^Defunkt */
    void Start()
    {
        mesh = new Mesh();
    }
    void Update()
    {
        float rayAngle = fovRotation.eulerAngles.z +45;
        float angleIncrease = fov / levelOfDetail;
        Vector3[] vertices = new Vector3[levelOfDetail + 2];
        Vector2[] points = new Vector2[vertices.Length];
        int[] triangles = new int[levelOfDetail * 3];
        vertices[0] = Vector3.zero;

        int vertexIndex = 1;
        int triangleIndex = 0;
        for (int i = 0; i <= levelOfDetail; i++)
        {
            Vector3 vertex;
            RaycastHit2D hit = Physics2D.Raycast(position.position, VectorFromAngle(rayAngle), viewDistance, layerMask);
            Debug.DrawRay(position.position, Vector3.zero + VectorFromAngle(rayAngle) * viewDistance);
            if(hit.collider == null)
            {
                vertex = Vector3.zero + VectorFromAngle(rayAngle) * viewDistance;
            }
            else
            {
                Vector3 point = hit.point;
                vertex = point - position.position;
            }
            vertices[vertexIndex] = vertex;
            points[vertexIndex] = vertex;
            if(i > 0)
            {
                triangles[triangleIndex] = 0;
                triangles[triangleIndex + 1] = vertexIndex - 1;
                triangles[triangleIndex + 2] = vertexIndex;
                triangleIndex += 3;
            }
            vertexIndex++;
            rayAngle -= angleIncrease;
        }

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        fovPhysics.GetComponent<PolygonCollider2D>().points = points;
        
    }
    public static Vector3 VectorFromAngle(float angle)
    {
        float angleRad = angle * Mathf.Deg2Rad;//(Mathf.PI /180f);
        return new Vector3(Mathf.Cos(angleRad),Mathf.Sin(angleRad));
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            //ChargerAi.seen = true;
            SendMessage("SeenDetection", true);
        }
        else if(collision.gameObject.name == "waypoint")
        {
            //ChargerAi.seenWander = true;
            SendMessage("SeenDetection", false);
            Debug.Log("Running detect");
        }
    }
}
