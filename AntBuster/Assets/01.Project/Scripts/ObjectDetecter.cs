using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDetecter : MonoBehaviour
{

    [SerializeField]
    private TowerSpawner towerSpawner;

    private Camera mainCamera;
    private Ray ray;
    private RaycastHit hit;

    private void Awake()
    {
        // "MainCamera" �±׸� ������ �ִ� ������Ʈ Ž�� �� Camera ������Ʈ ���� ����
        // // GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>(); �� ����
        mainCamera = Camera.main;

    }

    private void Update()
    {
        // ���콺 ���� ��ư�� ������ ��
        if ( Input.GetMouseButtonDown(0)) 
        {
            ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            if( Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                //������ �ε��� ������Ʈ�� �±װ� Tile�̸� 
                if (hit.transform.CompareTag("Tile"))
                {
                    towerSpawner.SpawnTower(hit.transform);
                }
            }

        }
    }

}
