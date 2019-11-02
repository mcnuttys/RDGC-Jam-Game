using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{

    public enum LookType
    {
        MouseX,
        MouseY
    };

    public LookType lookType;

    public float sensitivityX = 3;
    public float sensitivityY = 3;

    public Vector2 minMaxX = new Vector2(-360, 360);
    public Vector2 minMaxY = new Vector2(-80, 80);

    private float xRot;
    private float yRot;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch(lookType)
        {
            case LookType.MouseX:
                xRot += Input.GetAxis("Mouse X");
                //xRot = Mathf.Clamp(xRot, minMaxX.x, minMaxX.y);

                transform.localRotation = Quaternion.Euler(0, xRot, 0);
                break;
            case LookType.MouseY:
                yRot += Input.GetAxis("Mouse Y");
                yRot = Mathf.Clamp(yRot, minMaxY.x, minMaxY.y);

                transform.localRotation = Quaternion.Euler(-yRot, 0, 0);
                break;
        }
    }
}
