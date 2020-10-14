using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeMachine : MonoBehaviour
{
    public static bool isCollision = false;

    private void Start()
    {
        isCollision = false;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player") ;
        {
            isCollision = true;
        }
        if (collision.gameObject.tag == "Projectile")
        {
                isCollision = false;
        }
        


    }

   
}


    
    
        
    

