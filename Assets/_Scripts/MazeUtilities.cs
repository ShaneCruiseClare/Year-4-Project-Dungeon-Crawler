using System.Collections.Generic;
using UnityEngine;

namespace Project1
{
    public class MazeUtilities
    {
        public static List<MapLocation> FindAllKeys(Maze maze, byte typeToFine = TileType.KEY)
        {
            Debug.Log(" ======================== searching for keys");
            List<MapLocation> keyLocations = new List<MapLocation>();

            for (int z = 0; z < maze.depth; z++)
            {

                for (int x = 0; x < maze.width; x++)
                {
                    byte tile = maze.map[x, z];
                    // ignore 0 and 1
                    if (tile > 1)
                    {
                        Debug.Log("(" + z + "," + x + ") tile type = " + tile);
                    }

                    if (tile == typeToFine)
                    {
                        Debug.Log("**************  key found z (row?) = " + z + ", x (column?) = " + x);
                        keyLocations.Add(new MapLocation(x, z));
                    }
                }
            }

            return keyLocations;
        }


        public static string KeyLocationsAsString(List<MapLocation> keys)
        {
            string keyLocations = "";
            foreach (MapLocation location in keys)
            {
                keyLocations += location.ToString() + ", ";
            }

            return keyLocations;
        }
    }

}
