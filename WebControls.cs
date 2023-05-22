using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebControls : MonoBehaviour
{
    bool spaceDown;
    bool jumpUp;
    private Rigidbody2D rb;
    
    [SerializeField] private float downForce = 100f;
    [SerializeField] private float upForce = 10f;
    [SerializeField]float smooth = 5f;
    [SerializeField] float tiltAngle = 45f;
    [SerializeField] float timeBeforeFly = .3f;
    float flyTimer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
            Dive();
            FlyUp();
    }

    public void Dive()
    { 
        if(Input.GetKey(KeyCode.Space))
        {
            spaceDown = true;
        }
        if(Input.GetKeyUp(KeyCode.Space))
        {
            spaceDown = false;
        }
        switch (spaceDown)
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

    public void FlyUp()
    {
        if(Input.GetKey(KeyCode.UpArrow) && Time.time > flyTimer)
       
        {
           if(transform.rotation.z > -45 && transform.position.y > -1.50 && transform.position.y < 1.5)   
            {
                Flying();
            
            }
        }
        
    }
    public void Flying()
    {
            Quaternion Target = Quaternion.Euler(0,0,0);
            transform.rotation = Quaternion.Slerp(transform.rotation, Target , Time.deltaTime * smooth);
            rb.AddForce(new Vector2(0,upForce),ForceMode2D.Impulse);
            flyTimer = Time.time + timeBeforeFly;
    }
}
