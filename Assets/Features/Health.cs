using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health
{
    public int HP { get; private set; }

    public bool isDead => HP <= 0;

    public event Action OnDead;

    public Health(int startHP) 
    {
        HP = startHP;  
    }

    public void Damage(int amount)
    {
        HP -= amount;

        if(isDead)
        {
            OnDead?.Invoke();
        }
    }
}
