using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Environment_Behaviors : MonoBehaviour
{
    public bool m_isPushingPlayer;
    private float m_pushTimer;

    public float m_coolDownTime;
    public GameObject m_playerObject;
    public float m_windForce;
    public AudioClip m_backgroundMusic;
    public float m_volume;

    private AudioSource m_env_audio;
    private GameObject musicObj;

    void Start()
    {
        this.m_isPushingPlayer = false;
        this.m_pushTimer = m_coolDownTime;
    }

    void Awake()
    {
        this.m_env_audio = gameObject.GetComponent<AudioSource>();
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
        this.m_env_audio.volume = m_volume * 2;
        this.m_env_audio.Play();
    }

    // Update is called once per frame
    void Update()
    {
        PushPlayerTowards();
    }

    void PushPlayerTowards()
    {

        float trueForce;

        if (m_isPushingPlayer)
            trueForce = m_windForce;
        else
            trueForce = 0f;

        // Push player
        if(m_playerObject != null)
            m_playerObject.GetComponent<Player_Controller>().PushPlayer(trueForce);
    }
}
