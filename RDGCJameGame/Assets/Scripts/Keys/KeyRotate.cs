using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyRotate : MonoBehaviour
{
    float timer;
    float maxTime = 1;
    bool up;
    Vector3 position;
    // Start is called before the first frame update
    void Start()
    {
        up = false;
        position = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (up)
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
        gameObject.transform.rotation = Quaternion.Euler(gameObject.transform.rotation.eulerAngles.x, gameObject.transform.rotation.eulerAngles.y + 1f, gameObject.transform.rotation.eulerAngles.z);
    }
}
