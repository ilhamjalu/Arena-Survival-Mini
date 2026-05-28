using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] ScoreView scoreView;
    [SerializeField] public Score scoreModel;

    // Start is called before the first frame update
    void Start()
    {
        scoreModel = new Score();

        scoreView = GetComponent<ScoreView>();
    }

    private void OnEnable()
    {
        GameEvents.OnEnemyKilled += HandleEnemyKilled;
    }

    private void OnDisable()
    {
        GameEvents.OnEnemyKilled -= HandleEnemyKilled;
    }

    private void HandleEnemyKilled(int score)
    {
        scoreModel.AddScore(score);

        scoreModel.AddKill();

        scoreView.UpdateScoreText(scoreModel.score);

        GameEvents.OnScoreChanged?.Invoke(scoreModel.score);
    }
}
