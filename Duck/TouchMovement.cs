using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchMovement : MonoBehaviour
{
    private Rigidbody2D rb; 
    private float downForce = 100f;
    private bool fingerDown;

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
