using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class GunStats : ScriptableObject
{
    public float FireRate;
    public float MagazineSize;
    public float ShotsFired;
    public float ReloadSpeed;
    public int GunDamage;
}
