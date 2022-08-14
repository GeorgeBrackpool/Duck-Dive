using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class GameOverUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    ScoreKeeper scoreKeeper;
    
    private void Update() {
        if(scoreKeeper.GetScore() > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", scoreKeeper.GetScore());
        }
       
    }
    void Start()
    {
       scoreKeeper = FindObjectOfType<ScoreKeeper>();   
        scoreText.text = scoreKeeper.GetScore().ToString();
    }

 
}
