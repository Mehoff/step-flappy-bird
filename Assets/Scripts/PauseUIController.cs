using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEditor;

public class PauseUIController : MonoBehaviour
{
    private static Canvas canvas;
    public Button restrartButton;
    public Button resumeButton;
    public Button exitButton;
    public TextMeshProUGUI spawnRateTextMesh;
    public Slider spawnRateSlider;


    void Start()
    {
        canvas = GetComponent<Canvas>();

        restrartButton.onClick.AddListener(Restart);
        resumeButton.onClick.AddListener(Resume);
        exitButton.onClick.AddListener(Exit);
        spawnRateSlider.onValueChanged.AddListener(SpawnRateSliderChangleHanlder);

        ShowPauseUI(false);
    }
    public static void ShowPauseUI(bool action)
    {
        canvas.gameObject.SetActive(action);
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Resume();
    }
    public void Resume()
    {
        if (GameController.isPaused)
            GameController.TogglePause();
    }
    public void Exit()
    {
        Resume();
        Application.Quit();
    }
    public void SpawnRateSliderChangleHanlder(float _value)
    {
        int value = (int)_value;
        PipeController.SetSpawnColldownSeconds(value);
        spawnRateTextMesh.text = $"Spawnrate - each {value}s";
    }
}
