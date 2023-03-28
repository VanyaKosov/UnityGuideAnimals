using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    public TextMeshProUGUI Lives;
    public TextMeshProUGUI Score;

    private int _lives = 3;
    private int _score;

    internal void DecrementLives()
    {
        _lives--;
        ShowLives();
    }

    internal void IncrementScore()
    {
        _score += 100;
        ShowScore();
    }

    private void ShowLives()
    {
        Lives.text = $"Lives: {_lives}";
    }

    private void ShowScore()
    {
        Score.text = $"Score: {_score}";
    }

    void Start()
    {
        ShowLives();
        ShowScore();
    }
}
