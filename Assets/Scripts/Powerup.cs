using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
//INHERITANCE
private MeshRenderer meshRenderer;

    private AudioSource audioSource;
    public AudioClip pickupSound;
    
    private void Awake() {
        audioSource = GameObject.Find("MainCamera").GetComponent<AudioSource>();
        meshRenderer = gameObject.GetComponent<MeshRenderer>();
    }

    protected void PickUp()
    {
        audioSource.PlayOneShot(pickupSound);
        OnPickupFunctionality();
        meshRenderer.enabled = false;
    }

   protected virtual void OnPickupFunctionality() {

   }

}
