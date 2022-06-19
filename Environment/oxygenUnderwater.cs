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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
          if (duck.currentOxygen <= 0)
            {
            
            duck.currentOxygen = 0;
            isUnderwater = false;
            duck.DuckDestroyed();
            }
    }
    private void OnTriggerEnter2D(Collider2D collision) 
    {
         if(collision.gameObject.tag == "Player")
        {
            isUnderwater = true;
            StartCoroutine(reduceOxygen(oxygenDecreaseRate));
        }
    }
     private void OnTriggerExit2D(Collider2D exitCollision)
    {
            isUnderwater = false;
    }

     IEnumerator reduceOxygen(int damage)
    {
         
         do
         {
            if(gameObject!=null)
            {
                duck.currentOxygen -= damage;
                oxygenMeter.SetOxygen(duck.currentOxygen);
                yield return new WaitForSeconds(timeBeforeOxygenDecrease);
            }
            
        }
        while (isUnderwater == true);
         
        }
    /*IEnumerator regainOxygen(int damage)
    {
        isUnderwater = false;
        do
        {
            if(duck.currentOxygen != 0 && duck.currentOxygen != duck.maxOxygen )
        {
            duck.currentOxygen += damage;
            oxygenMeter.SetOxygen(duck.currentOxygen);
            yield return new WaitForSeconds(timeBeforeOxygenIncrease);
        }
        else if(duck.currentOxygen >= duck.maxOxygen)
        {
            StopCoroutine(regainOxygen(damage));
        }
        }
        while (isUnderwater == false);
    }*/
}
