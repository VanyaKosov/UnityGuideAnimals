using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    public TextMeshProUGUI Lives;
    public TextMeshProUGUI Score;
    public GameObject DeathMessage;

    private int _lives = 3;
    private int _score;

    internal void DecrementLives()
    {
        _lives--;
        ShowLives();
        if (_lives == 0)
        {
            EndGame();
        }
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
