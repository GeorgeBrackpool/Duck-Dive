using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawns : MonoBehaviour
{
    [SerializeField] List<GameObject> obstaclePrefabs;
    [SerializeField] float timeBetweenObstacleSpawns = 2f;
    [SerializeField] float spawnTimeVariance;
    [SerializeField] float minimumSpawnTime = 0.2f;
    GameObject currentObstacle;
    [SerializeField] bool isLoopingWaves;
  

    void Start()
    {
       StartCoroutine(SpawnObstacles());
    }

     public int GetObstacleCount()
    {
        return obstaclePrefabs.Count;
    }
     public float GetRandomSpawnTime(){
        float spawnTime = Random.Range(timeBetweenObstacleSpawns - spawnTimeVariance, 
        timeBetweenObstacleSpawns + spawnTimeVariance);
        return Mathf.Clamp(spawnTime, minimumSpawnTime, float.MaxValue);
    }

    public GameObject GetRandomObstaclePrefab(int index){
        index = Random.Range(0, obstaclePrefabs.Count);
        currentObstacle = obstaclePrefabs[index];
        return obstaclePrefabs[index];
    }

    IEnumerator SpawnObstacles()
    {
        do{
        foreach(GameObject obstacle in obstaclePrefabs)
            {
            currentObstacle = obstacle;
            for (int i = 0; i < GetObstacleCount(); i++)
            {
                Instantiate(GetRandomObstaclePrefab(i),
                transform.position,
                Quaternion.identity, transform);
                yield return new WaitForSeconds(GetRandomSpawnTime());
            }
        
            }
        }
        while(isLoopingWaves == true); 
    }
}

