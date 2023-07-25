using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float speed = default;
    private Rigidbody bulletRigidbody = default;
    //private EnemySpawner enemyspawner;

    // Start is called before the first frame update
    void Start()
    {
        bulletRigidbody = GetComponent<Rigidbody>();
        bulletRigidbody.velocity = transform.forward * speed;
        Destroy(gameObject, 3f);
       
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            Destroy(gameObject, 0f);
            Debug.Log("√—æÀ¿Ã ∏∏≥µ¿Ω");

            Enemy enemy = other.GetComponent<Enemy>();
            
            Debug.Log(enemy.enemyHp);

            if (enemy.enemyHp != 0) 
            {
                enemy.DecreaseHp(2.0f);
                Debug.Log(enemy.enemyHp);
                if (enemy.enemyHp <= 0f)
                {
                    Debug.Log("¡◊¥¬∞≈ Ω««‡");

                    enemy.DieEnemy();
                    //enemyspawner.DecreaseEnemy();

                }
            }
            
            
        }
    }
    // Update is called once per frame
    void Update()
    {
    }
}
