using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Duck : MonoBehaviour
{
        Rigidbody2D rb;
        BoxCollider2D col;
        bool playerdead;
        ScoreKeeper scoreKeeper;
        levelManager LevelManager;

        public int maxOxygen = 100;
        public int currentOxygen;
        
        

        
        
    // Start is called before the first frame update
    void Start()
    {
       rb = GetComponent<Rigidbody2D>();
       col = GetComponent<BoxCollider2D>();
       currentOxygen = maxOxygen;
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

        playerdead = true;
        LevelManager.LoadGameOver();
        if(gameObject != null){
            Destroy(this.gameObject);
        }
        
        //GameObject explosion = Instantiate(deathVFX, transform.position, transform.rotation);
        //Destroy(explosion, durationOfExplosion);
        //AudioSource.PlayClipAtPoint(deathSFX,Camera.main.transform.position, deathSFXVolume);
        //LevelLoading.FirstTime = false;
    }

   
}
