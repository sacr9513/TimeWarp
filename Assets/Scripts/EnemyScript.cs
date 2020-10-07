using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector2 = UnityEngine.Vector2;

public class EnemyScript : MonoBehaviour
{
    public float speed = 4f;

    private Transform target;
    
    private Rigidbody2D rb;

    public int bufferArea;

    public GameObject Flame;

    public float FireTime;

    public GameObject flameParent;

   
    
   
    
    
    // Start is called before the first frame update
    void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        InvokeRepeating("Fire", FireTime, FireTime);
        


    }

   

    private void Fire()
    {
        Instantiate(Flame, flameParent.transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, target.position) > bufferArea)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       
        if (collision.gameObject.tag == "Projectile")
        {
            Destroy(this.gameObject);
        }
    }

    

}

