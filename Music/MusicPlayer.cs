using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        SetUpSingleton();
    }
    private void SetUpSingleton()
    {
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
        else 
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        Scene m_scene;//This code destroys the music player object to play the new music for those scenes. If I add more levels some kind of array would be better for every few levels or so.

        m_scene = SceneManager.GetActiveScene();

        if (m_scene.name == "Game" )
        {
            
            Destroy(gameObject);

        }
        if (m_scene.name == "GameOver")
        {
            Destroy(gameObject);
        }
    }
}
