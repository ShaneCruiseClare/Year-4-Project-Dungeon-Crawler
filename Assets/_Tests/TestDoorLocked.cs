using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Project1;
namespace Project1 {
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
    }

}

