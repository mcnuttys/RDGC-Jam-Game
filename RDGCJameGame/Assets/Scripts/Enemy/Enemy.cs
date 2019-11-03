using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private NavMeshAgent nav;
    private Transform player;

    public float updateTargetTimer = 3f;
    public float movementSpeed = 1.5f;
    private float timer;

    private Footstep footstepScript;
    private Vector3 prevPosition;
    private bool coroutinesStopped;

    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        footstepScript = this.GetComponent<Footstep>();
        StartCoroutine(WaitForFootstep(1));
    }

    // Update is called once per frame
    void Update()
    {
        if (prevPosition != transform.position && coroutinesStopped)
        {
            StartCoroutine(WaitForFootstep(1));
            coroutinesStopped = false;
        }
        if (prevPosition == transform.position)
        {
            StopAllCoroutines();
            coroutinesStopped = true;
        }

        if(GetComponentInChildren<MeshRenderer>().isVisible)
        {
            Debug.DrawRay(transform.position, player.position - transform.position, Color.red);

            RaycastHit hit;
            Physics.Raycast(transform.position, player.position - transform.position, out hit);

            if (hit.transform == player)
                nav.speed = 0f;
        }
        else
        {
            nav.speed = movementSpeed;
        }

        if (timer <= 0)
        {
            nav.SetDestination(player.position);
            timer = updateTargetTimer;
        }

        if (timer > 0)
            timer -= Time.deltaTime;

        prevPosition = transform.position;
    }

    IEnumerator WaitForFootstep(float stepInterval)
    {
        yield return new WaitForSeconds(stepInterval);
        footstepScript.walking = true;
        StartCoroutine(WaitForFootstep(stepInterval));
    }
}
