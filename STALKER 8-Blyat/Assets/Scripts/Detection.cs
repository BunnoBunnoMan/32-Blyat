using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using UnityEngine.Rendering;
using JetBrains.Annotations;

public class Detection : MonoBehaviour
{
    public bool seen;
    public Transform position;
    public float fov;
    public int levelOfDetail;
    public float viewDistance;
    public LayerMask layerMask;
    private Mesh mesh;
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
    }*/
    void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        /*float angle = 0f;
        float angleIncrease = fov / levelOfDetail;

        Vector3[] vertices = new Vector3[levelOfDetail + 2];
        int[] triangles = new int[levelOfDetail * 3];
        vertices[0] = Vector3.zero;

        int vertexIndex = 1;
        int triangleIndex = 0;
        for (int i = 0; i <= levelOfDetail; i++)
        {
            Vector3 vertex;
            RaycastHit2D hit = Physics2D.Raycast(position.position, VectorFromAngle(angle), viewDistance, layerMask);
            //Debug.DrawRay(position.position, VectorFromAngle(angle), Color.white, viewDistance);
            if(hit.collider == null)
            {
                vertex = Vector3.zero + VectorFromAngle(angle) * viewDistance;
                Debug.Log("No Hit:" + vertex);
            }
            else
            {
                vertex = hit.point;
                Debug.Log("Hit:" + hit.point);
            }
            vertices[vertexIndex] = vertex;
            if(i > 0)
            {
                triangles[triangleIndex + 2] = 0;
                triangles[triangleIndex + 1] = vertexIndex - 1;
                //Debug.Log("vertexindex:" + vertices[vertexIndex - 1]);
                triangles[triangleIndex] = vertexIndex;
                //Debug.Log("vertexindex - 1:" + vertices[vertexIndex]);
                triangleIndex += 3;
            }
            vertexIndex++;
            angle -= angleIncrease;
        }

        mesh.vertices = vertices;
        mesh.triangles = triangles;*/
        
    }
    void Update()
    {
        float angle = 0f;
        float angleIncrease = fov / levelOfDetail;

        Vector3[] vertices = new Vector3[levelOfDetail + 2];
        int[] triangles = new int[levelOfDetail * 3];
        vertices[0] = Vector3.zero;

        int vertexIndex = 1;
        int triangleIndex = 0;
        for (int i = 0; i <= levelOfDetail; i++)
        {
            Vector3 vertex;
            RaycastHit2D hit = Physics2D.Raycast(position.position, VectorFromAngle(angle), viewDistance, layerMask);
            //Debug.DrawRay(position.position, VectorFromAngle(angle), Color.white, viewDistance);
            if(hit.collider == null)
            {
                vertex = Vector3.zero + VectorFromAngle(angle) * viewDistance;
                Debug.Log(vertex);
            }
            else
            {
                Vector3 point = hit.point;
                vertex = point - transform.position;
                Debug.Log(hit.point);
            }
            vertices[vertexIndex] = vertex;
            if(i > 0)
            {
                triangles[triangleIndex] = 0;
                triangles[triangleIndex + 1] = vertexIndex - 1;
                Debug.Log("vertexindex:" + vertices[vertexIndex - 1]);
                triangles[triangleIndex + 2] = vertexIndex;
                Debug.Log("vertexindex - 1:" + vertices[vertexIndex]);
                triangleIndex += 3;
            }
            vertexIndex++;
            angle -= angleIncrease;
        }

        mesh.vertices = vertices;
        mesh.triangles = triangles;
    }
    public Vector3 VectorFromAngle(float angle)
    {
        float angleRad = angle * Mathf.Deg2Rad;//(Mathf.PI /180f);
        return new Vector3(Mathf.Cos(angleRad),Mathf.Sin(angleRad));
    }
}
