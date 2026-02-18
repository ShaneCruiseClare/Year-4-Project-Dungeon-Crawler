using UnityEngine;

namespace Project1
{
    // Fred manages the agenda
    // mostly working on the first item (current task to complete) in the agenda ....


    //
    // Fred does the following:
    // 1. get first item from agenda
    // 2. ask TaskExecuter if it can execute that task
    //      if YES - then ask it to execute the task    
    //          if SUCCESS, then remove task from agenda and repeat from 1.
    //          if FAILUER, then ....
    //      if NO then Fred needs to ask the TaskSimplifier to provide a list of one or more simpler tasks
    //          and then replace first item on agenda with these simpler tasks
    // then repeart from 1. above ...

    // TODO - rename 
    // e.g. PlayerManager or something like that .... but for now, just call it Fred :)
    public class Fred
    {
        private Player player;



        public void FredTask()
        {
            AgendaManager agenda = new AgendaManager();


            TaskExecuter taskExecuter = new TaskExecuter(player);

            // has player completed level?
            // if not, then need to work through agenad items
            // get ('pop' off) first item from agenda
            // try to execute that task ...
            //     if taskExecuter cannot execute that task (needs decomposing into simpler task(s), then ask TaskSimplifier for simpler tasks to complete that task
            //     and then replace first item on agenda with these simpler tasks
            //     and then repeat from 1. above ...
            //
            //      if taskExecuter can execute top task, then execute it
            //          if task execution is successful, then remove that task from agenda and repeat from 1.
            //          if task execution is unsuccessful, then try to solve byt examing the failure in the report
            //              and then repeat from 1. above ...


            //if (taskExecuter.NeedsDecomposing())
            //{
            //    // ask TaskSimplifier for simpler tasks to complete the OPEN_EXIT_DOOR task
            //    // return a list of tasks:
            //    //      1. FIND_KEY
            //    //      2. USE_KEY
            //}
            //else
            //{
            //    // execute the task
            //}

        }
    }
}