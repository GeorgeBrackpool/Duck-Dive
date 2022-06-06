using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] List<ObstacleSpawnConfig> waveConfiguration;
    [SerializeField] float timeBetweenObstacleWaves = 0f;
    [SerializeField] bool isLoopingWaves;
    ObstacleSpawnConfig currentWave;
    // Start is called before the first frame update
    void Start()
    {
       StartCoroutine(SpawnObstacles());
    }

    public ObstacleSpawnConfig GetCurrentWave()
    {
        return currentWave;
    }
    IEnumerator SpawnObstacles()
    {
        do{
        foreach(ObstacleSpawnConfig wave in waveConfiguration)
            {
            currentWave = wave;
            //currentWave = Random.Range(0,waveConfiguration.Count);
            for (int i = 0; i < currentWave.GetObstacleCount(); i++)
            {
                Instantiate(currentWave.GetObstaclePrefab(i),
                transform.position,
                Quaternion.identity, transform);
                yield return new WaitForSeconds(currentWave.GetRandomSpawnTime());
            }
            yield return new WaitForSeconds(timeBetweenObstacleWaves);//TODO: randomise waves.
        
            }
        }
        while(isLoopingWaves == true); 
    }
}
