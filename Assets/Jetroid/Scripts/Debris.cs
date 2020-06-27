using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debris : MonoBehaviour
{


    private SpriteRenderer _renderer;   //getting a reference to the sprite renderer
    //two clors to change the alpha transparency of the sprites
    private Color _startColor;
    private Color _endColor;
    private float t = 0f; //this is for time
    
    // Start is called before the first frame update
    void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _startColor = _renderer.color;
        _endColor = new Color(_startColor.r, _startColor.g, _startColor.b, 0f);  // getting the same start color with a different alpha
    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;
        _renderer.material.color = Color.Lerp(_startColor, _endColor, t / 2); // this allows to change the color over time **Lerp - changes the value over time

        if (_renderer.material.color.a <=0f) //checking the alpha value and make the debris destroy 
        {
            Destroy(gameObject);
        }
    }
}
