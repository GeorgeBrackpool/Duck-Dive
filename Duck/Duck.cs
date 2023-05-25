using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Duck : MonoBehaviour
{
        Rigidbody2D rb;
        BoxCollider2D col;
        SpeedupScore speedupScore;
        ScoreKeeper scoreKeeper;
        levelManager LevelManager;
        private CameraShake shake;
        AudioSource audioSource;
        float originalHitStopTime = 0.5f;
        public float hitStopSpeedUpDelay;
        
        
        
    // Start is called before the first frame update
    void Start()
    {
       speedupScore = FindObjectOfType<SpeedupScore>();
       rb = GetComponent<Rigidbody2D>();
       col = GetComponent<BoxCollider2D>();
       shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<CameraShake>();
    }
    private void Awake() 
    {
        LevelManager = FindObjectOfType<levelManager>();
        scoreKeeper = GetComponent<ScoreKeeper>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
      
    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if(collision.gameObject.tag == "Obstacle")
        {
            DuckDestroyed();
        }
       
    }
    public void DuckDestroyed()
    {
        
        if(gameObject != null){ 
            hitStopSpeedUpDelay = originalHitStopTime + hitStopSpeedUpDelay;
            FindObjectOfType<HitStop>().Stop(hitStopSpeedUpDelay);
            shake.CamShake();
            GameObject.FindWithTag("HitStop").GetComponent<AudioSource>().PlayDelayed(0.8f);
            DestroyDuck();
            //TODO: Check co routine hitstop as its broken.
            
            
            
        }
        
    }
    void DestroyDuck()
    {
        Destroy(gameObject);
        LevelManager.LoadGameOver();
        
       
    }
}
