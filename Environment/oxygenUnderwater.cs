using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oxygenUnderwater : MonoBehaviour
{
    public OxygenMeter oxygenMeter;
    public Duck duck;
    bool isUnderwater = false;
    [SerializeField] int oxygenDecreaseRate = 5;
    [SerializeField] int timeBeforeOxygenDecrease = 3;
    [SerializeField] int timeBeforeOxygenIncrease = 2;
    [SerializeField] int oxygenRegainRate = 5;
    private void Awake() {
        FindObjectOfType<OxygenMeter>();
        FindObjectOfType<Duck>();
        duck = FindObjectOfType<Duck>();
        oxygenMeter = FindObjectOfType<OxygenMeter>();
        oxygenMeter.SetMaxOxygen(duck.maxOxygen);
    }
  

    // Update is called once per frame
    void Update()
    {
          if (duck.currentOxygen <= 0)
            {
            StopAllCoroutines();
            isUnderwater = false;
            duck.currentOxygen = 0;
            if (duck != null)
            {
                 duck.DuckDestroyed();
            }
            
        }
    }
    private void OnTriggerEnter2D(Collider2D collision) 
    {
         if(collision.gameObject.tag == "Player")
        {
            isUnderwater = true;
            StopCoroutine(regainOxygen(oxygenRegainRate));
            StartCoroutine(reduceOxygen(oxygenDecreaseRate));
            
        }
    }
     private void OnTriggerExit2D(Collider2D exitCollision)
    {
            isUnderwater = false;
            StopCoroutine(reduceOxygen(oxygenDecreaseRate));
            StartCoroutine(regainOxygen(oxygenRegainRate));
           
            
    }

     IEnumerator reduceOxygen(int damage)
    {
         
         do
         {      
                yield return new WaitForSeconds(timeBeforeOxygenDecrease);
                duck.currentOxygen -= damage;
                oxygenMeter.SetOxygen(duck.currentOxygen);
                
                
        }
        
        while (isUnderwater == true && duck.currentOxygen > 0);
         
        }
    IEnumerator regainOxygen(int damage)
    {
        
        do
        {
            duck.currentOxygen += damage;
            oxygenMeter.SetOxygen(duck.currentOxygen);
            yield return new WaitForSeconds(timeBeforeOxygenIncrease);
            
        }
        while (duck.currentOxygen < duck.maxOxygen && duck.currentOxygen > 0 && isUnderwater == false);
    }
}
