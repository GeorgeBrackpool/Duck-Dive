using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSounds : MonoBehaviour
{
    //This class is a copy of the GameMusic.cs class but is used to randomise water/stream sounds.
     public AudioSource audioSource;
    public AudioClip[] waterTracks;
    public float volume;
    public float pitch = 1f;
    private float trackTimer;
    private float songsPlayed;
    private bool[] hasPlayed;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        hasPlayed = new bool[waterTracks.Length];

        if(!audioSource.isPlaying)
        ChangeSong(Random.Range(0, waterTracks.Length));
    }

    // Update is called once per frame
    void Update()
    {
        audioSource.volume = volume;
        audioSource.pitch = pitch;

        if(audioSource.isPlaying)
        trackTimer += 1 * Time.deltaTime;

        if(!audioSource.isPlaying || trackTimer >= audioSource.clip.length)
        ChangeSong(Random.Range(0, waterTracks.Length));

        RestartShuffle();
    }
    public void ChangeSong(int songPicked)
    {
        if(!hasPlayed[songPicked])
        {
            trackTimer = 0;
            songsPlayed++;
            hasPlayed[songPicked] = true;
            audioSource.clip = waterTracks[songPicked];
            audioSource.Play();
        }
        else
        audioSource.Stop();
    }
    private void RestartShuffle()
    {
    if (songsPlayed == waterTracks.Length)
        {
            songsPlayed = 0;
            for (int i = 0; i < waterTracks.Length; i++)
            {
                if (i == waterTracks.Length)
                break;
                else
                hasPlayed[i] = false;
            }
        }
    }
}
