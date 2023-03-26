using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    public TextMeshProUGUI Lives;
    public TextMeshProUGUI Score;

    private int _lives;
    private int _score;

    internal void IncrementScore()
    {
        _score += 100;
        ShowScore();
    }

    private void ShowScore()
    {
        Score.text = $"Score: {_score}";
    }

    void Start()
    {
        ShowScore();
    }
}
