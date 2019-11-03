using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController cc;
    private Vector3 direction;
    private float verticalSpeed;
    public GameObject enemy;
    public Vector3 previousPosition;
    public bool moving;

    public float movementSpeed = 3;
    public float jumpSpeed = 3;

    private bool canMove;
    private AudioSource spookSource;
    private bool soundPlaying;

    // Start is called before the first frame update
    void Start()
    {
        moving = false;
        cc = GetComponent<CharacterController>();
        canMove = true;
        spookSource = GetComponent<AudioSource>();
        soundPlaying = false;
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
        if(direction.magnitude>0)
        {
            moving = true;
        }
        else
        {
            moving = false;
        }

        TestEnemyDistance();
    }

    void FixedUpdate()
    {
        Vector3 move = direction * movementSpeed;
        move.y = verticalSpeed;

        if (!cc.isGrounded)
            verticalSpeed += Physics.gravity.y * Time.deltaTime;

        move *= Time.deltaTime;
        if (canMove)
            cc.Move(move);
    }

    private void TestEnemyDistance()
    {
        if(Vector3.Distance(transform.position, enemy.transform.position) < 1.4f && !soundPlaying)
        {
            soundPlaying = true;
            // play spooky sound
            // aww ty jacob
            spookSource.Play();
            canMove = false;
            Cursor.lockState = CursorLockMode.None;
            StartCoroutine(WaitForSpookSound());
        }
    }

    IEnumerator WaitForSpookSound()
    {
        yield return new WaitForSeconds(spookSource.clip.length);
        SceneManager.LoadScene(3); //dead screen
    }
}
