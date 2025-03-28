using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shredder : MonoBehaviour
{
     private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.tag == "Obstacle")
        {
            Destroy(collision.transform.parent.gameObject);
        }
        else if(collision.gameObject.tag == "Collectable")
        {
            Destroy(collision.gameObject);
        }
        else if(collision.gameObject.tag == "FlyingObstacle")
        {
            Destroy(collision.gameObject);
        }
            
    }
}
