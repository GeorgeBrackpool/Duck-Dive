using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Duck : MonoBehaviour
{
        Rigidbody2D rb;
        BoxCollider2D col;
        ScoreKeeper scoreKeeper;
        levelManager LevelManager;
        private CameraShake shake;
        
        
    // Start is called before the first frame update
    void Start()
    {
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
            FindObjectOfType<HitStop>().Stop(.2f);
            Destroy(this.gameObject);
            shake.CamShake();
            
            
        }
        LevelManager.LoadGameOver();
    }
    
    
}
