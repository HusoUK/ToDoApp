using ToDo.Models;

namespace ToDo.Services
{
    public interface IBasicToDoServices
    {
        List<IBasicTask> AddTask(string tasktodo);
        void CompleteTask(IBasicTask task);
        IBasicTask CreateTask(string description);
    }
}