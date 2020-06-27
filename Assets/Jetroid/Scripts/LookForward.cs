//collision detection and to change the direction of the alien and making sure its looking forward
// this is added twice to the aliens, first time is for detecting if it hits a wall, second to determine if its running off a platform
// isCollisionNeeded is changed to false for preventing from running off of platform
// two empty objects are needed to separate this two types of behavior 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookForward : MonoBehaviour
{

    public Transform sightStart, SightEnd; // transform of the both the direction at start and end
    public string layer = "Solid"; //this to keep a consistent reference to the layer and will help use reuse this script for other objects
    public bool isCollisionNeeded = true; //to look for a collision or to not look for a collision if there are nothing to hit

    private bool _isCollision; //to detect whether a collision happened or not. default false;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // we will ask the physics2d co cast a line at the beginning and end and to check if it collides with a particular layer by name

        _isCollision = Physics2D.Linecast(sightStart.position, SightEnd.position, 1 << LayerMask.NameToLayer(layer));
        Debug.DrawLine(sightStart.position, SightEnd.position, Color.green);

        if (_isCollision==isCollisionNeeded)
        {
            //bset to use vector3 for localscale
            //if you use vector2 and the z value is 0 then the object will disapear
            transform.localScale = new Vector3(transform.localScale.x == 1 ? -1: 1, 1,1 ); //check which direction the alien is, and reverse it
        }
    }
}
