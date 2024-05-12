using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mesh : MonoBehaviour
{
    // Start is called before the first frame update
    public LayerMask layerMask;
    void Start()
    {
        Mesh mesh = new();
        
        Vector3[] vertices = new Vector3[3];
        int[] triangles = new int[3];
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up);
        RaycastHit2D bed = Physics2D.Raycast(transform.position, VectorFromAngle(45), 50);
        vertices[0] = Vector3.zero;
        vertices[1] = new Vector3(-10, 2.96F);
        Debug.Log(VectorFromAngle(45));
        Debug.Log(hit.distance);
        Debug.Log(hit.point);
        Vector3 whatYouStandToGain = new Vector3(hit.point.x, hit.distance);
        Vector3 point = bed.point;
        Vector3 turnThePage = point - transform.position;
        Vector3 darkAge = new Vector3(0, hit.distance);
        vertices[2] = turnThePage;
        Debug.Log(point);
        Debug.Log(turnThePage);
        

        triangles[0] = 0;
        triangles[1] = 1;
        triangles[2] = 2;
        
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        
        GetComponent<MeshFilter>().mesh = mesh;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, new Vector2(50,50));//VectorFromAngle(45));
    }
    public Vector3 VectorFromAngle(float angle)
    {
        float angleRad = angle * Mathf.Deg2Rad;//(Mathf.PI /180f);
        return new Vector3(Mathf.Cos(angleRad),Mathf.Sin(angleRad));
    }
}
