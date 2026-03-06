using UnityEngine;

namespace Project1
{
    public class TaskExecuter : MonoBehaviour
    {
        private Player myParent;
        Maze maze;

        // cosntructor - store reference to PARENT "Player"
        public TaskExecuter(Player player)
        {
            myParent = player;
            maze = player.maze;
        }

        public static bool NeedsDecomposing(AgendaItem item)
        {
            if (item.task.Equals(GameEnums.TaskType.OPEN_EXIT_DOOR))
            {
                return false;
            }
            return true;
        }


        /*
         
        e.g. JSON
        [
            
            {"OPEN_EXIT_DOOR": false},
            {"CLOSE_DOOR": false},
            {"DROP_PICKUP(blue key)": false},

        ]
       

        */



        //
        // can get reference to GameState
        // e.g.
        //    GameState.GetInstance.exitDoorLocked ....

       
        public TaskSuccessReport Execute(AgendaItem item)
        {
            // execute the task
            // e.g. if task is OPEN_EXIT_DOOR, then check if player has the key, and if so, open the door
            if (item.task.Equals(GameEnums.TaskType.OPEN_EXIT_DOOR))
            {
                GameState instance = GameState.GetInstance();

                return TryOpenDoor();
            }

            // if get here, then task is not recognized, so return failure report

            TaskSuccessReport report = new TaskSuccessReport();
            report.success = false;
            report.failureType = GameEnums.TaskFailureReasonType.UNDEFINED;
            return report;
        }


        // TODO:
        // add to "Further Work" Chapter 
        // how you could refactor these methods with the "Command" design pattern...
        private TaskSuccessReport TryOpenDoor()
        {
            // need to be at DOOR LOCATION]
            // TODO !!! find from maze

            //
            // use REF to parent .... e.g. Location currentLocation = myParent.GetCurrentLocation();
            //Location currentLocation = myParent.GetCurrentLocation();
            bool atDoorLocation = true;

            // DOOR needs to be unlocked/open
            // TODO !!! find from maze
            //
            // use REF to GameState .... e.g. bool doorLocked = Maze.getInstance().exitDoorLocked;

            bool doorLocked = GameState.GetInstance().exitDoorOpen;

            TaskSuccessReport report = new TaskSuccessReport();
            report.success = true;

            // failure condition
            if (!atDoorLocation)
            {
                report.success = false;
                report.failureType = GameEnums.TaskFailureReasonType.NOT_AT_DOOR;
                return report;
            }

            // failure condition
            if (doorLocked)
            {
                report.success = false;
                report.failureType = GameEnums.TaskFailureReasonType.DOOR_LOCKED_BLUE_KEY_NEEDED;
                return report;
            }

            return report;
        }

    }
}
