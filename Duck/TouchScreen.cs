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
          Quaternion baseTarget = Quaternion.Euler(0,0,0);//Slerp back to original Angle of 0.
           transform.rotation = Quaternion.Slerp(transform.rotation, baseTarget , Time.deltaTime * smooth);
     }
    // Update is called once per frame
    void Update()
    {
        Swipe();
    }
    private void FixedUpdate() {
        
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
                    Debug.Log("Up");
                    if(transform.rotation.z > -45 && transform.position.y > -1.50 && transform.position.y < 2) 
                    {
                         
                         Debug.Log("Jumped");
                    rb.constraints = RigidbodyConstraints2D.FreezeRotation;
                    rb.AddForce(new Vector2(0,upForce),ForceMode2D.Impulse);
                    Quaternion baseTarget = Quaternion.Euler(0,0,0);//Slerp back to original Angle of 0.
                    transform.rotation = Quaternion.Slerp(transform.rotation, baseTarget , Time.deltaTime * smooth);
                    
                    }
                    stopTouch = true;
                }
                
            }
            fingerDown = true;
        }
        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Stationary)
        {
            fingerDown = true;
            endTouchPosition = Input.GetTouch(0).position;
        Vector2 Distance = endTouchPosition - startTouchPosition;
         if (Mathf.Abs(Distance.x) < tapRange && Mathf.Abs(Distance.y) < tapRange)
        {
            Dive();
        }
        }
      if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
      {
         Quaternion baseTarget = Quaternion.Euler(0,0,0);//Slerp back to original Angle of 0.
           transform.rotation = Quaternion.Slerp(transform.rotation, baseTarget , Time.deltaTime * smooth);
        stopTouch = false;
        fingerDown = false;
        
       
      }
    }
    private void Dive()
        {
            switch (fingerDown)
       {
           case true:
           
           Quaternion target = Quaternion.Euler(0, 0 , -tiltAngle); //The angle we want to Slerp to.
           transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
            rb.AddForce(new Vector2(0f, -downForce), ForceMode2D.Force);//Add down force to dive under.
           break;
           case false:
           Quaternion baseTarget = Quaternion.Euler(0,0,0);//Slerp back to original Angle of 0.
           transform.rotation = Quaternion.Slerp(transform.rotation, baseTarget , Time.deltaTime * smooth);
           rb.AddForce(new Vector2(0f, 0f), ForceMode2D.Force);//Add down force to dive under.
           break;
       }
       }
    }
