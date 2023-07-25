using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindNearObj : MonoBehaviour
{
    public List<GameObject> FoundObjects;
    public GameObject enemy;
    public string TagName;
    public float shortDis;


    void Start()
    {
        FoundObjects = new List<GameObject>(GameObject.FindGameObjectsWithTag(TagName));
        shortDis = Vector3.Distance(gameObject.transform.position, FoundObjects[0].transform.position); // ù��°�� �������� ����ֱ� 

        enemy = FoundObjects[0]; // ù��°�� ���� 

        foreach (GameObject found in FoundObjects)
        {
            float Distance = Vector3.Distance(gameObject.transform.position, found.transform.position);

            if (Distance < shortDis) // ������ ���� �������� �Ÿ� ���
            {
                enemy = found;
                shortDis = Distance;
            }
        }
        Debug.Log(enemy.name);

    }

    void Update()
    {
        shortDis = Vector3.Distance(gameObject.transform.position, FoundObjects[0].transform.position); // ù��°�� �������� ����ֱ� 

        enemy = FoundObjects[0]; // ù��°�� ���� 

        foreach (GameObject found in FoundObjects)
        {
            float Distance = Vector3.Distance(gameObject.transform.position, found.transform.position);

            if (Distance < shortDis) // ������ ���� �������� �Ÿ� ���
            {
                enemy = found;
                shortDis = Distance;
            }
        }
        Debug.Log(enemy.name);
    }

    private void OnTriggerStay(Collider other)
    {
    }
}
