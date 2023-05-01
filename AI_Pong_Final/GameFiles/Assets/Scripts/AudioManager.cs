using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Audio;
public class AudioManager : MonoBehaviour
{
    public Sound[] sounds; // array of all the sounds in the scene

    // Start is called before the first frame update
    void Awake() // loads all the sounds in the scene into a audiosource component
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }
    private void Start()
    {
        Play("BG"); // plays the background audio
    }

    public void Play(string name) // finds the clip by the name in the array of sounds and plays it
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }
}