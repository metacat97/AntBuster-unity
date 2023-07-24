using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSpawner : MonoBehaviour
{
    [SerializeField] private GameObject towerPrefab;

    public void SpawnTower(Transform tileTransform)
    {
        Instantiate(towerPrefab, tileTransform.position, Quaternion.identity);
    }
}
