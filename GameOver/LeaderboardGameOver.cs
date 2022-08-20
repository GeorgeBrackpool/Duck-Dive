using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderboardGameOver : MonoBehaviour
{
    ScoreKeeper scoreKeeper;
    
    
    private void Awake() {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        CloudOnceServices.instance.SubmitScoreToLeaderboard(scoreKeeper.GetScore());
    }
    private void Start() {
       
    }
}
