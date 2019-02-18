using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movable_Object : MonoBehaviour
{
    Transform m_transform;
    public AudioClip m_dragSound;
    private AudioSource m_soundPlayer;

    void Awake()
    {
        m_transform = gameObject.GetComponent<Transform>();
        m_soundPlayer = gameObject.GetComponent<AudioSource>();
    }

    // Push object
    public void MoveThisTowards(Vector2 deltaPos)
    {
        m_transform.Translate(deltaPos.x, deltaPos.y, 0);

        // Play Sound
        if (!m_soundPlayer.isPlaying)
            m_soundPlayer.PlayOneShot(m_dragSound);
    }
}