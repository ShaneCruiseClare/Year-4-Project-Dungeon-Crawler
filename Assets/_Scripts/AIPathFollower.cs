using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project1
{
    public class AIPathFollower : MonoBehaviour
    {
        public Maze maze;
        public float speed = 3f;

        private List<PathMarker> path;
        //private int currentIndex = 0;
        private bool pathHasBeenFound = false;

        private bool hasFinishedPrintingOutPath = false;

        private FindPathAStar pathfinder;

        void Start()
        {
            MapLocation start = maze.entry;
            MapLocation end = maze.exit;

            Debug.Log("start = " + start + " //  " + "end = " + end);


            pathfinder = new FindPathAStar(maze, start, end);

            // Wait until a path is found method
            StartCoroutine(WaitForPath());
        }

        IEnumerator WaitForPath()
        {
            // Wait until path is found
            while (!pathfinder.HasFinished())
                yield return null;

            // Get the path from solutionPath
            path = pathfinder.GetSolutionPath();

            // Convert map positions into world positions
            //currentIndex = 0;
            pathHasBeenFound = true;

        }

        void Update()
        {
            if (pathHasBeenFound)
            {
                if (!hasFinishedPrintingOutPath)
                {
                    // done - print out path
                    string message = "Path found: " + path.Count + " nodes";
                    message += "\n node path = " + PathMarker.NodePathAsString(path);
                    Debug.Log(message);

                    // only print out once
                    hasFinishedPrintingOutPath = true;
                }


            }
        }
    }
}
