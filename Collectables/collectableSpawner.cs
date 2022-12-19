using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectableSpawner : MonoBehaviour
{
    [SerializeField] public List<GameObject> collectablePrefabs;
    [SerializeField] float timeBetweenCollectableSpawns = 15f;
    [SerializeField] float spawnTimeVariance = 5f;
    [SerializeField] public float minimumSpawnTime = 10f;
    GameObject currentCollectable;
    [SerializeField] bool isLoopingWaves;
  

    void Start()
    {
       StartCoroutine(SpawnCollectables());
    }

     public int GetCollectableCount()
    {
        return collectablePrefabs.Count;
    }
     public float GetRandomSpawnTime(){
        float spawnTime = Random.Range(timeBetweenCollectableSpawns - spawnTimeVariance, 
        timeBetweenCollectableSpawns + spawnTimeVariance);
        return Mathf.Clamp(spawnTime, minimumSpawnTime, float.MaxValue);
    }

    public GameObject GetRandomCollectablePrefab(int index){
        index = Random.Range(0, collectablePrefabs.Count);
        currentCollectable = collectablePrefabs[index];
        return collectablePrefabs[index];
    }

    IEnumerator SpawnCollectables()
    {
        do{
        foreach(GameObject collectable in collectablePrefabs)
            {
            currentCollectable = collectable;
            for (int i = 0; i < GetCollectableCount(); i++)
            {
                Instantiate(GetRandomCollectablePrefab(i),
                transform.position,
                Quaternion.identity, transform);
                yield return new WaitForSeconds(GetRandomSpawnTime());
            }
        
            }
        }
        while(isLoopingWaves == true); 
    }
}
