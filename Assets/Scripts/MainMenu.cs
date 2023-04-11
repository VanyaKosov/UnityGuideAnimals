using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public Canvas GameCanvas;

    public SpawnManager SpawnManager;

    private void StartGame(float interval)
    {
        SpawnManager.SpawnInterval = interval;

        SpawnManager.enabled = true;

        GameCanvas.enabled = true;
        gameObject.SetActive(false);
    }

    public void Easy()
    {
        StartGame(0.75f);
    }

    public void Medium()
    {
        StartGame(0.5f);
    }

    public void Hard()
    {
        StartGame(0.3f);
    }

    public void SoulsLike()
    {
        StartGame(0.2f);
    }

    void Start()
    {

    }
}
