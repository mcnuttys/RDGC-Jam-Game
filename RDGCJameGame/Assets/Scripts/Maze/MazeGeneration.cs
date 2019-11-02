using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGeneration : MonoBehaviour
{

    public string[] maze = new string[]
    {
        "11111111",
        "10000001",
        "10000001",
        "10000001",
        "10000001",
        "10000001",
        "10000001",
        "10000001",
        "10000001",
        "11111111"
    };

    public float wallWidth = 1f;
    public float wallLength = 1f;

    public GameObject wallSection;

    // Start is called before the first frame update
    void Start()
    {
        GenerateMaze(maze);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GenerateMaze(string[] maze)
    {
        int width = maze[0].Length;
        int height = maze.Length;

        for (int x = 0; x < width; x++)
        {
            for (int z = 0; z < height; z++)
            {
                if (maze[z][x] == '1')
                {
                    Vector3 wallPos = new Vector3(x * wallWidth, 0, z * wallLength);

                    // Instantiate the wall section.
                    Instantiate(wallSection, wallPos, Quaternion.identity, transform);
                }
            }
        }
    }
}
