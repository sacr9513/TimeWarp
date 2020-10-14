using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    private float xPos;
    private float yPos;
    public float speed = .025f;
    public float leftWall, rightWall, topWall, bottomWall;
    public KeyCode fireKey;
    private Rigidbody2D rb;
    public static int scoreNumber = 0;
    public Text score;
    public Image healthBar;
    public float health = 1f;
    public Image fuelBar;
    public float fuel = 0f;
    public string SampleScene;
    public string Level2;
    public int objectsTouched = 0;
    public Image Fuzz;
    public static bool warpStarted = false;










    // Start is called before the first frame update
    void Start()
    {

        warpStarted = false;
        rb = GetComponent<Rigidbody2D>();
        healthBar.fillAmount = health;
        fuelBar.fillAmount = fuel;
        var tempColor = Fuzz.color;
        tempColor.a = 0f;
        Fuzz.color = tempColor;
        TimeMachine.isCollision = false;

    }

    // Update is called once per frame

    void Update()
    {
        Scene scene = SceneManager.GetActiveScene();
        score.text = "Score:" + scoreNumber;
        if (objectsTouched == 4 && warpStarted==false)
        {
            StartCoroutine(Warp());
            
        }

        if (health <= 0)
        {
            Die();
        }

        if (fuel == 1 && scene.name == SampleScene && TimeMachine.isCollision == true)
        {
            ResetCollision();
            LevelTwo();
            
        }

        if (fuel == 1 && scene.name == Level2 && TimeMachine.isCollision == true)
        {
            Die();
            


        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {

            if (xPos > leftWall)
            {
                xPos -= speed;
            }

        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
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


    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "pickup")
        {
            scoreNumber += 1000;
            Destroy(collision.gameObject);


        }

        if (collision.gameObject.tag == "Enemy")
        {
            health -= .25f;
            healthBar.fillAmount = health;
        }

        if (collision.gameObject.tag == "Fuel")
        {
            fuel += .2f;
            fuelBar.fillAmount = fuel;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "Fuel")
        {
            objectsTouched += 1;
        }
    }

    void Die()
    {
        SceneManager.LoadScene("GameOver");
    }

    void LevelTwo()
    {

        SceneManager.LoadScene("Level2");

    }

    void ResetCollision()
    {
        TimeMachine.isCollision = false;
    }

    IEnumerator Warp()
    {
        
        var tempColor = Fuzz.color;
        tempColor.a = 1f;
        Fuzz.color = tempColor;
        yield return new WaitForSeconds(0.2f);
        tempColor.a = 0f;
        Fuzz.color = tempColor;
        yield return new WaitForSeconds(0.2f);
        warpStarted = true;
        
    }

}

    
        



