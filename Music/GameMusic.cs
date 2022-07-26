using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMusic : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip[] songTracks;
    public float volume;
    private float trackTimer;
    private float songsPlayed;
    private bool[] hasPlayed;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        hasPlayed = new bool[songTracks.Length];

        if(!audioSource.isPlaying)
        ChangeSong(Random.Range(0, songTracks.Length));
    }

    // Update is called once per frame
    void Update()
    {
        audioSource.volume = volume;

        if(audioSource.isPlaying)
        trackTimer += 1 * Time.deltaTime;

        if(!audioSource.isPlaying || trackTimer >= audioSource.clip.length)
        ChangeSong(Random.Range(0, songTracks.Length));

        RestartShuffle();
    }
    public void ChangeSong(int songPicked)
    {
        if(!hasPlayed[songPicked])
        {
            trackTimer = 0;
            songsPlayed++;
            hasPlayed[songPicked] = true;
            audioSource.clip = songTracks[songPicked];
            audioSource.Play();
        }
        else
        audioSource.Stop();
    }
    private void RestartShuffle()
    {
    if (songsPlayed == songTracks.Length)
        {
            songsPlayed = 0;
            for (int i = 0; i < songTracks.Length; i++)
            {
                if (i == songTracks.Length)
                break;
                else
                hasPlayed[i] = false;
            }
        }
    }
}