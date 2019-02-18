using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Starting_Script : MonoBehaviour
{
    public AudioClip m_backgroundMusic;
    public float m_volume;

    private AudioSource m_env_audio;
    
    // Start is called before the first frame update
    void Start()
    {
        this.m_env_audio = GetComponent<AudioSource>();

        m_env_audio.loop = true;

        playDefaultClip();
    }

    public void playDefaultClip()
    {
        this.m_env_audio.Stop();
        this.m_env_audio.clip = this.m_backgroundMusic;
        this.m_env_audio.volume = m_volume;
        this.m_env_audio.Play();
    }

    // Sets the environment music to clip
    public void playAudioClip(AudioClip clip)
    {
        this.m_env_audio.Stop();
        this.m_env_audio.clip = clip;
        this.m_env_audio.volume = m_volume;
        this.m_env_audio.Play();
    }
}
