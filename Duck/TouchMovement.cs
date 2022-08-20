using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchMovement : MonoBehaviour
{
     private Rigidbody2D rb; 
    [SerializeField] private float downForce = 100f;
    [SerializeField] private float upForce = 100f;
    private bool fingerDown;
    private Vector2 startTouchPosition, currentTouchPosition;
    public float swipeRange; // Length of the swipe
    [SerializeField]float smooth = 5f;
    [SerializeField] float tiltAngle = 45f;

    
    // Start is called before the first frame update
    void Start()
    {
        fingerDown = false;
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        DiveMovement();
        
    }

    private void FixedUpdate() {
      DiveSwitch();
      
    }

    private void DiveMovement()
    {
         if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
           fingerDown = true;
           startTouchPosition = Input.GetTouch(0).position;
           
        }
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
           currentTouchPosition = Input.GetTouch(0).position;
           Vector2 Distance = currentTouchPosition - startTouchPosition;

        if(fingerDown && Distance.y > swipeRange)
        {
            if(transform.rotation.z > -45 && transform.position.y > -1.50 && transform.position.y < 2) 
            {
                
                rb.constraints = RigidbodyConstraints2D.FreezeRotation;
                Quaternion baseTarget = Quaternion.Euler(0,0,0);//Slerp back to original Angle of 0.
                transform.rotation = Quaternion.Slerp(transform.rotation, baseTarget , Time.deltaTime * smooth);
                rb.AddForce(new Vector2(0,upForce),ForceMode2D.Force);
            }
        }
        }
   
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {

           fingerDown = false;
           
        }
        
    }

    private void DiveSwitch()
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
           rb.AddForce(new Vector2( 0f, 0f), ForceMode2D.Force);
           
           break;
       }
    }

}

   
   


