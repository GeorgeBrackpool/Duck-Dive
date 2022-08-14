using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AchievementsManager : MonoBehaviour
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
        if (scoreKeeper.score == 15 || scoreKeeper.score > 15 && scoreKeeper.score < 19)// OR statement is to catch the instances where the player may pickup a bread or pea collectable which go over the score of 15 and will miss the achievement.
        {
            
            CloudOnceServices.instance.AwardNoviceDiver();
        }

        if (scoreKeeper.score == 30 || scoreKeeper.score > 30 && scoreKeeper.score < 39)
        {
            
            CloudOnceServices.instance.AwardIntermediateDiver();
            
        }

        if (scoreKeeper.score == 50 || scoreKeeper.score > 50 && scoreKeeper.score < 59)
        {
            
            CloudOnceServices.instance.AwardAdeptDiver();
            
        }

        if (scoreKeeper.score == 100 || scoreKeeper.score > 100 && scoreKeeper.score < 109)
        {
            
            CloudOnceServices.instance.AwardMasterDiver();
            
        }

         if (scoreKeeper.collectableCounter == 25)
        {
            
            CloudOnceServices.instance.AwardQuackQuack();
        }
        if (scoreKeeper.collectableCounter == 50)
        {
            
            CloudOnceServices.instance.AwardHonk();
        }
    }
}
