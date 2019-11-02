﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampScript : MonoBehaviour
{

    private Transform player;

    public float visibilityRange = 25f;
    public Bounds checkBox;
    public GameObject lanternObject;
    public GameObject light;
    public Vector2 flickerTimerRange;
    public float offTime = 1f;

    private float flickerTimer;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, player.position) < visibilityRange && !Physics.CheckBox(transform.position + checkBox.center, checkBox.size/4))
        {
            if (!lanternObject.activeSelf)
                lanternObject.SetActive(true);
            
        } else
        {
            if (lanternObject.activeSelf)
                lanternObject.SetActive(false);
        }

        if(flickerTimer <= 0)
        {
            light.SetActive(true);
            flickerTimer = Random.Range(flickerTimerRange.x, flickerTimerRange.y);
        }

        if (flickerTimer < Random.Range(0,offTime))
        {
            light.SetActive(false);
        }

        if (flickerTimer > 0)
            flickerTimer -= Time.deltaTime;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position + checkBox.center, checkBox.size/2);
    }
}
