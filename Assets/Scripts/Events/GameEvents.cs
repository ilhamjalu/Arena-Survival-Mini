using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameEvents
{
    public static Action<int> OnEnemyKilled;
    public static Action OnPlayerDead;
    public static Action<int> OnScoreChanged;
}
