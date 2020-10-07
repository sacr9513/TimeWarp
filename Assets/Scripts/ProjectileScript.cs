using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    public float speed = 20f;
    GameObject target;
    private Rigidbody2D rb;
    private Vector2 fireDirection;
    public float deathtime;
    private Collider2D myCollider; 
    
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player");
        fireDirection = (target.transform.position-transform.position).normalized * speed;
        rb.velocity = new Vector2(fireDirection.x, fireDirection.y);
        Destroy(gameObject,deathtime);
        myCollider = GetComponent<Collider2D>();
        myCollider.enabled = false;

    }
    void Start()
    {
        StartCoroutine("Wait");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag =="Enemy")
            Destroy(this.gameObject);
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.1f);
        myCollider.enabled = true;

    }
   

    // Update is called once per frame
    void Update()
    {
        
    }
}
