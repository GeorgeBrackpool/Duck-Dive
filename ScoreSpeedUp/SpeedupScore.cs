using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedupScore : MonoBehaviour
{
     ScoreKeeper scoreKeeper;
    [SerializeField]ObstacleMover obstacleMover;
     ObstacleSpawns obstacleSpawns;

    BackgroundScroller backgroundScroller;
    [SerializeField] Animator waterAnimation;
    [SerializeField] public float obstacleSpeedIncrease = 0.1f;
    [SerializeField] float backgroundSpeedIncrease = 0.02f;
    [SerializeField, Range(0.01f, 2f)] float waterAnimationSpeedIncrease = 0.2f;
    [SerializeField] int targetScore = 20;
    private void Start() {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        obstacleMover = FindObjectOfType<ObstacleMover>();
        obstacleSpawns = FindObjectOfType<ObstacleSpawns>();
        backgroundScroller = FindObjectOfType<BackgroundScroller>();
        
    }
   private void FixedUpdate() {
    if(scoreKeeper.score >= targetScore)
    {
        //TODO: Speed up Music and Collectables along with reducing collectable spawn rate.

        foreach(GameObject obstacle in obstacleSpawns.obstaclePrefabs)
            {    
                obstacle.GetComponent<ObstacleMover>().Speed += obstacleSpeedIncrease;//instead of referencing the script directly, Reference the Script as a component of the gameobject.
            }
        // need to check how this affects collectable obstacles as their speed is set to 3 whereas obstacle speed is set to 5.
        waterAnimation.SetFloat("speedMultiplier", +waterAnimationSpeedIncrease);//need to multiply.
        backgroundScroller.GetComponent<BackgroundScroller>().backgroundScrollSpeed += backgroundSpeedIncrease;
        targetScore = targetScore += 20;//increment target score so that when another x points is achieved game speeds up.
    }
     
   }

}
