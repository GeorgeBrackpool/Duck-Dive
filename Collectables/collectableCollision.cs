using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectableCollision : MonoBehaviour
    {
    ScoreKeeper scoreKeeper;
    public int collectableCounter;
    private void Awake() {
       
       scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision != null && collision.gameObject.tag == "Player")
        {
            collectableCounter++;
            scoreKeeper.ModifyScore(+5);
            Destroy(gameObject);
        }
    }
}
