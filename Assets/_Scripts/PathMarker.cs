using System.Collections.Generic;

namespace Project1
{
    public class PathMarker
    {
        public MapLocation location;
        public float G, H, F;
        //   public GameObject marker;
        public PathMarker parent;

        //        public PathMarker(MapLocation l, float g, float h, float f, GameObject m, PathMarker p)
        public PathMarker(MapLocation l, float g, float h, float f, PathMarker p)
        {

            location = l;
            G = g;
            H = h;
            F = f;
            //      marker = m;
            parent = p;
        }

        public override bool Equals(object obj)
        {

            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
                return false;
            else
                return location.Equals(((PathMarker)obj).location);
        }

        public override int GetHashCode()
        {
            return 0;
        }

        //--------- static (class) methods ---------

        /**
        * give a list of Nodes,
        * return a string of their GameObject names
        */
        public static string NodePathAsString(List<PathMarker> path)
        {
            string nodeNames = "";
            foreach (PathMarker n in path)
            {
                MapLocation location = n.location;
                nodeNames += location.ToString() + ", ";
            }

            return nodeNames;
        }

        /*
         * move this logic into a separate method
         * it looks back through node links following the 'cameFrom' link
         * and returns a list of Nodes
         */
        public static List<PathMarker> RetrieveBestPath(PathMarker currentNode, PathMarker start, PathMarker end)
        {
            List<PathMarker> path = new List<PathMarker>();

            path.Insert(0, end);

            while (currentNode != start)
            {
                currentNode = currentNode.parent;
                path.Add(currentNode);
            }

            path.Reverse();
            return path;
        }

    }
}
