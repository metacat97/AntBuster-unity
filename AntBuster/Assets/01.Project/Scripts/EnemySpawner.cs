using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab; //적 프리팹 
    public float enemyCount = 0f; //현재 생성된 적의 수 
    [SerializeField] private float enemyTreshold = 6.0f; // 적 최대 생성 수 
    
    // 적 생성 최소 최대 시간
    [SerializeField] private float spawnRateMin = 2.0f;
    [SerializeField] private float spawnRateMax = 5.0f;

    // 적 오브젝트 담을 빈오브젝트
    [SerializeField] private Transform enemyPool = default;

    // 적 생성주기 
    private float spawnRate;
    private float timeAfterSpawn;

    //[SerializeField] float spawnTime; //적 생성 주기


    private void Awake()
    {
        //InvokeRepeating("SpawnEnemy", 2.0f, 5.0f*Time.deltaTime);
        timeAfterSpawn = 0f;
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        //spawnRate = 3.0f;
        Debug.Log(timeAfterSpawn);
        //Debug.Log(spawnRate);

    }

    void Update()
    {
            timeAfterSpawn += Time.deltaTime;
        if (enemyCount < enemyTreshold)
        {
            if (timeAfterSpawn >= spawnRate)
            {
                timeAfterSpawn = 0f;

                enemyCount += 1.0f;
                Instantiate(enemyPrefab,
                    transform.position, transform.rotation, enemyPool);



                spawnRate = Random.Range(spawnRateMin, spawnRateMax);
            }
            //Instantiate(enemyPrefab,
            //        transform.position, transform.rotation, enemyPool);
        }
        else if( enemyCount >= enemyTreshold) 
        { /*Do nothing*/ }
        
        //timeAfterSpawn += Time.deltaTime;

        //if (timeAfterSpawn >= spawnRate)
        //{
        //    timeAfterSpawn = 0f;

        //    Instantiate(enemyPrefab,
        //        transform.position, transform.rotation, enemyPool);



        //    spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        //}
    }

    public void DecreaseEnemy()
    {
        enemyCount -= 1.0f;
    }

    //private void FixedUpdate()
    //{
    //    if (enemyCount >= enemyTreshold)
    //    {
    //        CancelInvoke();
    //    }
    //    else if(enemyCount <)
    //}
    //private void SpawnEnemy()
    //{
    //    enemyCount +=1;
    //    GameObject clone = Instantiate(enemyPrefab);


    //}

}
