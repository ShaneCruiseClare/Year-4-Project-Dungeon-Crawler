using System.Collections.Generic;


namespace Project1
{
    
    public class Player
    {
        public Location location;

        public List<InventoryItem> inventory;

        // player has ref to maze (so its components get this reference for actions...)
        public Maze maze;

        public Player(Maze maze)
        {
            this.maze = maze;

        }


        public List<InventoryItem> GetPlayerInventory()
        {

            return inventory;
        }

    }
}