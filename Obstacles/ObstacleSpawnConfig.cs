using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "ObstacleSpawningConfiguration", menuName = "Duck Dive/ObstacleSpawnConfiguration", order = 0)]
public class ObstacleSpawnConfig : ScriptableObject 
{
    [SerializeField] List<GameObject> obstaclePrefabs;
    [SerializeField] float timeBetweenObstacleSpawns = 2f;
    [SerializeField] float spawnTimeVariance;
    [SerializeField] float minimumSpawnTime = 0.2f;
    public int GetObstacleCount()
    {
        return obstaclePrefabs.Count;
    }

    public GameObject GetObstaclePrefab(int index){
        return obstaclePrefabs[index];
    }

    public float GetRandomSpawnTime(){
        float spawnTime = Random.Range(timeBetweenObstacleSpawns - spawnTimeVariance, 
        timeBetweenObstacleSpawns + spawnTimeVariance);
        return Mathf.Clamp(spawnTime, minimumSpawnTime, float.MaxValue);
    }
}

