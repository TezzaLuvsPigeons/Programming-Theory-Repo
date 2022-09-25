using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

public GameObject player;
private Vector3 offset = new Vector3(0f, 1.6f, -5f);
    
    void Update()
    {
        transform.position = player.transform.position + offset;
    }
}
