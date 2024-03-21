using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aiming : MonoBehaviour
{
    private Camera cam;
    private Vector3 mousePos;

    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 rotation = mousePos - transform.position;
        float z = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg + 90;
        transform.rotation = Quaternion.Euler(0, 0, z);
    }
}
