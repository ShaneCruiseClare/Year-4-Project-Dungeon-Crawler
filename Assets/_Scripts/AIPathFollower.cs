using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ShaneClareDev;

    public class AIPathFollower : MonoBehaviour
    {
        public FindPathAStar pathfinder;
        public Maze maze;
        public float speed = 3f;

        private List<PathMarker> path;
        private int currentIndex = 0;
        private bool ready = false;

        void Start()
        {
            // Wait until a path is found method
            StartCoroutine(WaitForPath());
        }

        IEnumerator WaitForPath()
        {
            // Wait until path is found
            while (!pathfinder.done)
                yield return null;

            // Get the path from solutionPath
            path = pathfinder.solutionPath;

            // Convert map positions into world positions
            currentIndex = 0;
            ready = true;

            // Move AI to the first node
            Vector3 startPoint = MazeGrid(path[0].location);
            transform.position = startPoint;
        }

        void Update()
        {
        /* 
          ------------------------------------------------------------------------
          If path is not ready and not found and is equal to exit then stop moving
          ------------------------------------------------------------------------
        */
        if (ready && path != null && currentIndex < path.Count)
        {
            // Else move toward the next node
            Vector3 nextPos = MazeGrid(path[currentIndex].location);
            transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);

            // The node was found move to next one
            if (Vector3.Distance(transform.position, nextPos) < 0.1f)
            {
                currentIndex++;
            }
        }
        
        }

        Vector3 MazeGrid(MapLocation loc)
        {
            return new Vector3(loc.row * maze.scale, 1f, loc.col * maze.scale);
        }
    }
