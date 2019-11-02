using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyManager : MonoBehaviour
{
    public int keyCount;
    bool win;

    // Start is called before the first frame update
    void Start()
    {
        keyCount = 0;
        win = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(keyCount>=4)
        {
            win = true;
        }
    }
}
