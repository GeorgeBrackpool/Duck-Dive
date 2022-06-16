using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddScore : MonoBehaviour
{
    ScoreKeeper scoreKeeper;

    private void Awake() {
     scoreKeeper = FindObjectOfType<ScoreKeeper>();   
    }
    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision != null && collision.gameObject.tag == "Player")
        {
            scoreKeeper.ModifyScore(+1);
        }
    }
}
