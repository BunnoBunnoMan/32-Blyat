using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class FasterGun : MonoBehaviour
{
    public GunStats Stats;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("defaultGunBox");
        Stats.FireRate = 0.3f;
        Stats.MagazineSize = 10f;
        Stats.ReloadSpeed = 2f;
        Stats.ShotsFired = 0f;
    }
}
