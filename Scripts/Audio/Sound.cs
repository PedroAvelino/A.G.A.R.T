using UnityEngine.Audio;
using System;
using UnityEngine;

[System.Serializable]
public class Sound
{
    [Header("Audio Name")]
    public string name;

    [Header("Audio Clip")]
    public AudioClip clip;

    [Header("Settings")]
    [Range(0f, 1f)]
    public float volume;
    [Range(.1f, 3f)]
    public float pitch;
    public bool loop;
    public bool playInAwake;

    [HideInInspector]
    public AudioSource source;
}
