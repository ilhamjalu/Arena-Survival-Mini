using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreView : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    
    public void UpdateScoreText(int score)
    {
        scoreText.text = $"Score : {score}";
    }
}
