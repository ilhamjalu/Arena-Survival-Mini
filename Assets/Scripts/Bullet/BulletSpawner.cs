using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Team
{
    Player,
    Enemy
}

public class BulletSpawner
{
    private readonly BulletController prefab;
    
    public BulletSpawner(BulletController prefab, Team team)
    {
        this.prefab = prefab;
    }

    public void Spawn(Vector2 position, Vector2 direction, Team ownerTeam)
    {
        BulletController bullet = Object.Instantiate(prefab, position, Quaternion.identity);

        bullet.Initialize(direction, ownerTeam);
    }
}
