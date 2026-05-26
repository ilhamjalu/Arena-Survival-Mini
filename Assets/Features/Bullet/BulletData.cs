using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletData
{
    public int bulletSpeed {  get; private set; }
    public int bulletDamage {  get; private set; }

    public BulletData(int bulletSpeed, int bulletDamage)
    {
        this.bulletSpeed = bulletSpeed;
        this.bulletDamage = bulletDamage;
    }
}
