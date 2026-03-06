namespace Project1
{
    /* 
        This class defines the various enums used in the game, including:
        - PickupType: the types of pickups that can be found in the maze (e.g. food, keys)
        - TaskType: the types of tasks that the player can be assigned (e.g. open exit door, 
          find exit location)
        - TaskFailureReasonType: the reasons why a task might fail (e.g. not at door, door 
          locked, not have key)
        
         These enums provide a structured way to represent the different types of pickups, tasks,
         and failure reasons in the game, which can be used by the AI system to plan and execute
         actions in the game world.
        
    */
    public class GameEnums

    {

        public enum PickupType
        {
            FOOD,
            KEY_BLUE,
            KEY_RED
        }

        public enum TaskType
        {
            OPEN_EXIT_DOOR,
            GOTO_EXIT_DOOR,
            FIND_EXIT_LOCATION,
            PATH_TO_EXIT,
            PICKUP_KEY,
            USE_KEY,
            GET_RED_KEY,
            GET_BLUE_KEY,
            FIND_A_PICKUP_LOCATION,
            FIND_AND_FOLLOW_PATH,
            COMPLETE_LEVEL
        }

        public enum TaskFailureReasonType
        {
            NOT_AT_DOOR,
            DOOR_LOCKED_BLUE_KEY_NEEDED,
            DOOR_LOCKED_RED_KEY_NEEDED,
            NOT_HAVE_KEY,
            UNDEFINED
        }


    }

}
