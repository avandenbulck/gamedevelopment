using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioSource backgroundMusicAudioSource;
    public AudioClip shootSFX;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);

        }else if(instance != this)
        {
            Destroy(this.gameObject);
        }
    }

    public void EnableBackgroundMusic(bool enable)
    {
        if (enable)
            backgroundMusicAudioSource.Play();
        else
            backgroundMusicAudioSource.Stop();
    }

    public void PlayShootSFX()
    {
        backgroundMusicAudioSource.PlayOneShot(shootSFX);
    }
}
