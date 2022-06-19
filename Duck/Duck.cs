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
        public OxygenMeter oxygenMeter;

        bool isUnderwater = false;
        [SerializeField] int oxygenDecreaseRate = 5;
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
        oxygenMeter.SetMaxOxygen(maxOxygen);
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
        while(collision.gameObject.tag == "Underwater")
        {
            reduceOxygen(oxygenDecreaseRate);
        }
    }

    void DuckDestroyed()
    {

        playerdead = true;
        LevelManager.LoadGameOver();
        Destroy(this.gameObject);
        //GameObject explosion = Instantiate(deathVFX, transform.position, transform.rotation);
        //Destroy(explosion, durationOfExplosion);
        //AudioSource.PlayClipAtPoint(deathSFX,Camera.main.transform.position, deathSFXVolume);
        //LevelLoading.FirstTime = false;
    }

    void reduceOxygen(int damage)
    {
        if(currentOxygen !< 0)
        {
            currentOxygen -= damage;
            oxygenMeter.SetOxygen(currentOxygen);
        }
        if(currentOxygen <= 0)
        {
            currentOxygen = 0;
            DuckDestroyed();
        }
    }
}
