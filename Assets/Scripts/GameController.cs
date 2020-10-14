using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameController : MonoBehaviour
{
    public GameObject Dino;

    public float SpawnTime = 8f;

    public GameObject SpawnPoint;

    public int MaxEnemies = 3;

    public int CurrentEnemyCount = 0;

    public GameObject pickUp;

    public PlayerScript compareScript;

    public GameObject SecondaryEnemy;

    public bool SecondEnemySpawn = true;













    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", SpawnTime, SpawnTime);
        Vector2 pos = new Vector2(Random.Range(-5, 5), Random.Range(-4, 2));
        Instantiate(pickUp, pos, Quaternion.identity);
        SecondEnemySpawn = true;

    }


    // Update is called once per frame
    void Update()
    {
        if (PlayerScript.warpStarted == true && SecondEnemySpawn == true)
        {
            Instantiate(SecondaryEnemy, SpawnPoint.transform.position, Quaternion.identity);
            StartCoroutine("Waiting");

        }

    }

    private void Spawn()

    {
        if (CurrentEnemyCount < MaxEnemies)
        {
            Instantiate(Dino, SpawnPoint.transform.position, Quaternion.identity);
            CurrentEnemyCount += 1;
            if (CurrentEnemyCount == MaxEnemies)
            {
                CurrentEnemyCount -= 3;
            }

        }
    }

    IEnumerator Waiting()
    {
        SecondEnemySpawn = false;
        yield return new WaitForSeconds(30f);
        SecondEnemySpawn = true;
    }


}

    
   
    
    

   


