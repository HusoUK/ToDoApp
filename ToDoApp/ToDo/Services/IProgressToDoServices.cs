using ToDo.Models;

namespace ToDo.Services
{
    public interface IProgressToDoServices
    {
        List<IProgressTask> AddTask(string description);
        void ArchiveTask(IProgressTask task);
        List<IProgressTask> CompleteTask(IProgressTask task);
        IProgressTask CreateTask(string description);
        void DeleteArchived(IProgressTask taskToDelete);
        void StartTask(IProgressTask task);
        void WaitingTask(IProgressTask task);
    }
}