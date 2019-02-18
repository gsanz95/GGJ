using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music_Engage : MonoBehaviour
{
    GameObject musicObj;
    public AudioClip clipToPlayHere;

    void Start()
    {
        musicObj = GameObject.FindGameObjectWithTag("Environment");
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Player"))
            if(musicObj)
                musicObj.GetComponent<Environment_Behaviors>().playAudioClip(clipToPlayHere);
    }
}
