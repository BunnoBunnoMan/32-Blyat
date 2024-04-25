using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Aiming : MonoBehaviour
{
    private Camera cam;
    private Vector3 mousePos;
    public GameObject bullet;
    public Transform bulletTransform;
    public bool canFire;
    private float timer;

    public GunStats Stats;
    public float TimeBetweenFiring;

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
        
        float z = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg + 180;
        
        transform.rotation = Quaternion.Euler(0, 0, z);

        if (!canFire)
        {
            timer += Time.deltaTime;
            if(timer > Stats.FireRate) // figure out a way to change the time between firing
            {
                canFire = true;
                timer = 0;
            }
        }

        if (Input.GetMouseButton(0) && canFire && !MenuHandler_Kris.paused)
        {   
        
            canFire = false;
            Instantiate(bullet, bulletTransform.position, quaternion.identity);
        }
        
    }
}