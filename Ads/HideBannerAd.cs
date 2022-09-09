using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class HideBannerAd : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Advertisement.Banner.Hide();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
