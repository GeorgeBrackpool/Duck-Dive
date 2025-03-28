using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    static ScoreKeeper instance;
    public int score = 0;
    public int collectableCounter = 0;
    
    private void Awake() {
        ManageSingleton();
    }
    void ManageSingleton()
    {
        if(instance!=null){
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
   public int GetScore()
   {
    return score;
   }

   public void ModifyScore(int value)
   {
    score += value;
    Mathf.Clamp(score, 0, int.MaxValue);
    
   }

   public void ResetScore()
   {
    score = 0;
   }
   public void ResetCollectableCounter()
   {
    collectableCounter = 0;
   }

}
