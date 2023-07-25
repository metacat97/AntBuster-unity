using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float enemyHp = default;
    //private float enemyAtk = default;
    GameObject test;

    //EnemySpawner enemyspawner;
    
    // Start is called before the first frame update
    void Start()
    {
        enemyHp = 5.0f;
        test = GameObject.Find("EnemySpawnPoint");

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void DecreaseHp(float damage)
    {
        enemyHp -= damage;
    }

    public void DieEnemy()
    {
        Destroy(gameObject,0.3f);
        test.GetComponent<EnemySpawner>().DecreaseEnemy();
        Debug.Log(test.GetComponent<EnemySpawner>().enemyCount);

        //enemyspawner.DecreaseEnemy();
        //Debug.Log(enemyspawner.enemyCount);
    }

}
