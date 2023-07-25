using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float spawnRateMin = 0.5f;
    public float spawnRateMax = 3f;

    //public Transform bulletPool = default;
    private Transform target;
    private float spawnRate;
    private float timeAfterSpawn;
    // Start is called before the first frame update
    void Start()
    {
        timeAfterSpawn = 0f;
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);
    }

    // Update is called once per frame
    void Update()
    {
        timeAfterSpawn += Time.deltaTime;
        //target = FindObjectOfType<Enemy>().transform;

    }


    private void OnTriggerStay(Collider other)
    {
            target = FindObjectOfType<Enemy>().transform;

        
        if (other.tag == "Enemy")
        {
            this.transform.LookAt(target);

            if (timeAfterSpawn >= spawnRate)
            {
                timeAfterSpawn = 0f;

                GameObject bullet = Instantiate(bulletPrefab,
                    transform.position, transform.rotation);//, bulletPool);
                bullet.transform.LookAt(target);
                this.transform.LookAt(target);


                spawnRate = Random.Range(spawnRateMin, spawnRateMax);
            }
        }

    }
}
