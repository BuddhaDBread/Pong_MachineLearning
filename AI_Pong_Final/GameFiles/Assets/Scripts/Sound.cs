using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound // wrapper for unity's audio solution
{
    //member variables for the name of the song and the audioclip
    public string name;
    public AudioClip clip;//source of the clip from the assets

    [Range(0f, 1f)]
    public float volume; // loudness of the clip
    [Range(.1f, 3f)]
    public float pitch; //frequency of the clip

    public bool loop; // whether the clip keeps looping

    [HideInInspector]
    public AudioSource source; //unity's audio component that allows it to be played
}