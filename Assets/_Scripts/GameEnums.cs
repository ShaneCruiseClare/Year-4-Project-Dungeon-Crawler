using UnityEngine;
using System;
using System.Collections.Generic;

namespace Project1
{
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
            FIND_EXIT_LOCATION,
            PICKUP_KEY,
            USE_KEY,
            GET_RED_KEY,
            GET_BLUE_KEY,
            FIND_A_PICKUP_LOCATION,
            FIND_AND_FOLLOW_PATH
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
