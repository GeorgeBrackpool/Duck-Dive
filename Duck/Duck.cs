using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Duck : MonoBehaviour
{
        Rigidbody2D rb;
        BoxCollider2D col;
        bool playerdead;
    // Start is called before the first frame update
    void Start()
    {
       rb = GetComponent<Rigidbody2D> ();
        col = GetComponent<BoxCollider2D> ();
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

    void DuckDestroyed()
    {
        playerdead = true;
        //FindObjectOfType<LevelLoading>().LoadGameOver();
        Destroy(this.gameObject);
        //GameObject explosion = Instantiate(deathVFX, transform.position, transform.rotation);
        //Destroy(explosion, durationOfExplosion);
        //AudioSource.PlayClipAtPoint(deathSFX,Camera.main.transform.position, deathSFXVolume);
        //LevelLoading.FirstTime = false;
    }

}
