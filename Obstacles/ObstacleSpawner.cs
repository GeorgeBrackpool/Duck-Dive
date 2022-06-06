using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] ObstacleSpawnConfig currentWave;
    // Start is called before the first frame update
    void Start()
    {
        SpawnObstacles();
    }

    void SpawnObstacles()
    {
        for (int i = 0; i < currentWave.GetObstacleCount(); i++){
        Instantiate(currentWave.GetObstaclePrefab(i),
        transform.position,
        Quaternion.identity, transform);
        }
    }
}
