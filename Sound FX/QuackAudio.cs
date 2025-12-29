using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuackAudio : MonoBehaviour
{
    [SerializeField] List<AudioClip> audioClips;
    [SerializeField] List<AudioClip> underwaterAudioClips;
    AudioSource source;
    AudioClip currentClip;
    [SerializeField] float minWaitBetweenPlay = 2f;
    [SerializeField] float maxWaitBetweenPlay = 8f;
    float waitTimeCountdown = -1f;
    bool DuckUnderwater = false;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!source.isPlaying)
        {
            if (waitTimeCountdown < 0f)
            {
               
                if(DuckUnderwater == false)
                {
                    currentClip = audioClips[Random.Range(0, audioClips.Count)];
                }
                else if(DuckUnderwater == true)
                {
                    currentClip = underwaterAudioClips[Random.Range(0, underwaterAudioClips.Count)];
                }
                source.clip = currentClip;
                source.Play();
                waitTimeCountdown = Random.Range(minWaitBetweenPlay, maxWaitBetweenPlay);
            }
            else 
            {
                waitTimeCountdown -= Time.deltaTime;
            }
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Underwater")
        {
            DuckUnderwater = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        DuckUnderwater = false;
    }
}

