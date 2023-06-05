using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchScreen : MonoBehaviour
{
    private Vector2 startTouchPosition;
    private Vector2 currentTouchPosition;
    private Vector2 endTouchPosition;
    private bool stopTouch = false;
     private bool fingerDown;
    [SerializeField] private float upForce = 100f;
    [SerializeField] private float downForce = 100f;
    [SerializeField] float tiltAngle = 45f;
    [SerializeField]float smooth = 5f;
    public float swipeRange;
    public float tapRange;

    private Rigidbody2D rb;
     private void Start() {
         rb = GetComponent<Rigidbody2D>();
         stopTouch = false;
         fingerDown = false;
          
     }
    // Update is called once per frame
    void Update() //TODO: TEST FIXED UPDATE FOR TOUCHSCREEN, LESSEN THE DOWNFORCE AND RETEST
    {
        Swipe();
        
    }
    private void FixedUpdate() {
          if (fingerDown)
                {
                    // move this method back below into touchphase stationary after test
                    Dive();
                }
    }
    public void Swipe()
    {
       
        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            startTouchPosition = Input.GetTouch(0).position;
            
        }
        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            currentTouchPosition = Input.GetTouch(0).position;
            Vector2 Distance = currentTouchPosition - startTouchPosition;
            if(!stopTouch)
            {
                 if(Distance.y > swipeRange)
                {
                   
                    if(transform.rotation.z > -45 && transform.position.y > -1.50 && transform.position.y < 2) 
                    {
                         
                        Quaternion baseTarget = Quaternion.Euler(0,0,0);//Slerp back to original Angle of 0.
                        transform.rotation = Quaternion.Slerp(transform.rotation, baseTarget , Time.deltaTime * smooth);
                        rb.AddForce(new Vector2(0,upForce),ForceMode2D.Impulse);
                    }
                    stopTouch = true;
                }
                
            }
        }
        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Stationary)
        {
            fingerDown = true;
            endTouchPosition = Input.GetTouch(0).position;
            Vector2 Distance = endTouchPosition - startTouchPosition;
            // put fixedupdate thing here.
            //Mathf.Abs(Distance.x) < tapRange && Mathf.Abs(Distance.y) < tapRange
        }
      if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
      {
        stopTouch = false;
        fingerDown = false;
      }
             if (!fingerDown)
            {
              Quaternion originaltarget = Quaternion.Euler(0,0,0);//Slerp back to original Angle of 0.
              transform.rotation = Quaternion.Slerp(transform.rotation, originaltarget , Time.deltaTime * smooth);
            }
    }
    private void Dive()
        {
            switch (fingerDown)
       {
           case true:
           rb.AddForce(new Vector2(0f, -downForce), ForceMode2D.Force);//Add down force to dive under.
           Quaternion target = Quaternion.Euler(0, 0 , -tiltAngle); //The angle we want to Slerp to.
           transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
           break;
           case false:
           Quaternion baseTarget = Quaternion.Euler(0,0,0);//Slerp back to original Angle of 0.
           transform.rotation = Quaternion.Slerp(transform.rotation, baseTarget , Time.deltaTime * smooth);
           break;
       }
    }
}
