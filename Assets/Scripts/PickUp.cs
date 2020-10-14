using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class PickUp : MonoBehaviour
{
    private Transform target;
    public int sightArea;
    
    // Start is called before the first frame update
    void Start()
    {    
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        GetComponent<SpriteRenderer>().enabled = false;
        
    }

   
    // Update is called once per frame
    void Update()
    {
        
        if (Vector2.Distance(transform.position, target.position) < sightArea)
        {
            GetComponent<SpriteRenderer>().enabled = true;
        }
    } 
    
    
}

