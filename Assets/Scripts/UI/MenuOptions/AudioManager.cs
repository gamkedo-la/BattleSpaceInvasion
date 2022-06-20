using UnityEngine.Audio;
using System;
using UnityEngine;

/*
    Note to anyone adding sound:
    Call the audio manager from the script that is playing the sound
    Call: FindObjectOfType<AudioManager>().Play("Name");
    Where "Name" is the name entered into the gameobject holding the audiomanager script and must match exactly
    On the gameobject in the editor:
    add a new sound (don't mess with the others unless you purposely want to alter them)
    Set the volume to 1 (or desired volume) and pitch to 1 (or desired pitch)
*/

public class AudioManager : MonoBehaviour
{
    private Sound[] sounds;
    public AudioSO audios;
    public AudioMixerGroup audioMixerGroup;
    public AudioMixer audioMixer;

    private float[] originalVolumes;
    //public static AudioManager instance;

    public SettingsSO settings;

    //singleton to last throughtout each scene
    void Awake()
    {
        //apply the desired settings to each sound
        foreach (Sound s in audios.sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.outputAudioMixerGroup = audioMixerGroup;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
        originalVolumes = new float[audios.sounds.Length];
    }

    //set the main audio volume
    private void Start()
    {
        audioMixer.SetFloat("Volume", Mathf.Log10(settings.soundSetting) * 20);
    }

    //call this to start playing the desired sound...make sure to enter the name in script exactly as entered in the editor
    public void Play(string name)
    {
        Sound s = Array.Find(audios.sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.source.Play();
    }

    //stop the sound by the correct name
    public void Stop(string name)
    {
        Sound s = Array.Find(audios.sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.source.Stop();
    }

    //stop all sounds being played
    public void StopAllSounds()
    {
        foreach (Sound s in audios.sounds)
        {
            s.source.Stop();
        }
    }

    //mute the audio
    public void MuteAudio()
    {
        foreach (Sound s in audios.sounds)
        {
            for (int i = 0; i < audios.sounds.Length; i++)
            {
                originalVolumes[i] = s.volume;
            }

            s.source.volume = 0f;
        }
    }

    //unmute the audio
    public void UnmuteAudio()
    {
        foreach (Sound s in audios.sounds)
        {
            for (int i = 0; i < audios.sounds.Length; i++)
            {
                s.source.volume = originalVolumes[i];
            }
        }
    }
}