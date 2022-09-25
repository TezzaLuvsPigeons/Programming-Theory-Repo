using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

public float spawnDistance = 50f;
public List<GameObject> objectPrefabs;
private GameObject objectToSpawn;
GameObject[] objects;
GameObject[] extraLifeInstances;
GameObject[] obstacleInstances;
GameObject[] slowTimeInstances;
GameObject[] scoreBoostInstances;
private int objectCount;
public int objectCountLimit = 40;

//ENCAPSULATION
private int ObjectCountLimit {
    get {return objectCountLimit;}
    set {
if (value > 40) {
    value = 40;
}
if (value < 20) {
    value = 20;
}
objectCountLimit = value;
    }
}

private float spawnGap;
private float startSpawnDelay = 0.1f;
private float spawnDelay = 0.1f;

private void Start() {
    spawnGap = DataSaver.instance.spawnGap;
    InvokeRepeating(nameof(SpawnObject), startSpawnDelay, spawnDelay);
}

private void SpawnObject() 
{
    if (objectCount < objectCountLimit)
    {
Instantiate(ChooseObjectToSpawn(), GenerateSpawnPosition(), objectToSpawn.transform.rotation);
    }

}

private Vector3 GenerateSpawnPosition() 
{
spawnDistance += spawnGap;
float xPos = Random.Range(-6.24f, 6.24f);
float yPos = 1.4f;
Vector3 spawnPos = new Vector3(xPos, yPos, spawnDistance);
return spawnPos;
}

private GameObject ChooseObjectToSpawn() 
{ // 0.5% chance extra life, 1.5% chance slow time, 5% score boost, 92% obstacle chance spawnrate
int randomNum = Random.Range(0, 1001);
if (randomNum < 5 && !GameManager.instance.isHeartPickedUp) objectToSpawn = objectPrefabs[0];
else if (randomNum < 20) objectToSpawn = objectPrefabs[1];
else if (randomNum < 70) objectToSpawn = objectPrefabs[2];
else objectToSpawn = objectPrefabs[3];
return objectToSpawn;
}

private void Update() 
{
extraLifeInstances = GameObject.FindGameObjectsWithTag("ExtraLife");
scoreBoostInstances = GameObject.FindGameObjectsWithTag("ScoreBoost");
slowTimeInstances = GameObject.FindGameObjectsWithTag("SlowTime");
obstacleInstances = GameObject.FindGameObjectsWithTag("Obstacle");
    objectCount = extraLifeInstances.Length + scoreBoostInstances.Length + slowTimeInstances.Length + obstacleInstances.Length;
   
}

}
