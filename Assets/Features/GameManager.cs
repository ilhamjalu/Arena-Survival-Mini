using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject winPanel;
    [SerializeField] GameObject losePanel;

    public bool gameEnded;

    private void OnEnable()
    {
        GameEvents.OnPlayerDead += HandleLoseCondition;

        GameEvents.OnScoreChanged += HandleWinCondition;
    }

    private void OnDisable()
    {
        GameEvents.OnPlayerDead -= HandleLoseCondition;

        GameEvents.OnScoreChanged -= HandleWinCondition;
    }

    public void HandleWinCondition(int score)
    {
        if (gameEnded) return;

        if(score >= 50)
        {
            WinGame();
        }
    }

    public void HandleLoseCondition()
    {
        if(gameEnded) return;

        LoseGame();
    }

    public void WinGame()
    {
        gameEnded = true;
        Time.timeScale = 0;
        winPanel.SetActive(true);
    }

    public void LoseGame()
    {
        gameEnded = true;
        Time.timeScale = 0;
        losePanel.SetActive(true);
    }

    public void ResetGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
