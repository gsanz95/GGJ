﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("working");
        //next level
        if (col.tag == "Player")
        {
            //Level 2
            Application.LoadLevel(3);
            Debug.Log("load");
        }

    }
}

