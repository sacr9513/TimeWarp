using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {
    private float     xPos;
    private float yPos;
    public float      speed = .025f;
    public float leftWall, rightWall, topWall, bottomWall;
    public KeyCode fireKey;
    private Rigidbody2D rb;
    
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKey(KeyCode.LeftArrow)) {

            if (xPos > leftWall)
            {
                xPos -= speed;
            }
        }

        if (Input.GetKey(KeyCode.RightArrow)) {
            if (xPos < rightWall)
            {
                xPos += speed;
            }
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (yPos < bottomWall)
            {
                yPos += speed;
            }
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            if (yPos > topWall)
            {
                yPos -= speed;
            }
        }

     
      
        rb.MovePosition(new Vector3(xPos, yPos, 0));
    }

}
