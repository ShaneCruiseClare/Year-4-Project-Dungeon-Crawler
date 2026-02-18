using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

namespace Project1
{
    [TestFixture]
    public class TestKeyFound
    {



        [Test]
        public void TestRedKeyFound()
        {
            // (1) Arrange: Set up the conditions for the test
            // Use the Assert class to test conditions
            bool keyRedFound = false;

            // create a red key pickup
            Pickup redKeyPickup = new Pickup();
            redKeyPickup.type = GameEnums.PickupType.KEY_RED;

            // create an agenda item for the red key pickup 
            AgendaItem keyPickupItem = new AgendaItem();
            keyPickupItem.pickup = new Pickup();

            // (2) Act: Perform the action that you want to test
            keyPickupItem.pickup.type = GameEnums.PickupType.KEY_RED;

            // create an agenda manager and add the red key pickup item to it
            Project1.AgendaManager agenda1 = new Project1.AgendaManager();
            agenda1.Add(keyPickupItem);

            // (3) Assert: Verify that the expected outcome has occurred
            keyRedFound = agenda1.ContainsAPickup(GameEnums.PickupType.KEY_RED);

            Assert.IsTrue(keyRedFound);
        }

        [Test]
        public void TestRedKeyNotFound()
        {
            // (1) Arrange: Set up the conditions for the test
            // Use the Assert class to test conditions
            bool keyRedFound = false;

            // create an agenda item with no pickups
            AgendaItem emptyAgendaItem = new AgendaItem();
            emptyAgendaItem.pickup = new Pickup();

            // create an agenda manager and add the empty agenda item to it
            Project1.AgendaManager agenda1 = new Project1.AgendaManager();
            agenda1.Add(emptyAgendaItem);

            // (2) Act: Perform the action that you want to test
            keyRedFound = agenda1.ContainsAPickup(GameEnums.PickupType.KEY_RED);

            // (3) Assert: Verify that the expected outcome has occurred
            Assert.IsFalse(keyRedFound);
        }

        [Test]
        public void BlueKeyFound()
        {
            // (1) Arrange: Set up the conditions for the test
            // Use the Assert class to test conditions
            bool keyBlueFound = false;

            // create a blue key pickup
            Pickup blueKeyPickup = new Pickup();
            blueKeyPickup.type = GameEnums.PickupType.KEY_BLUE;

            // create an agenda item for the blue key pickup 
            AgendaItem keyPickupItem = new AgendaItem();
            keyPickupItem.pickup = new Pickup();

            // (2) Act: Perform the action that you want to test
            keyPickupItem.pickup.type = GameEnums.PickupType.KEY_BLUE;

            // create an agenda manager and add the red key pickup item to it
            Project1.AgendaManager agenda1 = new Project1.AgendaManager();
            agenda1.Add(keyPickupItem);

            // (3) Assert: Verify that the expected outcome has occurred
            keyBlueFound = agenda1.ContainsAPickup(GameEnums.PickupType.KEY_BLUE);

            Assert.IsTrue(keyBlueFound);
        }
    }
}
