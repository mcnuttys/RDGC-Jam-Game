using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampScript : MonoBehaviour
{

    private Transform player;

    public float visibilityRange = 25f;
    public Bounds checkBox;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, player.position) < 25f && !Physics.CheckBox(transform.position + checkBox.center, checkBox.size/4))
        {
            if (!gameObject.activeSelf)
                gameObject.SetActive(true);
            
        } else
        {
            if (gameObject.activeSelf)
                gameObject.SetActive(false);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position + checkBox.center, checkBox.size/2);
    }
}
