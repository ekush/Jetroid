using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    public Vector2 moving = new Vector2(); //will use this to determine which direction the player is moving in the game
    
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //setting this to 0 at every frame, then we will normalize the moving direction values so that we know which direction to apply the force to
        moving.x = moving.y = 0;
        if (Input.GetKey("right")) //player moving right
        {
            moving.x = 1;
        } else if (Input.GetKey("left")) //player moving left
        {
            moving.x = -1;
        }

        if (Input.GetKey("up"))
        {
            moving.y = 1;
        } else if (Input.GetKey("down"))
        {
            moving.y = -1;
        }
    }
}
