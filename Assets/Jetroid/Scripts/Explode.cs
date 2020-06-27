// To detect if the player has collided with something deadly

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Explode : MonoBehaviour
{

    public Debris debris; // getting a reference to the debris
    public int totalDebris = 10; // total numbers of debris
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    // to check the collision trigger with a deadly object
    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.tag == "Deadly")
        {
            OnExplode();
        }
    }
    
    
    // to explode when deadly things are touched
    void OnExplode()
    {
        var t = transform; //a reference to the gameobject transform

        for (int i = 0; i < totalDebris; i++)
        {
            t.TransformPoint(0, -100, 0);
            var clone = Instantiate(debris, t.position, Quaternion.identity) as Debris; //creating a clone in the same position in the same orientation casting this as Debris to get the reference to the object
            var body2D = clone.GetComponent<Rigidbody2D>(); //getting rigidbody reference to the clones to apply a force to them
            body2D.AddForce(Vector3.right*Random.Range(-1000,1000));
            body2D.AddForce(Vector3.up*Random.Range(-500,2000));
        }
        
        Destroy(gameObject);
    }
}
