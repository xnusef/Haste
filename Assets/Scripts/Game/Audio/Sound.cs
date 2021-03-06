using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]public class Sound
{
    public string name;
    public AudioClip clip;
    public AudioMixerGroup group;
    [Range(0, 1f)] public float volume;
    [Range(.1f, 3f)] public float pitch;
    public bool loop;
    [System.NonSerialized]public AudioSource source;
}
