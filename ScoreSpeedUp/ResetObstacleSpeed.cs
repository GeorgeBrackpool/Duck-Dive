using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetObstacleSpeed : MonoBehaviour
{
    /* This class will reset the speed increases caused by the SpeedupScore class when the game reloads. The speedupscore script makes
    a permanent adjustment to some of the variables of the classes involved such as obstacle speed in the obstacle mover class.*/

    // Start is called before the first frame update
    void Start()
    {
          ObstacleSpeedReset();//Reset's the speed of obstacles to 5 due to Speedup Score script changing the values.
          BackgroundSpeedReset();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     public void ObstacleSpeedReset()
    {
         foreach(GameObject obstacle in FindObjectOfType<ObstacleSpawns>().obstaclePrefabs)
            {
                obstacle.GetComponent<ObstacleMover>().Speed = 5;//instead of referencing the script directly, Reference the Script as a component of the gameobject. Reset back to 5 which is baseline speed upon game load.  
            }
               
    }
    public void BackgroundSpeedReset()
    {
         FindObjectOfType<BackgroundScroller>().GetComponent<BackgroundScroller>().backgroundScrollSpeed = 0.05f; //Original Value in Background scroller class is 0.05f;
    }
}
