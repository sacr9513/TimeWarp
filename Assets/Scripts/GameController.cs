using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject Dino;

    public float SpawnTime = 15f;

    public GameObject SpawnPoint;

    public int MaxEnemies = 3;
    
    public int CurrentEnemyCount = 0;

    public GameObject pickUp; 
    
    

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", SpawnTime, SpawnTime);
        Vector2 pos = new Vector2(Random.Range(-5,5), Random.Range(-4,2));
        Instantiate(pickUp, pos, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {

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

}
