using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawns : MonoBehaviour
{
    [SerializeField] public List<GameObject> obstaclePrefabs;
    [SerializeField] float timeBetweenObstacleSpawns = 2f;
    [SerializeField] [Tooltip("Takes the number and randomly subtracts or adds the number to the time between obstacles.")] float spawnTimeVariance;
    [SerializeField] [Tooltip("Minimum spawn time allowed between obstacles so the variance doesn't go into a negative number.")] float minimumSpawnTime = 0.2f;
    public GameObject currentObstacle;
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

