using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footprints : MonoBehaviour
{
    public GameObject footprint;
    public double timer;
    public double maxTime = 1;
    public GameObject parent;
    public Vector3 previousPosition;
    // Start is called before the first frame update
    void Start()
    {
        previousPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position != previousPosition)
        {
            if (timer > maxTime)
            {
                timer = 0;
                Instantiate(footprint, new Vector3(transform.position.x, 1, transform.position.z), transform.rotation, parent.transform);
                //  make walking sound
            }
            else
            {
                timer += Time.deltaTime;
            }
        }
        previousPosition = transform.position;
    }
}
