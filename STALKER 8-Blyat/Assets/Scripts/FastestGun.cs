using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastestGun : MonoBehaviour
{
   public GunStats Stats;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("defaultGunBox");
        Stats.FireRate = 0.1f;
    }
}
