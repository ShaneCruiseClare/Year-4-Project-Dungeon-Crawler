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

        Debug.Log("\n key locations = " + MazeUtilities.KeyLocationsAsString(maze.keyLocations));

    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // intialiastion AGENDA
    }

    // Update is called once per frame
    /*
     * make a Coroutine - 
     * sleep/wait, current goal not yet complete
     * 
     * need a variable that GOAL can update to say when complete ...
     */
    void Update()
    {
        // if current goal completed 
        //           choose next goal in agenda
        ATTEMPT_GOTO_EXIT();
        
    }

    private void ATTEMPT_GOTO_EXIT()
    {

        FindPathAStar findPathAStar = new FindPathAStar(maze, maze.entry, maze.exit);

        List<PathMarker> path = findPathAStar.GetSolutionPath();
        string message = "Path found: " + path.Count + " nodes";
        message += "\n node path = " + PathMarker.NodePathAsString(path);
        Debug.Log(message);

    }
}
