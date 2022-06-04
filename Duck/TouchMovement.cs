using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchMovement : MonoBehaviour
{
    private Rigidbody2D rb; 
    private float downForce = 100f;
    private bool fingerDown;
    
    // Start is called before the first frame update
    void Start()
    {
        fingerDown = false;
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
         if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
           fingerDown = true;
        }
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
           fingerDown = false;
        }
    }

    private void FixedUpdate() {
       switch (fingerDown)
       {
           case true:
           rb.AddForce(new Vector2(0f, -downForce), ForceMode2D.Force);
           //transform.Rotate(0,0,-1);
           break;
           case false:
           rb.AddForce(new Vector2( 0f, 0f), ForceMode2D.Force);
           break;
       }
    }

}
