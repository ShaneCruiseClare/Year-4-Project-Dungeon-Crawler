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
    //          if FAILURE, then ....
    //      if NO then Fred needs to ask the TaskSimplifier to provide a list of one or more simpler tasks
    //          and then replace first item on agenda with these simpler tasks
    // then repeart from 1. above ...

    public class AgentPlanController
    {
        private Player player;
        AgendaManager agenda = new AgendaManager();


        TaskExecuter taskExecuter;
        TaskSimifier taskSimplifier;

        public AgentPlanController()
        {
           taskExecuter = new TaskExecuter(player);
           taskSimplifier = new TaskSimifier();
           CompleteLevel();
        }

        public void DecomposeTask()
        {


        }

        public void CompleteLevel()
        {
            bool levelComplete = false;
            while (!levelComplete)
            {

                // has player completed level?
                if (agenda.ContainsTask(GameEnums.TaskType.COMPLETE_LEVEL))
                {
                    levelComplete = true;
                }
                else
                {
                    // if not, then need to work through agenad items
                    // get ('pop' off) first item from agenda
                    AgendaItem currentTask = agenda.Pop();

                    if (TaskExecuter.NeedsDecomposing(currentTask))
                    {
                        // this will change what tasks are on the agenda
                        //DecomposeTask(currentTask);
                    }
                    else if (TaskSimifier.CanSimplifyTask(currentTask.task))
                    {
                        // this will change what tasks are on the agenda
                        // newAgendaItems = SimplifyTask(currentTask
                    } else
                    {
                        taskExecuter.Execute(currentTask);
                    }
           
                }
            }
        }
    }
}

