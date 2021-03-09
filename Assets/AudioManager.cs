using UnityEngine.Audio;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public static AudioManager instance;
    void Awake()
    {
        //if(SceneManager.GetActiveScene().buildIndex >= 3 && SceneManager.GetActiveScene().buildIndex <= 9)
        //{
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(gameObject);
                return;
            }

            DontDestroyOnLoad(gameObject);
        //}
        //else
        //{
        //    Destroy(gameObject);
        //    return;
        //}

        foreach (var s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.audioClip;

            s.source.volume = PlayerPrefs.GetFloat("volume", 0.75f);
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    private void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex <= 1)
        {
            StopPlaying("Background");
            Play("Menu");
        }
        else if(SceneManager.GetActiveScene().buildIndex == 2 || SceneManager.GetActiveScene().buildIndex >= 9)
        {
            StopPlaying("Menu");
            StopPlaying("Background");
        }
        else
        {
            StopPlaying("Menu");
            Play("Background");
        }
    }

    public void Play (string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }

    public void StopPlaying(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Stop();
        if (s == null) return;
    }

    private void Update()
    {
        foreach (var s in sounds)
        {
            s.source.volume = PlayerPrefs.GetFloat("volume", 0.75f);
        }
        if (SceneManager.GetActiveScene().buildIndex == 2 || SceneManager.GetActiveScene().buildIndex >= 9)
        {
            Destroy(this.gameObject);
        }
    }
}
