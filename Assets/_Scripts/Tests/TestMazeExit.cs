using NUnit.Framework;

namespace Project1
{
    public class TestMazeExit
    {
        // A Test behaves as an ordinary method
        [Test]
        public void TestMazeExitSimplePasses()
        {

            string[] maze1 = new string[] {
                "############",
                "#.......e..#",
                "#...##...k.#",
                "#s.....##..#",
                "############"
            };


            LoadMapFromTextFile loader = new LoadMapFromTextFile();
            loader.LoadMapFromStringArray(maze1);

            // get the maze exit location from maze 
            Maze maze = loader.GetMaze();
            MapLocation exitLocation = maze.GetExitLocation();

            Assert.NotNull(exitLocation);

        }


    }
}
