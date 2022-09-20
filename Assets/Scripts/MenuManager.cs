using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class MenuManager : MonoBehaviour
{
    public GameObject startButton;

    public void StartGame() 
    {
SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Exit() {
#if UNITY_EDITOR
EditorApplication.ExitPlaymode();
#else
Application.Exit();
#endif 
    }
}
