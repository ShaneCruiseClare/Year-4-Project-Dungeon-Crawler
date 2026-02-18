using System.Collections.Generic;
using UnityEngine;

namespace Project1
{
    public class GameRunnerMB : MonoBehaviour
    {
        private AgendaManager agenda1;

        // text file containing level data
        public TextAsset levelDataTextFile;
        //public AIPathFollower aIPathFollower;
        public MazeRenderer mazeRenderer;

        private Maze maze;

        void Awake()
        {
            LoadMapFromTextFile mapLoader = new LoadMapFromTextFile(levelDataTextFile);
            maze = mapLoader.GetMaze();
            mazeRenderer.DrawMap(maze);

            Debug.Log("\n key locations = " + MazeUtilities.KeyLocationsAsString(maze.keyLocations));

        }

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            agenda1 = new AgendaManager();
            agenda1.Init();

            AgendaItem item2 = new AgendaItem();
            item2.task = GameEnums.TaskType.USE_KEY;

            agenda1.Add(item2);
            print(agenda1);
        }

        // Update is called once per frame
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
}
