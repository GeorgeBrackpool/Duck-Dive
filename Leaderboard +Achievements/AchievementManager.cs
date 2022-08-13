using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CloudOnce;

public class AchievementManager : MonoBehaviour
{
    ScoreKeeper scoreKeeper;
    collectableCollision collectables;
    // Start is called before the first frame update
    void Start()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        collectables = FindObjectOfType<collectableCollision>();
    }

    // Update is called once per frame
    void Update()
    {
        AwardAchievement();
    }

    public void AwardAchievement()
    {
        if (scoreKeeper.score == 15 || scoreKeeper.score >= 15 && scoreKeeper.score < 25)// OR statement is to catch the instances where the player may pickup a bread or pea collectable which go over the score of 15 and will miss the achievement.
        {
            Debug.Log("Novice rewarded.");
            CloudOnceServices.instance.AwardNoviceDiver();
            
        }

        if (scoreKeeper.score == 30 || scoreKeeper.score >= 30 && scoreKeeper.score < 45)
        {
            Debug.Log("Intermediate rewarded.");
            CloudOnceServices.instance.AwardIntermediateDiver();
            
        }

        if (scoreKeeper.score == 50 || scoreKeeper.score >= 50 && scoreKeeper.score < 65)
        {
            Debug.Log("Adept rewarded.");
            CloudOnceServices.instance.AwardAdeptDiver();
            
        }

        if (scoreKeeper.score == 100 || scoreKeeper.score >= 100 && scoreKeeper.score < 120)
        {
            Debug.Log("Master rewarded.");
            CloudOnceServices.instance.AwardMasterDiver();
            
        }

         if (collectables.collectableCounter == 25)
        {
            Debug.Log("collectable 1 rewarded.");
            CloudOnceServices.instance.AwardQuackQuack();
        }
        if (collectables.collectableCounter == 50)
        {
            Debug.Log("collectable 2 rewarded.");
            CloudOnceServices.instance.AwardHonk();
        }
    }
}
