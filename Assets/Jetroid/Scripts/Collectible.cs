//collectible items

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    // This will occur when player collides with the collectible items. Trigger makes the collision detectable but lets the player go through the object
    // target game object is the player
    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.tag == "Player") // checking if the target is the player
        {
            Destroy(gameObject); // when player touches the collectible, destroy/remove the collectible from the screen
        }
    }
}
