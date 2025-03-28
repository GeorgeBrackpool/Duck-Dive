using System.Collections;
using System.Collections.Generic;
using UnityEditor;
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
        
    //Skins 
    public SkinDatabase DefaultSkin;
    public SkinDatabase NoviceSkin;
    public SkinDatabase IntermediateSkin;
    public SkinDatabase AdeptSkin;
    public SkinDatabase MasterSkin;

    SelectSkin selectSkin;

    // Start is called before the first frame update
    void Start()
    {
       
       speedupScore = FindObjectOfType<SpeedupScore>();
       rb = GetComponent<Rigidbody2D>();
       col = GetComponent<BoxCollider2D>();
       shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<CameraShake>();
       audioSource = GetComponent<AudioSource>();

        CheckSkin();
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
    public void CheckSkin()
    {
        if(PlayerPrefs.GetInt("ChosenSkin") == 0)
        { 
          gameObject.GetComponent<SpriteRenderer>().sprite = DefaultSkin.PlayerSkin;
        }
        if(PlayerPrefs.GetInt("ChosenSkin") == 1)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = NoviceSkin.PlayerSkin;
        }
        if (PlayerPrefs.GetInt("ChosenSkin") == 2)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = IntermediateSkin.PlayerSkin;
        }
        if (PlayerPrefs.GetInt("ChosenSkin") == 3)
        {
           gameObject.GetComponent<SpriteRenderer>().sprite = AdeptSkin.PlayerSkin;
        }
        if (PlayerPrefs.GetInt("ChosenSkin") == 4)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = MasterSkin.PlayerSkin;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if(collision.gameObject.tag == "Obstacle")
        {
            DuckDestroyed();
        }
        else if(collision.gameObject.tag == "FlyingObstacle")
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
            
            
            
            
        }
        
    }
    void DestroyDuck()
    {
        Destroy(this.gameObject);
        LevelManager.LoadGameOver();
    }
}
