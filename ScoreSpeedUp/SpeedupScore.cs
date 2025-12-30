using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedupScore : MonoBehaviour
{
    GameMusic gameMusic;
     Duck duck;
     ScoreKeeper scoreKeeper;
     WaterSounds streamWaterSound;
     ObstacleSpawns obstacleSpawns;
    collectableSpawner collectableSpawns;
    BackgroundScroller backgroundScroller;
    [SerializeField] Animator waterAnimation;
    [SerializeField] public float obstacleSpeedIncrease = 0.1f;
     [SerializeField] public float collectableSpeedIncrease = 0.1f;
    [SerializeField] public float timeBetweenObstacleSpawns = 0.2f; // Increases the frequency of obstacle spawns by reducing "timeBetweenObstacleSpawns" in the ObstacleSpawns class.
    [SerializeField] float backgroundSpeedIncrease = 0.02f;
    [SerializeField] float newMusicSpeed = 0.05f;
    [SerializeField] float newWaterSoundSpeed = 0.05f;
    [SerializeField, Range(0.01f, 2f)] float waterAnimationSpeedIncrease = +0.2f;
    [SerializeField] float collectableSpawnTimeDelay = 0.2f; // Increases the minimum spawn time for a collectable. Currently at 10.
    [SerializeField] float duckHitStopSpeedUpDelay = 0.2f;// This is to add to the blank float in the Duck class so that when the score speeds up the time taken for the stop in the hitstop increases so it's not missed due to the other speeding up objects.
    [SerializeField] int targetScore = 20;
    private void Start() {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        obstacleSpawns = FindObjectOfType<ObstacleSpawns>();
        collectableSpawns = FindObjectOfType<collectableSpawner>();
        backgroundScroller = FindObjectOfType<BackgroundScroller>();
        gameMusic = FindObjectOfType<GameMusic>();
        streamWaterSound = FindObjectOfType<WaterSounds>();
        duck = FindObjectOfType<Duck>();
        
    }
   private void FixedUpdate() {
    if(scoreKeeper.score >= targetScore)
    {
        

        foreach(GameObject obstacle in obstacleSpawns.obstaclePrefabs)
            {    
                obstacle.GetComponent<ObstacleMover>().Speed += obstacleSpeedIncrease;//instead of referencing the script directly, Reference the Script as a component of the gameobject.
            }
        
        foreach(GameObject collectable in collectableSpawns.collectablePrefabs)
            {    
                collectable.GetComponent<ObstacleMover>().Speed += collectableSpeedIncrease;//instead of referencing the script directly, Reference the Script as a component of the gameobject.
            }
        obstacleSpawns.timeBetweenObstacleSpawns -= timeBetweenObstacleSpawns;
        collectableSpawns.minimumSpawnTime += collectableSpawnTimeDelay;
        waterAnimation.speed = waterAnimation.speed + waterAnimationSpeedIncrease;
        backgroundScroller.backgroundScrollSpeed += backgroundSpeedIncrease;
        gameMusic.pitch += newMusicSpeed;
        streamWaterSound.pitch += newWaterSoundSpeed;
        duck.hitStopSpeedUpDelay += duckHitStopSpeedUpDelay;
        targetScore = targetScore += 20;//increment target score so that when another x points is achieved game speeds up.
    }
     
   }

}
