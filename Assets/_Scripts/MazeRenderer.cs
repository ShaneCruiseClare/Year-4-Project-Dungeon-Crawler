using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ShaneClareDev;

public class MazeRenderer : MonoBehaviour
{

    // TODO
    // render KEYS somehow - red cubes or whatever
    //
    // and perhaps ENTERY and EXIT 

    public void DrawMap(Maze maze)
    {
        for (int z = 0; z < maze.depth; z++)
            for (int x = 0; x < maze.width; x++)
            {
                if (maze.map[x, z] == 1)
                {
                    Vector3 pos = new Vector3(x * maze.scale, 0, z * maze.scale);
                    GameObject wall = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    wall.transform.localScale = new Vector3(maze.scale, maze.scale, maze.scale);
                    wall.transform.position = pos;
                }
            }
    }
}
