using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private NavMeshAgent nav;
    private Transform player;

    public float updateTargetTimer = 3f;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer <= 0)
        {
            nav.SetDestination(player.position);
            timer = updateTargetTimer;
        }

        if (timer > 0)
            timer -= Time.deltaTime;
    }
}
