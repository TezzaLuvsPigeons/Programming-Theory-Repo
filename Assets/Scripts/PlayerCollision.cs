using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    private SpawnManager spawnManager;
    private PlayerController playerMovement;
GameObject[] obstacleInstances;
GameObject[] slowTimeInstances;
GameObject[] scoreBoostInstances;


    public int scoreMultiplier = 1;
    

    private void Start() 
    {
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        playerMovement = gameObject.GetComponent<PlayerController>();
    }

     private void OnCollisionEnter(Collision other) 
 {
       if ((other.gameObject.name == "Obstacle" || other.gameObject.name == "Obstacle(Clone)") && GameManager.instance.isHeartPickedUp == false) //if the heart was used, the player shouldnt be able to revive again
       {
         GameManager.instance.audioSource.PlayOneShot(GameManager.instance.crashSound);
     GameManager.instance.GameOver();
       } 
       else if((other.gameObject.name == "Obstacle" || other.gameObject.name == "Obstacle(Clone)") && !GameManager.instance.isHeartUsed) 
       {
         GameManager.instance.audioSource.PlayOneShot(GameManager.instance.crashSound);
StartCoroutine(UseLife());
       } 
       else if (other.gameObject.name == "Obstacle" || other.gameObject.name == "Obstacle(Clone)") 
       {
         GameManager.instance.audioSource.PlayOneShot(GameManager.instance.crashSound);
        GameManager.instance.GameOver();
       }
 }

 public IEnumerator UseLife() 
 {
  playerMovement.enabled = false;
  yield return new WaitForSeconds(1);

 transform.position = new Vector3(0, 1, transform.position.z);
 playerMovement.playerRb.angularVelocity = new Vector3(0, 0, 0);
 transform.rotation = Quaternion.Euler(0, 0, 0);

scoreBoostInstances = GameObject.FindGameObjectsWithTag("ScoreBoost");
slowTimeInstances = GameObject.FindGameObjectsWithTag("SlowTime");
obstacleInstances = GameObject.FindGameObjectsWithTag("Obstacle");

for (int i = 0; i < scoreBoostInstances.Length; i++) 
{
Destroy(scoreBoostInstances[i].gameObject);
}

for (int i = 0; i < slowTimeInstances.Length; i++) 
{
Destroy(slowTimeInstances[i].gameObject);
}

for (int i = 0; i < obstacleInstances.Length; i++) 
{
Destroy(obstacleInstances[i].gameObject);
spawnManager.spawnDistance = transform.position.z + 50;
}

GameManager.instance.isHeartUsed = true;
GameManager.instance.heartImage.SetActive(false);
playerMovement.enabled = true;
 }

 private void OnTriggerEnter(Collider other) 
 {
  StartCoroutine(destroyObject());
 
    IEnumerator destroyObject()
    {
        if ((other.gameObject.name == "Obstacle" || other.gameObject.name == "Obstacle(Clone)") && other.gameObject != null) 
        {
        GameManager.instance.IncreaseScore(scoreMultiplier);
        yield return new WaitForSeconds(1f);
        if (other != null) {
Destroy(other.gameObject);
        }
        
        }     
    }
 }

 
}
 
