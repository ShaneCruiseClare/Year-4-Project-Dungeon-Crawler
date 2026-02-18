using NUnit.Framework;
using UnityEngine;


namespace Project1
{
    // stores STATE of player
    public class Player
    {
        public Location location;

        //public List<InventoryItem> inventory;

        // player has ref to maze (so its components get get this reference for actions...)
        public Maze maze;
 

    }
}