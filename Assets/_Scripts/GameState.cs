namespace Project1
{
    /* 
        This class represents the current state of the game, including the player's location, 
        whether the exit door is locked or open, and whether the player has the key. 
        It is implemented as a singleton, so that there is only one instance of the GameState 
        class throughout the game. The GameState class provides a method to retrieve the instance 
        of the class, as well as a constructor to initialize the instance.
        The GameState class can be used by the AI system to make decisions based on the current 
        state of the game, such as whether the player can open the exit door or whether they need 
        to find a key first. 

     */
    public class GameState
    {
        private static GameState instance = null;
        public bool exitDoorLocked = false;
        public bool hasKey = false;
        public bool exitDoorOpen = false;

        public Location playerLocation;

        public static GameState GetInstance()
        {
           
            return instance;
        }

        //-------------------------

        public GameState()
        {

            instance = this;

        }

    }
}
