﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGeneration : MonoBehaviour
{

    private string[] maze = new string[]
    {
        "111111111111111111111111111111111111111111111",
        "111111111111111111111111111111111111111110001",
        "111111110000000000011111011111100000111110001",
        "110001101011111111011111001000101101100000001",
        "100101001000000010000111100010101000101111111",
        "101111011011010010110011111010100010100000111",
        "101000000001010100001010000010101000111110001",
        "101011111100010011101100001110101110000010101",
        "101010000011101001000101001000100011111000101",
        "101010101010101111000101001011100100101010111",
        "100010100010000001000101110000000001000110011",
        "110100011010101101101101010111111111011111011",
        "100101000010101001000100000000010000010000011",
        "101101011110101111000111110101000111110101011",
        "100100000000100001000100010100010100000111111",
        "110111111110111101101111010111010001010100011",
        "100100000010000100100000011100010100010100011",
        "101101101010110110101101000101010011110100011",
        "100101000010000000001001010100011010110111011",
        "110101011111111101111011000111110000100001011",
        "100101010001010100101001110100010111111101011",
        "101100010101010000001100010101110101000101011",
        "101001111101000101110010010000000000010100011",
        "101010000000010001101001010111011110110101111",
        "101010101101001100101011010010010000010100011",
        "101010111111010001101000011011010111110110111",
        "101010001111110000010101011111010110111110111",
        "101010001100000110000100001000000000000100011",
        "100010001001111100010101001011011111010111011",
        "101111111110000001010100100001000111000001011",
        "100010100000111101000010101100110011011101011",
        "101000101110100100010101001000000100000101011",
        "100010001000010111100000101111010101110000011",
        "111111111011100100001111100100010000011111111",
        "111111111111111111111111111111111111111111111"
    };

    public float wallWidth = 1f;
    public float wallLength = 1f;

    public GameObject wallSection;
    public GameObject wallWithLampSection;

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

        for (int x = width-1; x >= 0; x--)
        {
            for (int z = 0; z < height; z++)
            {
                if (maze[z][x] == '1')
                {
                    Vector3 wallPos = new Vector3((width-x) * wallWidth, 0, z * wallLength);

                    // Instantiate the wall section.
                    GameObject objToCreate = (Random.Range(0, 100) > 10) ? wallSection : wallWithLampSection;

                    GameObject wall = Instantiate(objToCreate, wallPos, Quaternion.identity, transform);
                    wall.transform.name = wallPos.ToString();
                }
            }
        }
    }
}
