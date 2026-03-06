using UnityEngine;

namespace Project1
{
    /* 
        This class is responsible for loading a maze map from a text file and creating a Maze object 
        that represents the map. 
     */
    public class LoadMapFromTextFile
    {
        private Maze maze;

        private byte[,] map;

        private int numRows;
        private int numCols;

        private MapLocation entry;
        private MapLocation exit;

        private bool exitLocked;

        private bool printing = false;

        /**
		 *  GETTER
		 */
        public Maze GetMaze() { return maze; }

        /*-------------------------------------------------------------
		 * empty constructor - just for testing purposes, to create a maze without loading from a text file
		 */
        public LoadMapFromTextFile()
        {
        }

        /*-------------------------------------------------------------
		 * calls methods to create each ROW of the scene
		 */
        public LoadMapFromTextFile(TextAsset levelDataTextFile)
        {
            // (1) declare a newline character variable
            char newlineChar = '\n';

            // (3) read in and make array from level data		
            string[] stringArray = levelDataTextFile.text.Split(newlineChar);

            // (4) call the method to build this maze
            BuildMaze(stringArray);

            maze = new Maze();
            maze.SetMap(map, numRows, numCols, entry, exit, exitLocked);
            maze.keyLocations = MazeUtilities.FindAllKeys(maze);
            maze.exitLocations = MazeUtilities.FindAllExits(maze);

        }

        /*-------------------------------------------------------------
         * calls methods to create each ROW of the scene
         */
        public void LoadMapFromStringArray(string[] stringArray)
        {
            // (4) call the method to build this maze
            BuildMaze(stringArray);

            // if no entry found, assume entry is at exit location (i.e. player spawns at exit)
            if (null == entry)
            {
                entry = exit;
            }

            maze = new Maze();
            maze.SetMap(map, numRows, numCols, entry, exit, exitLocked);
            maze.keyLocations = MazeUtilities.FindAllKeys(maze);
            maze.exitLocations = MazeUtilities.FindAllExits(maze);

        }



        /*-------------------------------------------------------------
		 * create objects on screen as defined by this string array
		 */
        private void BuildMaze(string[] stringArray)
        {
            // count the number of rows in the string array
            numRows = stringArray.Length;
            numCols = stringArray[0].Length;

            if (printing)
            {
                Debug.Log("numRows = " + numCols);
                Debug.Log("numCols = " + numRows);
            }

            map = new byte[numRows, numCols];

            // loop for each row of the array
            for (int row = 0; row < numRows; row++)
            {
                // extract the string for the current row
                string currentRowString = stringArray[row];

                if (printing)
                {
                    Debug.Log(currentRowString);
                }

                // now call CreateRow for this string at this Y position
                CreateRow(row, currentRowString);
            }

        }

        /*-------------------------------------------------------------
		 * create a row of the scene given a string like "X..p...X"
		 */
        private void CreateRow(int row, string currentRowString)
        {
            // calculate X-offset based on Length of the string (numChars)
            int numCols = currentRowString.Length;

            // loop for each character in the row string
            for (int col = 0; col < numCols; col++)
            {
                //			int x = col;
                //			int z = row;
                char character = currentRowString[col];


                if (printing)
                {
                    Debug.Log("(row, col) = (" + row + ", " + col + ")");
                }

                byte n = TileType.CharToByte(character);

                map[row, col] = n;

                if (n > 1)
                {
                    Debug.Log(" LODADING - (" + row + "," + col + ") tile type char = '" + character + "'");
                }

                switch (n)
                {
                    case TileType.ENTRY:
                        entry = new MapLocation(row, col);
                        break;

                    case TileType.EXIT:
                        exit = new MapLocation(row, col);
                        break;
                    case TileType.EXIT_LOCKED:
                        exitLocked = true;
                        break;
                }
            }
        }

    }
}
