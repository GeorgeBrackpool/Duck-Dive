using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedupScore : MonoBehaviour
{
    GameMusic gameMusic;
     ScoreKeeper scoreKeeper;
     WaterSounds streamWaterSound;
     ObstacleMover obstacleMover;
     ObstacleSpawns obstacleSpawns;
    collectableSpawner collectableSpawns;
    BackgroundScroller backgroundScroller;
    [SerializeField] Animator waterAnimation;
    [SerializeField] public float obstacleSpeedIncrease = 0.1f;
     [SerializeField] public float collectableSpeedIncrease = 0.1f;
    [SerializeField] float backgroundSpeedIncrease = 0.02f;
    [SerializeField] float newMusicSpeed = 0.05f;
    [SerializeField] float newWaterSoundSpeed = 0.05f;
    [SerializeField, Range(0.01f, 2f)] float waterAnimationSpeedIncrease = +0.2f;
    [SerializeField] float collectableSpawnTimeDelay = 0.2f; // Increases the minimum spawn time for a collectable. Currently at 10.
    [SerializeField] int targetScore = 20;
    private void Start() {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        obstacleMover = FindObjectOfType<ObstacleMover>();
        obstacleSpawns = FindObjectOfType<ObstacleSpawns>();
        collectableSpawns = FindObjectOfType<collectableSpawner>();
        backgroundScroller = FindObjectOfType<BackgroundScroller>();
        gameMusic = FindObjectOfType<GameMusic>();
        streamWaterSound = FindObjectOfType<WaterSounds>();
        
    }
   private void FixedUpdate() {
    if(scoreKeeper.score >= targetScore)
    {
        //TODO: Speed up Music and Collectables along with reducing collectable spawn rate.

        foreach(GameObject obstacle in obstacleSpawns.obstaclePrefabs)
            {    
                obstacle.GetComponent<ObstacleMover>().Speed += obstacleSpeedIncrease;//instead of referencing the script directly, Reference the Script as a component of the gameobject.
            }
        
        foreach(GameObject collectable in collectableSpawns.collectablePrefabs)
            {    
                collectable.GetComponent<ObstacleMover>().Speed += collectableSpeedIncrease;//instead of referencing the script directly, Reference the Script as a component of the gameobject.
            }
        collectableSpawns.minimumSpawnTime += collectableSpawnTimeDelay;
        waterAnimation.speed = waterAnimation.speed + waterAnimationSpeedIncrease;
        backgroundScroller.backgroundScrollSpeed += backgroundSpeedIncrease;
        gameMusic.pitch += newMusicSpeed;
        streamWaterSound.pitch += newWaterSoundSpeed;

        //TODO: add the stream sounds to speed up too in it's new class. Should be waterSounds.pitch += newStreamSoundSpeed.
        
        targetScore = targetScore += 20;//increment target score so that when another x points is achieved game speeds up.
    }
     
   }

}