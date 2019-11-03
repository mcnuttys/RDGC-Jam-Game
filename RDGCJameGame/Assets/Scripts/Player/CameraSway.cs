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

    [SerializeField]
    private Footstep footstepScript;
    // Exists to make sure the footstep 
    // sound only plays once not twice
    private bool isMirror;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        right = false;
        up = false;
        position = gameObject.transform.position;
        
        // don't change the name of the object please
        isMirror = this.name == "MirrorHolder";
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

                        // footstep sounds here
                        if (isMirror)
                            footstepScript.walking = true;
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
                        // footstep sounds here
                        if (isMirror)
                            footstepScript.walking = true;
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
