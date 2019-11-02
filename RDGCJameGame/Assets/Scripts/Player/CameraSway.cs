using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSway : MonoBehaviour
{
    float timer;
    float maxTime = 1;
    bool left;
    bool up;
    Vector3 position;

    // Start is called before the first frame update
    void Start()
    {
        left = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (left)
        {
            if (up)
            {
                if (timer > maxTime)
                {
                    timer = 0;
                    left = false;
                }
                else
                {
                    timer += Time.deltaTime;
                    position.x += .005f;
                    gameObject.transform.position = position;
                }
            }
            else
            {
                if (timer > maxTime)
                {
                    timer = 0;
                    up = false;
                }
                else
                {
                    timer += Time.deltaTime;
                    position.y += .005f;
                    gameObject.transform.position = position;
                }
            }
        }
        else
        {
            if (up)
            {
                if (timer > maxTime)
                {
                    timer = 0;
                    left = true;
                }
                else
                {
                    timer += Time.deltaTime;
                    position.x -= .005f;
                    gameObject.transform.position = position;
                }
            }
            else
            {
                if (timer > maxTime)
                {
                    timer = 0;
                    up = true;
                }
                else
                {
                    timer += Time.deltaTime;
                    position.y -= .005f;
                    gameObject.transform.position = position;
                }
            }
        }
    }
}
