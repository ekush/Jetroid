using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float speed = 150f;
    public Vector2 maxVelocity = new Vector2(60,100); // As we move the player we dont want the player to go above the maximum velocity
    public float jetSpeed = 200f; //speed of the jet
    public bool isPlayerStanding; //player standing or not
    public float standingThreshold = 4f; //standing threshold - to determine if the player has hit the ground and if its okay to consider him standing
    public float airSpeedMultiplier = .3f;  //we want the air speed to be less than the ground speed i.e. 30% of the normal speed



    private Rigidbody2D _body2D; // The RigidBody component
    private SpriteRenderer _renderer2D; //The SpriteRenderer component
    private PlayerController _playerController;  //reference to the player controller
    private Animator _animator; //reference to the animator object
    
    // Start is called before the first frame update
    void Start()
    {
        //initialize reference to all the private variables used to control the players properties 
        _body2D = GetComponent<Rigidbody2D>();
        _renderer2D = GetComponent<SpriteRenderer>();
        _playerController = GetComponent<PlayerController>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        var absVelX = Mathf.Abs(_body2D.velocity.x); //absolute velocity in X direction
        var absVelY = Mathf.Abs(_body2D.velocity.y); //absolute velocity in Y direction

        if (absVelY <= standingThreshold) //to check if the player has landed properly and is okay to stand
        {
            isPlayerStanding = true;
        }
        else
        {
            isPlayerStanding = false;
        }
        
        
        //variables for force
        var forceX = 0f;
        var forceY = 0f;
        
        //Detect which keys are being pressed

        if (_playerController.moving.x != 0)  //right arrow key checked comparing with playercontroller variable
        {
            if (absVelX < maxVelocity.x) //checking if the absolute velocity is less than maximum velocity
            {
                var newSpeed = speed * _playerController.moving.x; //calculating new speed 1 for right, -1 for left
                forceX = isPlayerStanding ? newSpeed: (newSpeed*airSpeedMultiplier); //checking if the player is standing, if not multiplying with the airspeed
                _renderer2D.flipX = forceX < 0; //changing the direction of the animation of the player looking towards depending on the force in x direction
            }
            _animator.SetInteger("AnimState", 1); // setting the integer to the AnimState property set in the animator state machine
        }
        else
        {
            //when the player is not moving, set the animation back to player idle animation
            _animator.SetInteger("AnimState", 0); //animation state back to 0 for idle 
        }
        // up key is being checked separately because we want the player to be able to move when they are on the air.
        // if we checked this under one block, then the player wont be able to move on air. i.e. the player will only move to one direction at a time

        if (_playerController.moving.y >0) //up key pressed Y value will be higher than 0
        {
            if (absVelY < maxVelocity.y) //checking to make sure player doesn't go over max velocity
            {
                forceY = jetSpeed*_playerController.moving.y;
            }
            _animator.SetInteger("AnimState", 2); //setting the animation state to player jetpack state 
        } else if (absVelY >0 && !isPlayerStanding) // when Y velocity is greater than 0 and player is not standing
        {
            _animator.SetInteger("AnimState", 3);
        }
        _body2D.AddForce(new Vector2(forceX, forceY)); // finally adding the velocity after keypress to the rigidbody object, in this case, the player

    }
}
