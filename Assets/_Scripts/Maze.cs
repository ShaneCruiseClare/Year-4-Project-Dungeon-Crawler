using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ShaneClareDev;

namespace ShaneClareDev
{


    public class Maze
    {
        public List<MapLocation> directions = new List<MapLocation>() {
                                                new MapLocation(1,0),
                                                new MapLocation(0,1),
                                                new MapLocation(-1,0),
                                                new MapLocation(0,-1) };
        public int width = 30; //x length
        public int depth = 30; //z length
        public byte[,] map;
        public int scale = 6;

        public MapLocation entry;
        public MapLocation exit;
        public MapLocation key;


        public void SetMap(byte[,] newMap, int newWidth, int newDepth, MapLocation newEntry, MapLocation newExit, MapLocation newKey)
        {
            map = newMap;
            width = newWidth;
            depth = newDepth;
            entry = newEntry;
            exit = newExit;
            key = newKey;
        }

        // Start is called before the first frame update
        //     void Start()
        //     {
        //         // hard code as 5 x 5
        //         width = 5;
        //         depth = 5;
        //         
        //         InitialiseMap();
        // //        Generate();
        //
        //         map[0, 0] = 1; map[1, 0] = 1; map[2, 0] = 1; map[3, 0] = 1; map[4, 0] = 1;
        //         map[0, 1] = 1; map[1, 1] = 0; map[2, 1] = 0; map[3, 1] = 0; map[4, 1] = 1;
        //         map[0, 2] = 1; map[1, 2] = 0; map[2, 2] = 0; map[3, 2] = 0; map[4, 2] = 1;
        //         map[0, 3] = 1; map[1, 3] = 0; map[2, 3] = 0; map[3, 3] = 0; map[4, 3] = 1;
        //         map[0, 4] = 1; map[1, 4] = 1; map[2, 4] = 1; map[3, 4] = 1; map[4, 4] = 1;
        //
        //
        //         DrawMap();
        //     }


        public int CountSquareNeighbours(int x, int z)
        {
            int count = 0;
            if (x <= 0 || x >= width - 1 || z <= 0 || z >= depth - 1) return 5;
            if (map[x - 1, z] == 0) count++;
            if (map[x + 1, z] == 0) count++;
            if (map[x, z + 1] == 0) count++;
            if (map[x, z - 1] == 0) count++;
            return count;
        }

        public int CountDiagonalNeighbours(int x, int z)
        {
            int count = 0;
            if (x <= 0 || x >= width - 1 || z <= 0 || z >= depth - 1) return 5;
            if (map[x - 1, z - 1] == 0) count++;
            if (map[x + 1, z + 1] == 0) count++;
            if (map[x - 1, z + 1] == 0) count++;
            if (map[x + 1, z - 1] == 0) count++;
            return count;
        }

        public int CountAllNeighbours(int x, int z)
        {
            return CountSquareNeighbours(x, z) + CountDiagonalNeighbours(x, z);
        }
    }
}