using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Project1.Tests
{
    
    public class TestPathExitAgenda
    {
        [Test]
        public void TestPathToExit()
        {
            string[] maze3 = new string[] {
                "############",
                "#.......e..#",
                "#...##...k.#",
                "#s.....##..#",
                "############"
            };

            LoadMapFromTextFile loader = new LoadMapFromTextFile();
            loader.LoadMapFromStringArray(maze3);

            // get the maze exit location from maze 
            Maze maze = loader.GetMaze();
            // Test the agenda manager to see if it can add the path to the exit to the agenda
            AgendaManager agenda = new AgendaManager();
            // test that the path to the exit is added to the agenda
            agenda.Init();
            // add the path to the exit to the agenda
            MapLocation exitLocation = maze.GetExitLocation();
            AgendaItem pathToExit = new AgendaItem(GameEnums.TaskType.GOTO_EXIT_DOOR, GameEnums.TaskType.OPEN_EXIT_DOOR, exitLocation);
            agenda.Add(pathToExit);
            // check that the agenda contains the path to the exit
            Assert.IsTrue(agenda.ContainsTask(GameEnums.TaskType.GOTO_EXIT_DOOR));


        }
    }
}
