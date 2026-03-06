using System.Collections.Generic;

namespace Project1
{
    // list of locations - a path to follow
    // list of pickups - candidatesd to pickup

    // need a reference to game objects?
    //  player
    //  enemy
    //  doors
    // 

    /* 
        This class represents an item on the agenda for the player to complete. 
        It includes the task type, the path to follow to complete the task, and 
        any relevant game objects (e.g. pickups, doors) that are involved in 
        completing the task.
        
        Its provides a structured way to represent the player's goals and the steps 
        needed to achieve them, which can be used by the AI system to plan and execute 
        actions in the game world.
     */
    public class AgendaItem
    {
        // the type of task to complete (e.g. PATH_TO_EXIT, PICKUP_KEY, OPEN_DOOR)
        // test with PATH_TO_EXIT first, then add more task types as needed
        // for PATH_TO_EXIT, the path would be the path to the exit door
        
        public GameEnums.TaskType task;
        
        // ???? do we need a list of locations to follow to complete the task?
        // e.g. for OPEN_EXIT_DOOR, the location would be the location of the exit door

        public List<Location> path;

        public Location location;
        public Pickup pickup;
        public Door door;

        public AgendaItem()
        {

        }

        public AgendaItem(GameEnums.TaskType goto_exit_door,GameEnums.TaskType open_exit_door, MapLocation exitLocation)
        {
            GOTO_EXIT_DOOR = goto_exit_door;
            ExitLocation = exitLocation;
            OPEN_EXIT_DOOR = open_exit_door;
        }

        // Getters for the task type and exit location
        public GameEnums.TaskType GOTO_EXIT_DOOR { 
            get; 
        }
        public MapLocation ExitLocation 
        { 
            get; 
        }

        public GameEnums.TaskType OPEN_EXIT_DOOR
        {
            get;
        }
    }
}