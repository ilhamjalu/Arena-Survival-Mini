using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject resultPanel;
    [SerializeField] TextMeshProUGUI enemyKilledText;
    [SerializeField] TextMeshProUGUI panelTitle;
    [SerializeField] ScoreManager scoreManager;

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
            ShowResultPanel("YOU WIN!");
        }
    }

    public void HandleLoseCondition()
    {
        if(gameEnded) return;

        ShowResultPanel("YOU LOSE!");
    }

    public void ShowResultPanel(string title)
    {
        gameEnded = true;
        Time.timeScale = 0;
        resultPanel.SetActive(true);
        enemyKilledText.text = scoreManager.scoreModel.killCount.ToString();
        panelTitle.text = title;
    }

    public void ResetGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
