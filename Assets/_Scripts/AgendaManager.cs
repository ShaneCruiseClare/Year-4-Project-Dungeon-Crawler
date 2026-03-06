using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

namespace Project1
{
    /*    
         This class manages the player's agenda, which is a list of tasks 
         that the player needs to complete in order to win the game.
         The agenda is represented as a list of AgendaItem objects, which
         include the task type, the path to follow to complete the task, and
         any relevant game objects (e.g. pickups, doors) that are involved in
         completing the task.

            The AgendaManager provides methods to add, remove, and check for tasks
            on the agenda, as well as a method to initialize the agenda with the
            necessary tasks for the player to win the game (e.g. opening the exit door).
            
     */

    public class AgendaManager
    {



        private List<AgendaItem> agenda = new List<AgendaItem>();

        // AI Player MUST have an agenda item to open the exit door, otherwise they will never win the game.
        // This is added in the Init() function below.
        public void Init()
        {
            AgendaItem item1 = new AgendaItem();
            item1.task = GameEnums.TaskType.PATH_TO_EXIT;
            AgendaItem item2 = new AgendaItem();
            item2.task = GameEnums.TaskType.GOTO_EXIT_DOOR;         

            agenda.Add(item1);
            agenda.Add(item2);

        }

        public void Add(AgendaItem item)
        {
            agenda.Add(item);
        }

        public void Push(AgendaItem item)
        {
            agenda.Insert(0, item);
        }

        public AgendaItem Pop()
        {
            if (agenda.Count > 0)
            {
                AgendaItem item = agenda[0];
                agenda.RemoveAt(0);
                return item;
            }
            else
            {
                return null;
            }
        }



        public bool ContainsTask(GameEnums.TaskType task)
        {
            foreach (var item in agenda)
            {
                if (item.task == task)
                {
                    return true;
                }
            }
            return false;
        }

        public bool ContainsAPickup(GameEnums.PickupType pickupType)
        {
            foreach (var item in agenda)
            {
                if (item.pickup.type == pickupType)
                {
                    return true;
                }
            }

            return false;
        }

        override public string ToString()
        {
            string output = "";
            foreach (var item in agenda)
            {
                output += item.task + "\n";
            }

            return output;
        }

    }

}
