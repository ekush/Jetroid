// to add velocity to the alien so that it moves to a certain direction

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float speed=10f; //speed of the alien object

    private Rigidbody2D _rigidbody2D; //reference to the object itself
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //using localscale to change the direction.
        _rigidbody2D.velocity = new Vector2(transform.localScale.x,0)*speed; //by default localscale is set to 1, if we change it to -1, then the alien will look to left
    }
}
