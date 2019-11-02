using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSway : MonoBehaviour
{
    float timer;
    float maxTime = .4f;
    bool right;
    bool up;
    Vector3 position;
    float swaySpeedX = .0001f;
    float swaySpeedY = .00075f;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        right = false;
        up = false;
        position = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<PlayerMovement>().moving)
        {
            position = gameObject.transform.position;
            if (right)
            {
                if (up)
                {
                    if (timer > maxTime)
                    {
                        timer = 0;
                        right = false;
                        up = false;
                    }
                    else
                    {
                        timer += Time.deltaTime;
                        position.x += swaySpeedX;
                        position.y += swaySpeedY;
                        gameObject.transform.position = position;
                    }
                }
                else
                {
                    if (timer > maxTime)
                    {
                        timer = 0;
                        up = true;
                        right = true;
                    }
                    else
                    {
                        timer += Time.deltaTime;
                        position.x += swaySpeedX;
                        position.y -= swaySpeedY;
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
                        right = true;
                        up = false;
                    }
                    else
                    {
                        timer += Time.deltaTime;
                        position.x -= swaySpeedX;
                        position.y += swaySpeedY;
                        gameObject.transform.position = position;
                    }
                }
                else
                {
                    if (timer > maxTime)
                    {
                        timer = 0;
                        right = false;
                        up = true;
                    }
                    else
                    {
                        timer += Time.deltaTime;
                        position.x -= swaySpeedX;
                        position.y -= swaySpeedY;
                        gameObject.transform.position = position;
                    }
                }
            }
        }
           
    }
}
