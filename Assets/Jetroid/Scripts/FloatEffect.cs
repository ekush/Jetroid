﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatEffect : MonoBehaviour
{

    private float startY = 0f;
    private float duration = 1f;
    private RectTransform _rectTransform; //UI elements use recttransform
    
    // Start is called before the first frame update
    void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
        startY = _rectTransform.anchoredPosition.y;
    }

    // Update is called once per frame
    void Update()
    {
        var newY = startY + (startY + Mathf.Cos(Time.time / duration * 2)) / .1f;
        _rectTransform.anchoredPosition=new Vector2(_rectTransform.anchoredPosition.x, newY);
    }
}
