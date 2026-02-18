using UnityEngine; 

namespace Project1
{
    public class TaskSuccessReport
    {
        public bool success;
        public GameEnums.TaskFailureReasonType failureType = GameEnums.TaskFailureReasonType.UNDEFINED;
    }
}
