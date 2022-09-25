using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreBoost : Powerup
{
//INHERITANCE

private PlayerCollision playerCollision;
private float powerupDuration = 5f;

private void Start() {
    playerCollision = GameObject.Find("Player").GetComponent<PlayerCollision>();
}
   
   private void OnTriggerEnter(Collider other) {
    if (other.gameObject.CompareTag("Player"))
    {
        PickUp();
    }
   }

//POLYMORPHISM
    protected override void OnPickupFunctionality() 
    {
StartCoroutine(StartBoost());
    }

    IEnumerator StartBoost() {
playerCollision.scoreMultiplier *= 2;
GameManager.instance.multiplierText.text = "x" + playerCollision.scoreMultiplier.ToString();
yield return new WaitForSeconds(powerupDuration);
playerCollision.scoreMultiplier /= 2;
GameManager.instance.multiplierText.text = "x" + playerCollision.scoreMultiplier.ToString();
Destroy(gameObject);
    }
}
