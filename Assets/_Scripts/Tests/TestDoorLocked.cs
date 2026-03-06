using NUnit.Framework;



namespace Project1.Tests
{
    [TestFixture]
    public class TestDoorLocked
    {
        // A Test behaves as an ordinary method
        [Test]
        public void TestDoorLockedSimplePasses()
        {
            // Use the Assert class to test conditions
            bool d1 = false;

            Project1.Door door = new Project1.Door();
            door.locked = false;
            d1 = door.IsDoorLocked(door.locked, door.blueKey, door.redKey);
            Assert.IsTrue(d1);

        }

        [Test]
        public void TestDoorLockedTrue()
        {
            // Use the Assert class to test conditions
            bool d2 = false;
            
            LoadMapFromTextFile loader = new LoadMapFromTextFile();
            string[] map = new string[] {
                "#######",
                "#E#k..#",
                "#.#...#",
                "#...s.#",
                "#######"
            };

            loader.LoadMapFromStringArray(map);
            Project1.Door door = new Project1.Door();
            door.locked = true;
            d2 = door.IsDoorLocked(door.locked, door.blueKey, door.redKey);
            Assert.IsTrue(d2);



        }
    }
}

