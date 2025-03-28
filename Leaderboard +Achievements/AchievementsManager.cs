using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AchievementsManager : MonoBehaviour
{
    ScoreKeeper scoreKeeper;
    collectableCollision collectables;
    //Bools to stop calling the checks during update
    public bool noviceUnlocked;
    public bool intermediateUnlocked;
    public bool adeptUnlocked;
    public bool masterUnlocked;
    //Bools for non score related achievements.
    bool quackUnlocked;//These two aren't affected by the Skinmanager script so don't need to be public.
    bool honkUnlocked;

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
        if (scoreKeeper.score >= 15 && scoreKeeper.score < 19)
        {
            if (!noviceUnlocked)
            {
                noviceUnlocked = true;
                PlayerPrefs.SetInt("NoviceBool", Convert.ToInt32(noviceUnlocked));
                //Debug.Log("Novice Unlocked");
                CloudOnceServices.instance.AwardNoviceDiver();
            }
        }

        if (scoreKeeper.score >= 30 && scoreKeeper.score < 39)
        {
            if (!intermediateUnlocked)
            {
                intermediateUnlocked = true;
                PlayerPrefs.SetInt("IntermediateBool", Convert.ToInt32(intermediateUnlocked));
                //Debug.Log("Intermediate Unlocked");
                CloudOnceServices.instance.AwardIntermediateDiver();
            }

            // Ensure Novice is also unlocked
            if (!noviceUnlocked)
            {
                noviceUnlocked = true;
                PlayerPrefs.SetInt("NoviceBool", Convert.ToInt32(noviceUnlocked));
                //Debug.Log("Novice Unlocked (via Intermediate)");
                CloudOnceServices.instance.AwardNoviceDiver();
            }
        }

        if (scoreKeeper.score >= 50 && scoreKeeper.score < 59)
        {
            if (!adeptUnlocked)
            {
                adeptUnlocked = true;
                PlayerPrefs.SetInt("AdeptBool", Convert.ToInt32(adeptUnlocked));
                //Debug.Log("Adept Unlocked");
                CloudOnceServices.instance.AwardAdeptDiver();
            }

            // Ensure Intermediate and Novice are also unlocked
            if (!intermediateUnlocked)
            {
                intermediateUnlocked = true;
                PlayerPrefs.SetInt("IntermediateBool", Convert.ToInt32(intermediateUnlocked));
                //Debug.Log("Intermediate Unlocked (via Adept)");
                CloudOnceServices.instance.AwardIntermediateDiver();
            }

            if (!noviceUnlocked)
            {
                noviceUnlocked = true;
                PlayerPrefs.SetInt("NoviceBool", Convert.ToInt32(noviceUnlocked));
                //Debug.Log("Novice Unlocked (via Adept)");
                CloudOnceServices.instance.AwardNoviceDiver();
            }
        }

        if (scoreKeeper.score >= 100 && scoreKeeper.score < 109)
        {
            if (!masterUnlocked)
            {
                masterUnlocked = true;
                PlayerPrefs.SetInt("MasterBool", Convert.ToInt32(masterUnlocked));
                //Debug.Log("Master Unlocked");
                CloudOnceServices.instance.AwardMasterDiver();
            }

            // Ensure Adept, Intermediate, and Novice are also unlocked
            if (!adeptUnlocked)
            {
                adeptUnlocked = true;
                PlayerPrefs.SetInt("AdeptBool", Convert.ToInt32(adeptUnlocked));
                //Debug.Log("Adept Unlocked (via Master)");
                CloudOnceServices.instance.AwardAdeptDiver();
            }

            if (!intermediateUnlocked)
            {
                intermediateUnlocked = true;
                PlayerPrefs.SetInt("IntermediateBool", Convert.ToInt32(intermediateUnlocked));
                //Debug.Log("Intermediate Unlocked (via Master)");
                CloudOnceServices.instance.AwardIntermediateDiver();
            }

            if (!noviceUnlocked)
            {
                noviceUnlocked = true;
                PlayerPrefs.SetInt("NoviceBool", Convert.ToInt32(noviceUnlocked));
                //Debug.Log("Novice Unlocked (via Master)");
                CloudOnceServices.instance.AwardNoviceDiver();
            }
        }

        if (scoreKeeper.collectableCounter == 25)
        {
            if (!quackUnlocked)
            {
                quackUnlocked = true;
                //Debug.Log("Quack Unlocked");
                CloudOnceServices.instance.AwardQuackQuack();
            }
        }

        if (scoreKeeper.collectableCounter == 50)
        {
            if (!honkUnlocked)
            {
                honkUnlocked = true;
                //Debug.Log("Honk Unlocked");
                CloudOnceServices.instance.AwardHonk();
            }
        }
    }
}
