﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footprints : MonoBehaviour
{
    public GameObject footprint;
    public GameObject player;
    public double timer;
    public double maxTime;
    // Start is called before the first frame update
    void Start()
    {
        maxTime = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(timer>maxTime)
        {
            timer = 0;
            Instantiate(footprint, player.transform);
            //  make walking sound
        }
        else
        {
            timer += Time.deltaTime;
        }
    }
}
