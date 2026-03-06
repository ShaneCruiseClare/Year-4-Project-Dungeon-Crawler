using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Project1.Tests

{
    public class TestMazeExitLocked
    {
        // A Test behaves as an ordinary method
        [Test]
        public void TestMazeExitLockedSimplePass()
        {
            string[] maze2 = new string[] {
                "############",
                "#.......E..#",
                "#...##...k.#",
                "#s.....##..#",
                "############"
            };
            
            LoadMapFromTextFile loader = new LoadMapFromTextFile();
            loader.LoadMapFromStringArray(maze2);

            // get the maze exit location from maze 
            Maze maze = loader.GetMaze();
            bool exitLocked = maze.ExitDoorLocked();

            Assert.IsTrue(exitLocked);
        }
    }
}
