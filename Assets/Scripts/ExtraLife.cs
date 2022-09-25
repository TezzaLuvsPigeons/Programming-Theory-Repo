using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraLife : Powerup
{
    //INHERITANCE
private void OnTriggerEnter(Collider other) {
    if (other.gameObject.CompareTag("Player"))
    {
        PickUp();
        Destroy(gameObject);
    }
}

    protected override void OnPickupFunctionality()
    {
        GameManager.instance.isHeartPickedUp = true;
        GameManager.instance.DestroyExtraLives();
        GameManager.instance.heartImage.SetActive(true);
    }
}
