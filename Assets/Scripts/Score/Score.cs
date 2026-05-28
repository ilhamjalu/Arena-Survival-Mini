using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score
{
    public int score {  get; private set; }
    public int killCount {  get; private set; }

    public void AddScore (int amount)
    {
        score += amount;
    }

    public void AddKill()
    {
        killCount++;
    }
}
