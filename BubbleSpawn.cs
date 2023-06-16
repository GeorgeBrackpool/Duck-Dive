using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleSpawn : MonoBehaviour
{
    bool DuckUnderwater = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collison) 
    {
        if(collison.gameObject.tag == "Underwater")
        {
            DuckUnderwater = true;
            if(DuckUnderwater)
            {
                 GameObject.FindWithTag("Bubbles").SetActive(true);
                 //TODO fix this.
            }
           

        }    
    }

    private void OnTriggerExit2D(Collider2D other) {

        DuckUnderwater = false;
        GameObject.FindWithTag("Bubbles").SetActive(false);
    }
}
