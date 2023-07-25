using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab; //�� ������ 
    public float enemyCount = 0f; //���� ������ ���� �� 
    [SerializeField] private float enemyTreshold = 6.0f; // �� �ִ� ���� �� 
    
    // �� ���� �ּ� �ִ� �ð�
    [SerializeField] private float spawnRateMin = 2.0f;
    [SerializeField] private float spawnRateMax = 5.0f;

    // �� ������Ʈ ���� �������Ʈ
    [SerializeField] private Transform enemyPool = default;

    // �� �����ֱ� 
    private float spawnRate;
    private float timeAfterSpawn;

    //[SerializeField] float spawnTime; //�� ���� �ֱ�


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
