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

    public float timeBetweenfiring;
    
    public AudioSource m_pew;


    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        m_pew = GetComponent<AudioSource>();
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
            if(timer > timeBetweenfiring)
            {
                canFire = true;
                timer = 0;
            }
        }

        if (Input.GetMouseButton(0) && canFire && !MenuHandler_Kris.paused)
        {   
        
            canFire = false;
            m_pew.Play();
            Instantiate(bullet, bulletTransform.position, quaternion.identity);
        }
        
    }
}
