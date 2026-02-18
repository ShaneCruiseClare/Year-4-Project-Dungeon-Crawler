using UnityEngine;
using System;
using System.Collections.Generic;

namespace Project1
{
    // list of locatiosn - a path to follow
    // list of pickups - candidatesd to pickup

    // need a reference to game objects?
    //  player
    //  enemy
    //  doors
    // 

    public class AgendaItem 
    {
        public GameEnums.TaskType task;

        // ???? do we need a list of locations to follow to complete the task?
        // e.g. for OPEN_EXIT_DOOR, the location would be the location of the exit door

        public List<Location> path;

        public Location location;
        public Pickup pickup;
        public Door door;

    }
}