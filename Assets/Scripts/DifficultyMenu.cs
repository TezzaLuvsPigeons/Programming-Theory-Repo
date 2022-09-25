using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DifficultyMenu : MonoBehaviour
{

    public void Back() {
SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Easy() {
DataSaver.instance.difficultyNum = 0;
DataSaver.instance.difficulty = "Easy";
DataSaver.instance.spawnGap = 11f;
Back();
    }

   public void Medium() {
DataSaver.instance.difficultyNum = 1;
DataSaver.instance.difficulty = "Medium";
DataSaver.instance.spawnGap = 8.5f;
Back();
    }

    public void Hard() {
DataSaver.instance.difficultyNum = 2;
DataSaver.instance.difficulty =  "Hard";
DataSaver.instance.spawnGap = 6f;
Back();
    }


}
