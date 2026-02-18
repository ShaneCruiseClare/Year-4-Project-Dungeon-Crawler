namespace Project1
{
    public class GameState 
    {
        private static GameState instance = null; 

        public static GameState GetInstance()
        {
            return instance;
        }

        //-------------------------

        public GameState()
        {
            instance = this;
        }

        public bool exitDoorLocked = false;
        public Location playerLocation;

    }
}
