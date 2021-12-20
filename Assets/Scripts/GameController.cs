using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static bool isPaused;
    public static int score;
    void Start()
    {
        isPaused = false;
        score = 0;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }
    private static void Pause()
    {
        PauseUIController.ShowPauseUI(true);
        Time.timeScale = 0f;
    }
    private static void Resume()
    {
        PauseUIController.ShowPauseUI(false);
        Time.timeScale = 1f;
    }
    public static void TogglePause()
    {
        isPaused = !isPaused;

        switch (isPaused)
        {
            case true:
                Pause();
                break;
            case false:
                Resume();
                break;
        }
    }

    public static void AddScore(int _score)
    {
        score += _score;
        InGameUIController.SetScore(score);
    }

}
