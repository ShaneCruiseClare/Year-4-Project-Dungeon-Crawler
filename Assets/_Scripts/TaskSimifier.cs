using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

namespace Project1
{
    public class TaskSimifier
    {

        public List<AgendaItem> SimplifyTask(GameEnums.TaskType task)
        {
            List<AgendaItem> agendaItems = new List<AgendaItem>();

            // this method will return a list of simpler tasks that
            // be used to complete the given task
            if (task.Equals(GameEnums.TaskType.GET_BLUE_KEY))
            {
                Pickup pickup1 = new Pickup();
                pickup1.type = GameEnums.PickupType.KEY_BLUE;

                AgendaItem agendaItem1 = new AgendaItem();
                agendaItem1.task = GameEnums.TaskType.FIND_A_PICKUP_LOCATION;
                agendaItem1.pickup = pickup1;

                agendaItems.Add(agendaItem1);
            }

            return agendaItems;
        }

    }
}
