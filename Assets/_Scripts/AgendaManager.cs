using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace Project1
{
    public class AgendaManager
    { 
   


        private List<AgendaItem> agenda = new List<AgendaItem>();

        // AI Player MUST have an agenda item to open the exit door, otherwise they will never win the game.
        // This is added in the Init() function below.
        public void Init()
        {
            AgendaItem item1 = new AgendaItem();
            item1.task = GameEnums.TaskType.OPEN_EXIT_DOOR;

            agenda.Add(item1);

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
