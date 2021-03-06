using System;
using UnityEngine;
using UnityEngine.Audio;

public class EntityAudio : MonoBehaviour
{
    public Sound[] sounds;

    void Awake()
    {
        foreach(Sound sound in sounds)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;
            sound.source.volume = sound.volume;
            sound.source.pitch = sound.pitch;
            sound.source.loop = sound.loop;
            sound.source.outputAudioMixerGroup = sound.group;
        }
    }
    void Start()
    {
        Play("MenuMusic");
    }
    public void Play(string name)
    {
        Sound sound = Array.Find(sounds, sound => sound.name == name);
        if (sound == null)
            return;
        sound.source.Play();
    }
}
