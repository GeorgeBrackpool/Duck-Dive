using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    ScoreKeeper scoreKeeper;

    private void Awake() {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        CloudOnceServices.instance.SubmitScoreToLeaderboard(scoreKeeper.GetScore());
    }
    
    private void Update() {
        if(scoreKeeper.GetScore() > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", scoreKeeper.GetScore());
        }
    }
    void Start()
    {
        scoreText.text = scoreKeeper.GetScore().ToString();
        
    }

 
}
