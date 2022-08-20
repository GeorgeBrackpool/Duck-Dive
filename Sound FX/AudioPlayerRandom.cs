using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayerRandom : MonoBehaviour
{
    [SerializeField] List<AudioClip> audioClips;
    AudioSource source;
    AudioClip currentClip;
    [SerializeField] float minWaitBetweenPlay = 2f;
    [SerializeField] float maxWaitBetweenPlay = 8f;
    float waitTimeCountdown = -1f;
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
                currentClip = audioClips[Random.Range(0, audioClips.Count)];
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
}
