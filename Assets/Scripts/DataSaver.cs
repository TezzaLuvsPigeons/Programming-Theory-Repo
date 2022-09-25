using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataSaver : MonoBehaviour
{
public static DataSaver instance;

    public int difficultyNum = 0;
public string difficulty = "Easy"; 
public float spawnGap = 11f; 

    private void Awake() {
        if (instance != null){
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
