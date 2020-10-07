using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
            Destroy(this.gameObject);
        Debug.Log("You found an artifact!");
    }
    // Update is called once per frame
    private void Update()
    {
        if (Vector2.Distance(transform.position, target.position) < sightArea)
        {
            GetComponent<SpriteRenderer>().enabled = true;
        }
    }
}

