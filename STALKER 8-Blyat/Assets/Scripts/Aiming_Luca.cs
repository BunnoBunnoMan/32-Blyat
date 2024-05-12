using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
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
    public bool loaded;

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
            if(timer > Stats.FireRate)
            {
                canFire = true;

                timer = 0;
            }

        }
        if (!loaded)
        {
            // Debug.Log("reloading...");
            timer += Time.deltaTime;
            if (timer > Stats.ReloadSpeed)
            {
                Stats.ShotsFired = 0;
                loaded = true;
                timer = 0;
                // Debug.Log("done");
            }
        }

        if (Input.GetMouseButton(0) && canFire && !MenuHandler_Kris.paused && loaded)
        {   
            Stats.ShotsFired ++;
            canFire = false;
            Instantiate(bullet, bulletTransform.position, quaternion.identity);
        }

        if (Stats.ShotsFired >= Stats.MagazineSize){
            loaded = false;
        }

        

        
    }
}
