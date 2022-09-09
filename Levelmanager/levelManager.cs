using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;


public class levelManager : MonoBehaviour
{
    [SerializeField] float sceneLoadDelay = 2f;
    ScoreKeeper scoreKeeper;

  public void LoadStartMenu()
  {
      SceneManager.LoadScene(0);
  }
   
    public void LoadGame()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        if(scoreKeeper != null)
        {
            scoreKeeper.ResetScore();
            scoreKeeper.ResetCollectableCounter();
        }
        SceneManager.LoadScene("Game");
        Advertisement.Banner.Hide();
       
    }

    public void LoadGameOver()
    {
        StartCoroutine(WaitAndLoad("GameOver", sceneLoadDelay));
    }

    public void LoadHowToPlay()
    {
        SceneManager.LoadScene("HowToPlay");
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Advertisement.Banner.Hide();
    }
    public void LoadCredits()
    {
        SceneManager.LoadScene("Credits");
    }
    
    IEnumerator WaitAndLoad(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);

    }
}
