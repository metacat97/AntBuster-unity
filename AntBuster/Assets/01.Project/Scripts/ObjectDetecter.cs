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
        // "MainCamera" 태그를 가지고 있는 오브젝트 탐색 후 Camera 컴포넌트 정보 전달
        // // GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>(); 와 동일
        mainCamera = Camera.main;

    }

    private void Update()
    {
        // 마우스 왼쪽 버튼을 눌렀을 때
        if ( Input.GetMouseButtonDown(0)) 
        {
            ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            if( Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                //광선에 부딪힌 오브젝트의 태그가 Tile이면 
                if (hit.transform.CompareTag("Tile"))
                {
                    towerSpawner.SpawnTower(hit.transform);
                }
            }

        }
    }

}
