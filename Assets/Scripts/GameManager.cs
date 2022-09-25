using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.IO;

public class GameManager : MonoBehaviour
{

public TextMeshProUGUI scoreText;
public TextMeshProUGUI multiplierText;
public TextMeshProUGUI slowTimeText;
public TextMeshProUGUI highScoreText;
public TextMeshProUGUI difficultyText;

public static GameManager instance;

private GameObject[] extraLifeInstances;
public GameObject heartImage;
public GameObject pauseMenu;
public PlayerController player;
public int score;
public int highScore;
public int SlowTimeAbilityAmount;
public bool isHeartUsed = false;
public bool isHeartPickedUp = false;

public AudioSource audioSource;
public AudioClip crashSound;
public AudioClip declineSound;


//There is a highScore variable for each difficulty, for ex: if the difficulty is easy, the score is added to the easyHighScore variable, and it is displayed
//the program checks for which difficulty is selected,
private void Awake() {
    instance = this;
}

private void Start() 
{

    if (heartImage == null) {
        return;
    }
LoadHighScore();

audioSource = GameObject.Find("MainCamera").GetComponent<AudioSource>();
Time.timeScale = 1f;
score = 0;
SlowTimeAbilityAmount = 0;
highScoreText.text = "High Score: " + highScore;
difficultyText.text = "Difficulty: " + DataSaver.instance.difficulty;
}

public void IncreaseScore(int scoreToAdd) 
{
    score += scoreToAdd;
    scoreText.text = score.ToString();

    if (score > highScore) 
    {
        highScore = score;
        highScoreText.text = "High Score: " + highScore;
    }
}

public void IncreaseAbilityAmount(int amountToAdd) 
{
    SlowTimeAbilityAmount += amountToAdd;
    slowTimeText.text = SlowTimeAbilityAmount + "/2";
}

    public void GameOver() 
    {
        SaveHighScore();
        player.enabled = false;
        Invoke(nameof(Restart), 2f);
    }
    
    private void Restart() 
    {
SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
    public void Pause() {
pauseMenu.gameObject.SetActive(true);
Time.timeScale = 0f;
    }

    public void Unpause() {
pauseMenu.gameObject.SetActive(false);
Time.timeScale = 1f;
    }

    public void OpenMainMenu() {
        SaveHighScore();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void DestroyExtraLives() 
    {
        extraLifeInstances = GameObject.FindGameObjectsWithTag("ExtraLife");

        for(int i = 0; i < extraLifeInstances.Length; i++)
        {
            Destroy(extraLifeInstances[i].gameObject);
        }
    }

    [System.Serializable]
     private class SaveData
     {
        public int highScore;
     }

     public void SaveHighScore() 
     {
        SaveData data = new SaveData();
data.highScore = highScore;

string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
     }

     public void LoadHighScore() 
     {
         string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
                SaveData data = JsonUtility.FromJson<SaveData>(json);

                highScore = data.highScore;
        }
     }

}
