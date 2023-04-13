using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    private const int LIVES = 3;

    public TextMeshProUGUI Lives;
    public TextMeshProUGUI Score;
    public GameObject DeathMessage;

    private int _lives = LIVES;
    private int _score;

    internal void ResetCounters()
    {
        _lives = LIVES;
        _score = 0;

        ShowLives();
        ShowScore();
    }

    internal void DecrementLives()
    {
        _lives--;
        ShowLives();
        if (_lives == 0)
        {
            EndGame();
        }
    }

    internal void IncrementScore(int points)
    {
        _score += points;
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

    private void EndGame()
    {
        EndGameOfEntities<Move>();
        EndGameOfEntities<Animator>();
        EndGameOfEntities<SpawnManager>();
        EndGameOfEntities<PlayerController>();

        DeathMessage.SetActive(true);
    }

    private void EndGameOfEntities<T>() where T : Behaviour
    {
        var objects = FindObjectsOfType<T>();
        foreach (var obj in objects)
        {
            obj.enabled = false;
        }
    }
}
