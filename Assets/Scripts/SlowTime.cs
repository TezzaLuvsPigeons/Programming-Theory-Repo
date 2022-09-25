using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowTime : Powerup
{
//INHERITANCE
private int maxInvSlots = 2;

private void OnTriggerEnter(Collider other) {
    if (other.gameObject.CompareTag("Player"))
    {
        PickUp();
        Destroy(gameObject);
    }
}
    protected override void OnPickupFunctionality()
    {
        if (GameManager.instance.SlowTimeAbilityAmount < maxInvSlots)
        {
           GameManager.instance.IncreaseAbilityAmount(1);
        } else {
            GameManager.instance.IncreaseScore(10);
            Debug.Log("inventory full");
        }
    }

}
