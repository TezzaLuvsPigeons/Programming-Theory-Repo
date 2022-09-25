using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using TMPro;

public class MenuManager : MonoBehaviour
{
    public GameObject startButton;
    public TextMeshProUGUI highScoreText;
    public TextMeshProUGUI difficultyText;


private void Start() {
GameManager.instance.LoadHighScore();
highScoreText.text = "High Score: " + GameManager.instance.highScore;
difficultyText.text = "Difficulty: " + DataSaver.instance.difficulty;
}
private void Awake() {

}

    public void StartGame() 
    {
        GameManager.instance.SaveHighScore();
SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Exit() {
#if UNITY_EDITOR
EditorApplication.ExitPlaymode();
#else
Application.Exit();
#endif 
    }

    public void DifficultyMenu() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
