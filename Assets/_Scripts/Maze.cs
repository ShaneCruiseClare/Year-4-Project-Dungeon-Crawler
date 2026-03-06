using System.Collections.Generic;

namespace Project1
{
    /* 
        This class represents the maze in the game, including the layout of the maze 
        (represented as a 2D array of bytes), the locations of the entry and exit points, 
        the state of the exit door (locked or unlocked), and the locations of any keys in the maze.

        The Maze class provides methods to retrieve the state of the exit door, the player spawn location, 
        the key locations, and the exit location. It also includes a method to set the maze layout and 
        properties, as well as methods to count the number of square and diagonal neighbours for a given 
        location in the maze (which can be used for pathfinding and AI decision-making).
     */
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
        public bool exitLocked;
        public List<MapLocation> keyLocations;
        public List<MapLocation> exitLocations;


        public bool ExitDoorLocked()
        {
            // TODO - make this return the actual state of the exit door
            
            return true;

        }
        public bool GetExitDoor()
        {
            //GameState instance = GameState.GetInstance();
            
            return true;
        }

        public MapLocation GetPlayerSpawnLocation()
        {
            // TODO - make this return the actual state of the player spawn location
            // Change this to check if the entry location is valid (i.e. not a wall)
            return entry;
        }

        public List<MapLocation> GetKeyLocations()
        {
            // TODO - make this return the actual state of the key locations
            // Change this to return the actual key locations in the maze  
            return keyLocations;
        }

        public bool PlayerHasKey()
        {
            // TODO - make this return the actual state of whether the player has the key or not
            // Change this to check the player's inventory for the key  
            return false;
        }

        public MapLocation GetExitLocation()
        {
            // TODO - make this return the actual location of the exit door
            // Change this to return the actual exit location of maze  
            return exit;
        }




        public void SetMap(
            byte[,] newMap,
            int newWidth,
            int newDepth,
            MapLocation newEntry,
            MapLocation newExit,
            bool newExitLocked
            )
        {
            map = newMap;
            width = newWidth;
            depth = newDepth;
            entry = newEntry;
            exit = newExit;
            exitLocked = newExitLocked;
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
