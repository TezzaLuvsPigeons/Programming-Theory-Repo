using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour

{
    public float speed = 100f;
    [SerializeField] float sidewaysSpeed = 5f;  
    private bool abilityActive = false;
    private bool isPaused = false;

    public Rigidbody playerRb;
    private PlayerCollision playerCollision;
   
    public AudioClip startSloMo;
    public AudioClip stopSloMo;
   

void Start() {
     
     playerCollision = gameObject.GetComponent<PlayerCollision>();

}

void Update()
{
    if (Input.GetKeyDown(KeyCode.Space)) 
    {
    UseAbility(); //use slow time ability
    }

    if (Input.GetKeyDown(KeyCode.Escape)) { //pause game
        if (isPaused == false) {
            isPaused = true;
            GameManager.instance.Pause();
        } else { //unpause game
isPaused = false;
GameManager.instance.Unpause();
        }
    }
    
    MoveForward();
    MoveSideways();

    if (transform.position.y < -2) 
    {
        if (GameManager.instance.isHeartPickedUp == false) {
             GameManager.instance.GameOver();
        } else if(!GameManager.instance.isHeartUsed) {
StartCoroutine(playerCollision.UseLife());
        } else {
            GameManager.instance.GameOver();
        }
   
    }

}

//ABSTRACTION
    void MoveForward() 
    {
playerRb.AddForce(Vector3.forward * speed * Time.deltaTime, ForceMode.Impulse);
    }

//ABSTRACTION
    void MoveSideways() 
    {
float horizontalMovement = Input.GetAxis("Horizontal");
playerRb.AddForce(Vector3.right * horizontalMovement * sidewaysSpeed * Time.deltaTime, ForceMode.Impulse);
    }

    

//SLOW TIME USE FUNCTIONALITY   
    
    void UseAbility() {
  if (GameManager.instance.SlowTimeAbilityAmount != 0 && !abilityActive) 
  {
 abilityActive = true;
    speed /= 2;
GameManager.instance.IncreaseAbilityAmount(-1);
GameManager.instance.audioSource.PlayOneShot(startSloMo);
Invoke(nameof(CancelAbility), 2f);
Debug.Log("Space was pressed!");
  }  else {
    GameManager.instance.audioSource.PlayOneShot(GameManager.instance.declineSound);
  }
}

void CancelAbility() {
   GameManager.instance.audioSource.PlayOneShot(stopSloMo);
    speed *= 2;
    abilityActive = false;
}
}