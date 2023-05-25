using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckOxygen : MonoBehaviour
{
    Duck duck;
    public OxygenMeter oxygenMeter;
    bool isUnderwater = false;
        float currentOxygen;
        float maxOxygen = 100f;
        [Tooltip("Can add a small delay before regaining oxygen or keep it at zero.")][SerializeField] float timeBeforeOxygenIncrease; 
        [Tooltip("An int multiplier that will affect the rate at which the Oxygen increases")][SerializeField]int oxygenIncreaseRate;
        [Tooltip("An int multiplier that will affect the rate at which the Oxygen decreases")][SerializeField]int oxygenDecreaseRate;
        

    private void Awake() {
        FindObjectOfType<OxygenMeter>();
       duck = FindObjectOfType<Duck>();
        oxygenMeter = FindObjectOfType<OxygenMeter>();
        oxygenMeter.SetMaxOxygen(maxOxygen);
        currentOxygen = maxOxygen;
    }
    // Start is called before the first frame update
    void Start()
    {
    }
     private void OnTriggerStay2D(Collider2D collision) 
     {
        if(collision.gameObject.tag == "Underwater")
        {
            StopCoroutine(RegainOxygen());
            isUnderwater = true;
            currentOxygen -= Time.deltaTime * oxygenDecreaseRate;
            oxygenMeter.SetOxygen(currentOxygen);
        }
        
    }
    // Update is called once per frame
    void Update()
    {
       if (currentOxygen <= 0)
        {
            StopAllCoroutines();
            currentOxygen = 0;
            duck.DuckDestroyed();
            
        }
    }
    private void OnTriggerExit2D(Collider2D other) 
    {
        isUnderwater = false;
        StartCoroutine(RegainOxygen());
    }

    IEnumerator RegainOxygen()
    {
            do
            {
                
                currentOxygen += Time.deltaTime * oxygenIncreaseRate;
                oxygenMeter.SetOxygen(currentOxygen);
                yield return new WaitForSeconds(timeBeforeOxygenIncrease);
                
            }
                 
            while (!isUnderwater && currentOxygen < maxOxygen && currentOxygen > 0);
    }
}
