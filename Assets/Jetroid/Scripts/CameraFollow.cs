// to make the camera follow the player
// to determine the camera resolution dynamically

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject target; // the gameobject target to be followed by the camera
    public float scale = 4f; // camera scale value
    

    private Transform _transform; // to get a referrence to the gameobject transform values


    void Awake()
    {
        // calculating the camera scale in the awake state of the camera
        var camera = GetComponent<Camera>(); //getting a reference to the camera component
        
        //setting the cameras orthographic size
        //dividing by 2 because the screen starts from 0,0 and to get the height, we have to take its value by 50%
        // dividing by the scale will zoom things in 
        // scale is used because the game components are very small in size and camera needs to be adjusted to see them properly
        camera.orthographicSize = (Screen.height / 2f)/scale;  
    }

    // Start is called before the first frame update
    void Start()
    {
        _transform = target.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            //setting the camera transform position based on the target position X and Y and keeping the original Z position
            transform.position = new Vector3(_transform.position.x, _transform.position.y, transform.position.z);
        }
    }
}
