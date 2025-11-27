using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

using ShaneClareDev;


public class FindPathAStar : MonoBehaviour 
{
    public Maze maze;
    public Material closedMaterial;
    public Material openMaterial;
    public GameObject start;
    public GameObject end;
    public GameObject pathP;

    PathMarker startNode;
    PathMarker goalNode;
    PathMarker lastPos;
    public bool done = false;
    bool hasStarted = false;
    private bool hasFinishedPrintingOutPath = false;
    
    public List<PathMarker> solutionPath = new List<PathMarker>();

    List<PathMarker> open = new List<PathMarker>();
    List<PathMarker> closed = new List<PathMarker>();

    void BeginSearch() {

        done = false;
        startNode = new PathMarker(maze.entry, 0.0f, 0.0f, 0.0f, null);
        goalNode = new PathMarker(maze.exit, 0.0f, 0.0f, 0.0f,  null);

        open.Clear();
        closed.Clear();

        open.Add(startNode);
        lastPos = startNode;
        
        Debug.Log("start = " + maze.entry+ " //  " + "end = " + maze.exit);

    }

    void Search(PathMarker thisNode) 
    {
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

            if (!UpdateMarker(neighbour, g, h, f, thisNode)) {

//                open.Add(new PathMarker(neighbour, g, h, f, pathBlock, thisNode));
                open.Add(new PathMarker(neighbour, g, h, f, thisNode));
            }
        }
        open = open.OrderBy(p => p.F).ToList<PathMarker>();
        PathMarker pm = (PathMarker)open.ElementAt(0);
        closed.Add(pm);

        open.RemoveAt(0);
//        pm.marker.GetComponent<Renderer>().material = closedMaterial;

        lastPos = pm;
    }

    bool UpdateMarker(MapLocation pos, float g, float h, float f, PathMarker prt) 
    {
        foreach (PathMarker p in open) {
            if (p.location.Equals(pos)) {
                p.G = g;
                p.H = h;
                p.F = f;
                p.parent = prt;
                return true;
            }
        }
        return false;
    }

    bool IsClosed(MapLocation marker) {

        foreach (PathMarker p in closed) {

            if (p.location.Equals(marker)) return true;
        }
        return false;
    }

    void Start() 
    {
        BeginSearch();
        hasStarted = true;
    }

    void Update()
    {
        if (!done)
        {
            if (hasStarted)
            {
                Search(lastPos);
            }
        } else {
            if (!hasFinishedPrintingOutPath)
            {
                // done - print out path
                string message = "Path found: " + solutionPath.Count + " nodes";
                message += "\n node path = " + PathMarker.NodePathAsString(solutionPath);
                Debug.Log(message);

                // only print out once
                hasFinishedPrintingOutPath = true;
            }
        }
    }
}
