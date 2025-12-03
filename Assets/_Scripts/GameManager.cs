using ShaneClareDev;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // text file containing level data
    public TextAsset levelDataTextFile;
    //public AIPathFollower aIPathFollower;
    public MazeRenderer mazeRenderer;

    private Maze maze;

    void Awake()
    {
        LoadMapFromTextfile mapLoader = new LoadMapFromTextfile(levelDataTextFile);
        maze = mapLoader.GetMaze();
        mazeRenderer.DrawMap(maze);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        FindPathAStar findPathAStar = new FindPathAStar(maze, maze.entry, maze.exit);

        List<PathMarker> path = findPathAStar.GetSolutionPath();
        string message = "Path found: " + path.Count + " nodes";
        message += "\n node path = " + PathMarker.NodePathAsString(path);
        Debug.Log(message);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
