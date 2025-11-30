using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

using ShaneClareDev;

namespace ShaneClareDev
{
    public class FindPathAStar
    {
        private Maze maze;
        //public Material closedMaterial;
        //public Material openMaterial;
        //private GameObject start;
        //private GameObject end;
        //public GameObject pathP;

        private MapLocation startLocation;
        private MapLocation endLocation;

        private PathMarker startNode;
        private PathMarker goalNode;
        private PathMarker lastPos;

        private bool done = false;

        private List<PathMarker> solutionPath = new List<PathMarker>();

        List<PathMarker> open = new List<PathMarker>();
        List<PathMarker> closed = new List<PathMarker>();

        /**
         * ============================================= getters ================
         */

        public List<PathMarker> GetSolutionPath() { return solutionPath; }
        public bool HasFinished() { return done; }


        public FindPathAStar(Maze newMaze, MapLocation newStart, MapLocation newEnd)
        {
//            Debug.Log("(1) - FindPathAStar.FindPath()");
            maze = newMaze;
            startLocation = newStart;
            endLocation = newEnd;

            BeginSearch();
        }

        void BeginSearch()
        {
//            Debug.Log("(2) - FindPathAStar.BeginSearch()");

            done = false;
            startNode = new PathMarker(startLocation, 0.0f, 0.0f, 0.0f, null);
            goalNode = new PathMarker(endLocation, 0.0f, 0.0f, 0.0f, null);

            open.Clear();
            closed.Clear();

            open.Add(startNode);
            lastPos = startNode;

            Search(lastPos);


        }


        /**
         * search from the give node (thisNode argument) 
         * towards 'goalNode'
         * 
         */
        void Search(PathMarker thisNode)
        {
//            Debug.Log("(3) - FindPathAStar.Search()");

            /*
             * --------------------------------------------------
             *  found the goal - return the path back to start
             * --------------------------------------------------
             */
            if (thisNode.Equals(goalNode))
            {
                solutionPath = PathMarker.RetrieveBestPath(thisNode, startNode, goalNode);

                done = true;
                Debug.Log("DONE!");
                return;
            }

            /*
             * --------------------------------------------------
             *  still searching
             * - loop through 4 compass directions (N, S, E, W)
             * --------------------------------------------------
             */
            foreach (MapLocation dir in maze.directions)
            {
                //            MapLocation neighbour = dir + thisNode.location;
                int neighbourX = thisNode.location.row + dir.row;
                int neighbourY = thisNode.location.col + dir.col;
                MapLocation neighbour = new MapLocation(neighbourX, neighbourY);

                // if a WALL, then disregard this location (can't be part of path to destination!)
                if (maze.map[neighbour.row, neighbour.col] == TileType.WALL) continue;

                // if at the EDGE of the maze, then disregard this location (
                if (neighbour.row < 1 || neighbour.row >= maze.width || neighbour.col < 1 || neighbour.col >= maze.depth) continue;

                // if neightbour is in the list of closed nodes, then disregard
                if (IsClosed(neighbour)) continue;

                // add distance from current node to neightbour, to calc G value for neight 
                float g = Vector2.Distance(thisNode.location.ToVector(), neighbour.ToVector()) + thisNode.G;

                // calc H for neighbour as straight-line distance from neightbour to goal node
                float h = Vector2.Distance(neighbour.ToVector(), goalNode.location.ToVector());

                // calc F total for this neightbour node
                float f = g + h;

                // create a GameObject with Text for this neightbour node
                /*
                GameObject pathBlock = Instantiate(pathP, new Vector3(neighbour.x * maze.scale, 0.0f, neighbour.z * maze.scale), Quaternion.identity);
                TextMesh[] values = pathBlock.GetComponentsInChildren<TextMesh>();
                values[0].text = "G: " + g.ToString("0.00");
                values[1].text = "H: " + h.ToString("0.00");
                values[2].text = "F: " + f.ToString("0.00");
                */

                if (!UpdateMarker(neighbour, g, h, f, thisNode))
                {

                    //                open.Add(new PathMarker(neighbour, g, h, f, pathBlock, thisNode));
                    open.Add(new PathMarker(neighbour, g, h, f, thisNode));
                }
            }

            open = open.OrderBy(p => p.F).ToList<PathMarker>();
            PathMarker pm = (PathMarker)open.ElementAt(0);
            closed.Add(pm);

            open.RemoveAt(0);

            lastPos = pm;

            // search from new lastPos
            Search(lastPos);
        }

        bool UpdateMarker(MapLocation pos, float g, float h, float f, PathMarker prt)
        {
            foreach (PathMarker p in open)
            {
                if (p.location.Equals(pos))
                {
                    p.G = g;
                    p.H = h;
                    p.F = f;
                    p.parent = prt;
                    return true;
                }
            }
            return false;
        }

        bool IsClosed(MapLocation marker)
        {

            foreach (PathMarker p in closed)
            {

                if (p.location.Equals(marker)) return true;
            }
            return false;
        }

        //void Start() 
        //{
        //    BeginSearch();
        //    hasStarted = true;
        //}

        //void Update()
        //{
        //    if (!done)
        //    {
        //        if (hasStarted)
        //        {
        //            Search(lastPos);
        //        }
        //    } else {
        //        if (!hasFinishedPrintingOutPath)
        //        {
        //            // done - print out path
        //            string message = "Path found: " + solutionPath.Count + " nodes";
        //            message += "\n node path = " + PathMarker.NodePathAsString(solutionPath);
        //            Debug.Log(message);

        //            // only print out once
        //            hasFinishedPrintingOutPath = true;
        //        }
        //    }
        //}
    }

}