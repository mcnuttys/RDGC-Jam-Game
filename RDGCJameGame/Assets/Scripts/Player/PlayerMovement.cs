using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController cc;
    private Vector3 direction;
    private float verticalSpeed;

    public float movementSpeed = 3;
    public float jumpSpeed = 3;

    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        direction = transform.rotation * new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        if (direction.magnitude > 1)
            direction = direction.normalized;

        if(Input.GetButtonDown("Jump") && cc.isGrounded)
        {
            verticalSpeed = jumpSpeed;
        }
    }

    void FixedUpdate()
    {
        Vector3 move = direction * movementSpeed;
        move.y = verticalSpeed;

        if (!cc.isGrounded)
            verticalSpeed += Physics.gravity.y * Time.deltaTime;

        move *= Time.deltaTime;
        cc.Move(move);
    }
}
