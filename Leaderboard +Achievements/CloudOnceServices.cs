using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CloudOnce;
using GooglePlayGames.BasicApi;

public class CloudOnceServices : MonoBehaviour
{
    public static CloudOnceServices instance;
    ScoreKeeper scoreKeeper;
    private void Awake()
    {
        TestSingleton();

    }
    private void Start()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }
    private void TestSingleton()
    {
        if (instance != null) { Destroy(gameObject); return; }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void SubmitScoreToLeaderboard(int score)
    {
        Leaderboards.highScore.SubmitScore(score);
    }
    public void AwardNoviceDiver()
    {
        if (Achievements.noviceDiver.IsUnlocked) { return; }
        Achievements.noviceDiver.Unlock();

    }

    public void AwardIntermediateDiver()
    {
        if (Achievements.intermediateDiver.IsUnlocked) { return; }
        Achievements.intermediateDiver.Unlock();
    }
    public void AwardAdeptDiver()
    {
        if (Achievements.adeptDiver.IsUnlocked) { return; }
        Achievements.adeptDiver.Unlock();
    }
    public void AwardMasterDiver()
    {
        if (Achievements.masterDiver.IsUnlocked) { return; }
        Achievements.masterDiver.Unlock();
    }
    public void AwardQuackQuack()
    {
        if (Achievements.quackQuack.IsUnlocked) { return; }
        Achievements.quackQuack.Unlock();
    }

    public void AwardHonk()
    {
        if (Achievements.Honk.IsUnlocked) { return; }
        Achievements.Honk.Unlock();
    }
}
