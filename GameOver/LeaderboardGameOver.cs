using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderboardGameOver : MonoBehaviour
{
    ScoreKeeper scoreKeeper;
    
    
    private void Awake() {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
       
    }
    private void Start()
    {
        //CloudOnceServices.instance.SubmitScoreToLeaderboard(scoreKeeper.GetScore());
    }
}
