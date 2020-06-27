// to generate random sprites for the collectible objects

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSprite : MonoBehaviour
{
    public Sprite[] sprites; // an array to keep the sprites
    public int currentSprite = -1; // this will be used as a baseline. if this value is -1 then we will select a random sprite
    
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        if (currentSprite == -1) //checking which is the current sprite to determine which sprites to use
        {
            currentSprite = Random.Range(0, sprites.Length);
        } else if (currentSprite > sprites.Length)
        {
            currentSprite = sprites.Length - 1;
        }
        
        
        //select the sprite renderer and set the sprites to a random number between 0 and sprite array length
        GetComponent<SpriteRenderer>().sprite = sprites[currentSprite];  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
