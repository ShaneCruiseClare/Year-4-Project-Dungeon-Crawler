using UnityEngine;
using System.Collections.Generic;
using ShaneClareDev;
using Unity.VisualScripting;

namespace ShaneClareDev
{
	public class LoadMapFromTextfile
	{
		private Maze maze;

		private byte[,] map;

		private int numRows;
		private int numCols;

		private MapLocation entry;
		private MapLocation exit;
		private MapLocation key;


		private bool printing = false;

		/**
		 *  GETTER
		 */
		public Maze GetMaze() {  return maze; }


		/*-------------------------------------------------------------
		 * calls methods to create each ROW of the scene
		 */
		public LoadMapFromTextfile(TextAsset levelDataTextFile)
		{
			// (1) declare a newline character variable
			char newlineChar = '\n';

			// (3) read in and make array from level data		
			string[] stringArray = levelDataTextFile.text.Split(newlineChar);

			// (4) call the method to build this maze
			BuildMaze(stringArray);

			maze = new Maze();
			maze.SetMap(map, numRows, numCols, entry, exit, key);

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

				byte n = CharToByte(character);
				map[row, col] = n;

				switch (n)
				{
					case TileType.ENTRY:
						entry = new MapLocation(row, col);
						break;

					case TileType.EXIT:
						exit = new MapLocation(row, col);
						break;

					case TileType.KEY:
						key = new MapLocation(row, col);
						break;
				}
			}
		}

		/*-----------------
		 * convert from characrter to integer
		 * using TileType constants
		 */
		private byte CharToByte(char c)
		{
			if (c == '#') return TileType.WALL;
			if (c == '.') return TileType.FLOOR;
			if (c == 's') return TileType.ENTRY;
			if (c == 'e') return TileType.EXIT;


			if (c == 'k') return TileType.KEY;

			// default - return a walkable = 0
			return 0;
		}

	}
}