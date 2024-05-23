using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultGun : MonoBehaviour
{
    public GunStats Stats;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("defaultGunBox");
        Stats.FireRate = 0.8f;
        Stats.MagazineSize = 2f;
        Stats.ReloadSpeed = 3f;
        Stats.ShotsFired = 0f;
        Stats.GunDamage = 8;
    }
}
