using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack
{
    private int damage;
    private float cooldown;
    private float timer;

    public bool canAttack => timer <= 0;

    public EnemyAttack(int damage, float cooldown)
    {
        this.damage = damage;
        this.cooldown = cooldown;
    }

    public void TimerCountdown(float deltatime)
    {
        if(timer > 0)
        {
            timer -= deltatime;
        }
    }

    public void ConsumeAttack()
    {
        timer = cooldown;
    }
}
