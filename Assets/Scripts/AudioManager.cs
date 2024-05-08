
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    static protected AudioManager instance;

    public static AudioManager Instance { get { return instance; } }
    public List<Sound> music, sfx;
    public AudioSource musicSource, sFXSource;
    protected float volume;

    private void Awake()
    {
        AudioManager.instance = this;
        this.musicSource = GameObject.Find("MusicSource").GetComponent<AudioSource>();
        this.sFXSource = GameObject.Find("SFXSource").GetComponent<AudioSource>();
    }

    public void SetVolume()
    {
        volume = GameManager.Instance.Player.volume;
    }


    private void Update()
    {
        SetVolume();
    }

    public virtual void PlayMusic(string name)
    {
        musicSource.volume = volume;
        foreach (Sound sound in this.music)
        {
            if (sound.name == name)
            {
                musicSource.clip = sound.clip;
                musicSource.Play();
            }
        }
    }

    public virtual void PlaySFX(string name)
    {
        sFXSource.volume = volume;
        foreach (Sound sound in this.sfx)
        {
            if (sound.name == name)
            {
                sFXSource.PlayOneShot(sound.clip);
            }
        }
    }
}
